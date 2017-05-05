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
        IBoard _theBoard;
        DragManager _dragManager;

        public event MoveProviderEventHandler MoveChosenEvent;

        internal void RaiseMoveChosenEvent(MoveProviderEventArgs e)
        {
            MoveChosenEvent?.Invoke(this, e);
        }

        public BoardFrontEnd(IBoard board, Colour playerColour)
        {
            InitializeComponent();
            _theBoard = board;
            _dragManager = new DragManager(_theBoard, this);
            ColourOfTeamWithTurn = Colour.White;
            DataContext = _theBoard;
        }

        public Colour ColourOfTeamWithTurn
        {
            get; set;
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
                        if (_theBoard.GetSquare(gridRow, gridCol).ContainsPiece)
                        {
                            if (_theBoard.GetSquare(gridRow, gridCol).Piece.Colour == ColourOfTeamWithTurn)
                            {
                                if (!_dragManager.InDrag &&
                                    button.Content is Image &&
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
            if (_theBoard.GetSquare(row, col).ContainsPiece)
            {
                if (_theBoard.GetSquare(row, col).Piece.Colour == ColourOfTeamWithTurn)
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
                    Debug.Print("Mouse leave fired");
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
                    Debug.Print("Mouse up fired");
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
    }
}
