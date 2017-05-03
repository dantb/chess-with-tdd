using System.Collections.Generic;
using System.Linq;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class Board : IBoard
    {
        private List<List<ISquare>> _squares;
        private IMoveValidator _moveValidator;
        private IPawnManager _pawnManager;
        private IBoardCache _boardCache;
        private ICheckManager _checkManager;

        public Board(IBoardInitialiser boardInitialiser, IMoveValidator moveValidator, IPawnManager pawnManager, IBoardCache boardCache, ICheckManager checkManager)
        {
            InitialiseBoardDimensions();
            boardInitialiser.InitialiseBoardPieces(this);
            _moveValidator = moveValidator;
            _pawnManager = pawnManager;
            _boardCache = boardCache;
            _boardCache.InitialiseBoardCache(this);
            _checkManager = checkManager;
        }

        public List<ISquare> PendingUpdates { get; set; } = new List<ISquare>();

        public bool InCheck { get; set; } = false;

        public bool CheckMate { get; set; } = false;

        public int TurnCounter { get; set; } = 0;

        public int ColCount { get { return _squares.Count; } }

        public int RowCount { get { return _squares.FirstOrDefault().Count; } }

        public List<List<ISquare>> Squares { get { return _squares; } }

        public ISquare GetSquare(int row, int col)
        {
            return _squares[row][col];
        }

        public bool MoveIsValid(ISquare fromSquare, ISquare toSquare)
        {
            if (!_moveValidator.MoveIsValid(fromSquare, toSquare, this))
            {
                return false;
            }
            return fromSquare.Piece.CanMove(fromSquare, toSquare);
        }      

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IPawn)
            {
                _pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, this);
            }

            //Squares that had been marked two turns ago should be unmarked
            _pawnManager.UnmarkEnPassantSquares(TurnCounter);

            //This is where we actually execute the move
            ActualApply(fromSquare, toSquare);

            //Update board cache for easy access to pieces
            _boardCache.UpdateBoardCache();

            //Evaluate check states after move has been applied
            _checkManager.UpdateCheckAndCheckMateStates(this, toSquare);

            TurnCounter++;
        }

        private void ActualApply(ISquare fromSquare, ISquare toSquare)
        {
            GetSquare(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            GetSquare(toSquare.Row, toSquare.Col).ContainsPiece = true;
            GetSquare(fromSquare.Row, fromSquare.Col).Piece = null;
            GetSquare(fromSquare.Row, fromSquare.Col).ContainsPiece = false;
            PendingUpdates.Add(fromSquare);
            PendingUpdates.Add(toSquare);
        }           

        public void SetSquare(ISquare square)
        {
            _squares[square.Row][square.Col] = square;
        }

        private void InitialiseBoardDimensions()
        {
            _squares = new List<List<ISquare>>();
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                List<ISquare> rowOfBoard = new List<ISquare>();
                for (int j = 0; j < BOARD_DIMENSION; j++)
                {
                    rowOfBoard.Add(new Square(i, j));
                }
                _squares.Add(rowOfBoard);
            }
        }
    }
}
