using ChessWithTDD;
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
            Board = board;
            _dragManager = new DragManager(Board, this);
            _positionStateManager = new PositionStateManager();
            SetDataContext(Board);
        }

        public IBoard Board
        {
            get { return _board; }
            private set
            {
                _board = value;
                _board.MoveAppliedEvent += _board_MoveAppliedEvent;
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

        #endregion
    }
}