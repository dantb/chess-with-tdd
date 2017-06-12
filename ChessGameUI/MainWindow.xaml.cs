using ChessWithTDD;
using System.Diagnostics;
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

        public BoardFrontEnd(IBoard board, Colour playerColour)
        {
            InitializeComponent();
            TheBoard = board;
            _dragManager = new DragManager(TheBoard, this);
            ColourOfTeamWithTurn = Colour.White;
            DataContext = TheBoard;
        }

        public Colour ColourOfTeamWithTurn
        {
            get; set;
        }

        public IBoard TheBoard { get; }

        public event MoveProviderEventHandler MoveChosenEvent;

        internal void RaiseMoveChosenEvent(MoveProviderEventArgs e)
        {
            MoveChosenEvent?.Invoke(this, e);
        }

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
                        if (TheBoard.GetSquare(gridRow, gridCol).ContainsPiece)
                        {
                            if (TheBoard.GetSquare(gridRow, gridCol).Piece.Colour == ColourOfTeamWithTurn)
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
            if (TheBoard.GetSquare(row, col).ContainsPiece)
            {
                if (TheBoard.GetSquare(row, col).Piece.Colour == ColourOfTeamWithTurn)
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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser(TheBoard);
            string input = MoveNotationInputTextbox.Text;

            IMove theMove = parser.Parse(input);
            ISquare fromSquare = TheBoard.GetSquare(theMove.FromRow, theMove.FromCol);
            ISquare toSquare = TheBoard.GetSquare(theMove.ToRow, theMove.ToCol);
            if (TheBoard.MoveIsValid(fromSquare, toSquare))
            {
                TheBoard.Apply(fromSquare, toSquare);
                ColourOfTeamWithTurn = ColourOfTeamWithTurn == Colour.White ?
                    Colour.Black : Colour.White;
            }
        }
    }
}
