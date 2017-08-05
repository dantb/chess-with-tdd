using ChessWithTDD;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChessGameUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BoardFrontEnd : Window, IMoveProvider
    {
        private DragManager _dragManager;
        private PositionStateManager _positionStateManager;
        private IBoard _board;

        public BoardFrontEnd(IBoard board, Colour playerColour)
        {
            InitializeComponent();
            _positionStateManager = new PositionStateManager();
            SetDataContext(board);
        }

        public IBoard Board
        {
            get { return _board; }
            private set
            {
                _board = value;
                _board.MoveAppliedEvent += _board_MoveAppliedEvent;
                _dragManager = new DragManager(_board, this);
            }
        }

        private void _board_MoveAppliedEvent(object sender, MoveAppliedEventArgs eventArgs)
        {
            _positionStateManager.SaveMove(eventArgs.Data);
        }

        public event MoveProviderEventHandler MoveChosenEvent;

        internal void RaiseMoveChosenEvent(MoveProviderEventArgs e)
        {
            MoveChosenEvent?.Invoke(this, e);
        }

        private void SetDataContext(IBoard board)
        {
            foreach (UIElement item in ChessGrid.Children)
            {
                Button button = (Button)item;
                if (button.Content is Image)
                {
                    ((Image)button.Content).Opacity = 1;
                }

            }
            DataContext = board;
            Board = board;
        }

        #region Event Handlers

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (!_dragManager.InDrag)
                    {
                        int gridRow = Grid.GetRow(button);
                        int gridCol = Grid.GetColumn(button);
                        if (Board.GetSquare(gridRow, gridCol).ContainsPiece)
                        {
                            if (Board.GetSquare(gridRow, gridCol).Piece.Colour == Board.TeamWithTurn)
                            {
                                if (button.Content is Image &&
                                    _dragManager.LastButtonLeftMousePressedIn == button)
                                {
                                    _dragManager.BeginDrag(button);
                                }
                            }
                        }
                        else
                        {
                            Cursor = Cursors.No;
                        }
                    }
                }
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int gridRow = Grid.GetRow(button);
                int gridCol = Grid.GetColumn(button);
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (_dragManager.InDrag)
                    {
                        _dragManager.ButtonDragEnter(button);
                    }
                    else
                    {
                        Cursor = Cursors.No;
                    }
                }
                else
                {
                    SetCursorFromSquare(gridRow, gridCol);
                }
            }
        }

        private void SetCursorFromSquare(int row, int col)
        {
            if (Board.GetSquare(row, col).ContainsPiece)
            {
                if (Board.GetSquare(row, col).Piece.Colour == Board.TeamWithTurn)
                {
                    Cursor = Cursors.Hand;
                }
                else
                {
                    Cursor = Cursors.No;
                }
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (_dragManager.InDrag)
                {
                    _dragManager.ButtonDragLeave(button);
                }
            }
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (e.ChangedButton == MouseButton.Left &&
                    e.ButtonState == MouseButtonState.Released &&
                    _dragManager.InDrag)
                {
                    _dragManager.ButtonDrop(button);
                }
                else
                {
                    int gridRow = Grid.GetRow(button);
                    int gridCol = Grid.GetColumn(button);
                    SetCursorFromSquare(gridRow, gridCol);
                }
            }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragManager.LastButtonLeftMousePressedIn = sender as Button;
            e.Handled = true;
        }

        private void UndoButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IBoard newBoard = _positionStateManager.UndoneMoveBoard();
            SetDataContext(newBoard);
        }

        private void RedoButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IBoard newBoard = _positionStateManager.RedoneMoveBoard();
            SetDataContext(newBoard);
        }

        private void SaveButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Castling_Successs_Position_1"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;

                if (!File.Exists(filename))
                {
                    File.Create(filename).Close();
                    string[] lines = GetAlgebraicNotationMovesFromBoardReadyForFile();
                    File.WriteAllLines(filename, lines);
                }
                else
                {
                    MessageBox.Show("File exists, try again with a different name.");
                }
            }
            else
            {
                MessageBox.Show("Failed to save position file");
            }
        }

        private string[] GetAlgebraicNotationMovesFromBoardReadyForFile()
        {
            List<string> moves = new List<string>(Board.OrderedMoveData.Count);
            AlgebraicNotationGenerator generator = new AlgebraicNotationGenerator();
            foreach (var move in Board.OrderedMoveData)
            {
                string moveInNotation = generator.Convert(move);
                moves.Add(moveInNotation);
            }

            bool evenNumberOfMoves = moves.Count % 2 == 0;
            int nearestEven = evenNumberOfMoves ? moves.Count : moves.Count + 1;
            int linesNeeded = nearestEven / 2;
            string[] lines = new string[linesNeeded];
            for (int i = 0; i < linesNeeded - 1; i++)
            {
                string line = string.Concat(moves[i * 2], ",", moves[(i * 2) + 1]);
                lines[i] = line;
            }
            //final line
            string finalLine = evenNumberOfMoves
                ? string.Concat(moves[moves.Count - 2], ",", moves[moves.Count - 1])
                : moves[moves.Count - 1];
            lines[lines.Length - 1] = finalLine;
            return lines;
        }

        #endregion
    }
}