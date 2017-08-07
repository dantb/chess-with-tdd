﻿using Autofac;
using ChessGameUI;
using ChessWithTDD;
using System;
using System.Windows.Forms;

namespace ChessGameController
{
    public partial class GameEntryForm : Form
    {
        public GameEntryForm()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            IBoard theBoard = NewBoard();
            BoardFrontEnd chessBoardGUI = GetBoardUI(theBoard);
            RunChessGame(chessBoardGUI);
        }

        private static void RunChessGame(BoardFrontEnd chessBoardGUI)
        {
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

        private BoardFrontEnd GetBoardUI(IBoard board)
        {
            BoardFrontEnd chessBoardGUI = new BoardFrontEnd(board, BlackTeamRB.Checked ? Colour.Black : Colour.White, true);
            chessBoardGUI.MoveChosenEvent += ChessBoardGUI_MoveChosenEvent;
            return chessBoardGUI;
        }

        private BoardFrontEnd GetBoardUIWithNewUnderlyingBoard()
        {
            //Configure container and resolve a board
            ContainerConfiguration.Configure();
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                IBoard board = scope.Resolve<IBoard>();
                BoardFrontEnd chessBoardGUI = new BoardFrontEnd(board, BlackTeamRB.Checked ? Colour.Black : Colour.White, true);
                chessBoardGUI.MoveChosenEvent += ChessBoardGUI_MoveChosenEvent;
                return chessBoardGUI;
            }
        }

        private IBoard NewBoard()
        {
            //Configure container and resolve a board
            ContainerConfiguration.Configure();
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                return scope.Resolve<IBoard>();
            }
        }

        private void ChessBoardGUI_MoveChosenEvent(object sender, MoveProviderEventArgs e)
        {
            BoardFrontEnd playingBoard = (BoardFrontEnd) sender;
            IBoard board = playingBoard.Board;
            Move move = e.TheMove;
            ISquare fromSquare = board.GetSquare(move.FromRow, move.FromCol);
            ISquare toSquare = board.GetSquare(move.ToRow, move.ToCol);
            if (board.MoveIsValid(fromSquare, toSquare))
            {
                ApplyMove(playingBoard, board, fromSquare, toSquare);
            }
            else
            {
                ShowInvalidMoveDialogue(fromSquare, toSquare);
            }
        }

        private void ApplyMove(BoardFrontEnd chessBoard, IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            Colour teamThatMoved = board.TeamWithTurn;
            //after applying the move, the team with turn will switch
            board.Apply(fromSquare, toSquare);
            if (board.CheckMate)
            {
                ShowCheckMateDialogue(teamThatMoved, chessBoard);
            }
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

        private void LoadPositionButton_Click(object sender, EventArgs e)
        {
            if (BrowsePositionFileDialogue.ShowDialog() == DialogResult.OK)
            {
                string file = BrowsePositionFileDialogue.FileName;
                if (!string.IsNullOrEmpty(file))
                {
                    PositionLoader loader = new PositionLoader();
                    BoardFrontEnd boardUI = GetBoardUIWithNewUnderlyingBoard();
                    //now load up the position
                    if (loader.LoadPositionIntoBoard(boardUI.Board, file))
                    {
                        RunChessGame(boardUI);
                    }
                }
            }
            BrowsePositionFileDialogue.Reset();
        }
    }
}
