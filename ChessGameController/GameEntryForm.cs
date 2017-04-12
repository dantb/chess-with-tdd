﻿using ChessWithTDD;
using ChessGameUI;
using System;
using System.Windows.Forms;
using System.Windows.Forms;

using System.Windows;
using System.Windows.Forms.Integration;

namespace ChessGameController
{
    public partial class GameEntryForm : Form
    {
        public IBoard theBoard;

        public GameEntryForm()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            theBoard = GetAFullyInitialisedGameBoard();

            MainWindow chessBoardGUI = new MainWindow(theBoard, BlackTeamRB.Checked ? Colour.Black : Colour.White);
            ElementHost.EnableModelessKeyboardInterop(chessBoardGUI);
            chessBoardGUI.MoveChosenEvent += ChessBoardGUI_MoveChosenEvent;

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

        private void ChessBoardGUI_MoveChosenEvent(object sender, MoveProviderEventArgs e)
        {
            IMove move = e.TheMove;
            ISquare fromSquare = theBoard.GetSquare(move.FromRow, move.FromCol);
            ISquare toSquare = theBoard.GetSquare(move.ToRow, move.ToCol);
            if (theBoard.MoveIsValid(fromSquare, toSquare))
            {
                theBoard.Apply(fromSquare, toSquare);
                MainWindow chessBoard = (MainWindow) sender;
                chessBoard.ColourOfTeamWithTurn = chessBoard.ColourOfTeamWithTurn == Colour.White ?
                    Colour.Black : Colour.White;
            }
            else
            {
                string rowColumnString = $"row {fromSquare.Row}, column {fromSquare.Col}, to row {toSquare.Row}, column {toSquare.Col}";
                System.Windows.MessageBox.Show("Move from " + rowColumnString + "is invalid.");
            }
        }

        private IBoard GetAFullyInitialisedGameBoard()
        {
            IBoardInitialiser boardInitialiser = new BoardInitialiser();
            IMoveValidator moveValidator = GetAMoveValidator();
            IPawnManager pawnManager = GetAPawnManager();
            IBoardCache boardCache = new BoardCache();
            ICheckManager checkManager = GetACheckManager(boardCache);

            theBoard = new Board(boardInitialiser, moveValidator, pawnManager,
                boardCache, checkManager);
            return theBoard;
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