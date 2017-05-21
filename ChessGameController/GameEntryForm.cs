using ChessGameUI;
using ChessWithTDD;
using System;
using System.Windows.Forms;

namespace ChessGameController
{
    public partial class GameEntryForm : Form
    {
        private IBoard _theBoard;

        public GameEntryForm()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            BoardFrontEnd chessBoardGUI = GetBoardUI();
            try
            {
                chessBoardGUI.ShowDialog();
            }
            catch
            {
                System.Windows.MessageBox.Show("Exception in chess WPF board, closing the window.");
                chessBoardGUI.Close();
            }
        }

        private BoardFrontEnd GetBoardUI()
        {
            _theBoard = GetAFullyInitialisedGameBoard();

            BoardFrontEnd chessBoardGUI = new BoardFrontEnd(_theBoard, BlackTeamRB.Checked ? Colour.Black : Colour.White);
            chessBoardGUI.MoveChosenEvent += ChessBoardGUI_MoveChosenEvent;
            return chessBoardGUI;
        }

        private void ChessBoardGUI_MoveChosenEvent(object sender, MoveProviderEventArgs e)
        {
            IMove move = e.TheMove;
            ISquare fromSquare = _theBoard.GetSquare(move.FromRow, move.FromCol);
            ISquare toSquare = _theBoard.GetSquare(move.ToRow, move.ToCol);
            if (_theBoard.MoveIsValid(fromSquare, toSquare))
            {
                ApplyMove((BoardFrontEnd)sender, fromSquare, toSquare);
            }
            else
            {
                ShowInvalidMoveDialogue(fromSquare, toSquare);
            }
        }

        private void ApplyMove(BoardFrontEnd chessBoard, ISquare fromSquare, ISquare toSquare)
        {
            _theBoard.Apply(fromSquare, toSquare);
            Colour teamThatMoved = chessBoard.ColourOfTeamWithTurn;
            if (_theBoard.CheckMate)
            {
                ShowCheckMateDialogue(teamThatMoved, chessBoard);
            }
            chessBoard.ColourOfTeamWithTurn = teamThatMoved == Colour.White ?
                Colour.Black : Colour.White;
        }

        private void ShowInvalidMoveDialogue(ISquare fromSquare, ISquare toSquare)
        {
            string rowColumnString = $"row {fromSquare.Row}, column {fromSquare.Col}, to row {toSquare.Row}, column {toSquare.Col}";
            System.Windows.MessageBox.Show("Move from " + rowColumnString + "is invalid.");
        }

        private void ShowCheckMateDialogue(Colour winningColour, BoardFrontEnd chessBoard)
        {
            const string White = "white";
            const string Black = "black";
            string winningTeam = winningColour == Colour.White ?
                White : Black;
            string losingTeam = winningColour == Colour.White ?
                Black : White;
            MessageBox.Show(
                $"The {losingTeam} king is in checkmate. The {winningTeam} team wins!\n\n\tClick ok to close the board.",
                "Check mate!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            chessBoard.Close();
        }

        private IBoard GetAFullyInitialisedGameBoard()
        {
            IBoardInitialiser boardInitialiser = new BoardInitialiser();
            IMoveValidator moveValidator = GetAMoveValidator();
            IPawnManager pawnManager = GetAPawnManager();
            IBoardCache boardCache = new BoardCache();
            ICheckManager checkManager = GetACheckManager(boardCache);

            IStrictServiceLocator strictServiceLocator = null;

            _theBoard = new Board(strictServiceLocator);
            return _theBoard;
        }

        private IMoveValidator GetAMoveValidator()
        {
            IGenericMoveValidator genericMoveValidator = new GenericMoveValidator();
            IMultiSquareMoveValidator multiSquareMoveValidator = new MultiSquareMoveValidator();
            IMoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiSquareMoveValidator);
            return moveValidator;
        }

        private IPawnManager GetAPawnManager()
        {
            IEnPassantManager enPassantManager = new EnPassantManager();
            IPawnManager pawnManager = new PawnManager(enPassantManager);
            return pawnManager;
        }

        private ICheckManager GetACheckManager(IBoardCache boardCache)
        {
            ICheckMateEscapeManager checkMateEscapeManager = new CheckMateEscapeManager();
            ICheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            ICheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            return checkManager;
        }
    }
}
