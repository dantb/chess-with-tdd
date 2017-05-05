using ChessWithTDD;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ChessGameUI
{
    /// <summary>
    /// Handles drag operations for buttons on the board.
    /// </summary>
    public class DragManager
    {
        private IBoard _theBoard;
        private DragOperation _dragOperation;
        private BoardFrontEnd _window;

        public DragManager(IBoard theBoard, BoardFrontEnd window)
        {
            _theBoard = theBoard;
            _window = window;
        }

        public bool InDrag { get; set; } = false;

        public Button LastButtonLeftMousePressedIn { get; set; }

        internal void BeginDrag(Button button)
        {
            _dragOperation = new DragOperation(button);
            _window.Cursor = Cursors.Hand;
            InDrag = true;
        }

        /// <summary>
        /// When we drop:<para/>
        /// 1) If the button is the valid target, apply the move and notify controller.<para/>
        /// 2) Otherwise, cancel the drag operaion.<para/>
        /// In both cases set the cursor back to default and update InDrag flag.
        /// </summary>
        internal void ButtonDrop(Button button)
        {
            if (button == _dragOperation.Target?.Button)
            {
                if (button.Content is Image)
                {
                    ApplyMove(button);
                }
            }
            else
            {
                CancelDragOperation();
            }
            _window.Cursor = Cursors.Arrow;
            InDrag = false;
            _dragOperation = null;
        }

        /// <summary>
        /// When we leave a button:<para/>
        /// 1) If the button is the target, reset the binding of that button and remove as target.<para/>
        /// 2) If the button is the source, make source opacity small to indicate we're dragging this piece.<para/>
        /// 3) Otherwise, do nothing since drag enter will handle other squares.
        /// </summary>
        internal void ButtonDragLeave(Button button)
        {
            if (button == _dragOperation.Target?.Button)
            {
                //set target piece back to what it was before
                ResetTargetBinding();
                _dragOperation.Target = null;
            }
            else if (button == _dragOperation.Source.Button)
            {
                //source becomes less opaque
                _dragOperation.Source.ButtonImage.Opacity = 0.5;
            }
        }

        /// <summary>
        /// When we enter a button:<para/>
        /// 1) If the button isn't the source, check for a valid move to that target.<para/>
        ///     - If valid, set the target to the button.<para/>
        ///     - Otherwise, display "No" cursor.<para/>
        /// 2) If the button is the source, reset source opacity.
        /// </summary>
        internal void ButtonDragEnter(Button button)
        {
            if (button != _dragOperation.Source.Button)
            {
                int gridRow = Grid.GetRow(button);
                int gridCol = Grid.GetColumn(button);
                ISquare toSquare = _theBoard.GetSquare(gridRow, gridCol);
                ISquare fromSquare = _theBoard.GetSquare(
                    Grid.GetRow(_dragOperation.Source.Button),
                    Grid.GetColumn(_dragOperation.Source.Button));
                if (_theBoard.MoveIsValid(fromSquare, toSquare))
                {
                    SetNewTarget(button);
                }
                else
                {
                    _window.Cursor = Cursors.No;
                }
            }
            else
            {
                _dragOperation.Source.ButtonImage.Opacity = 1;
            }
        }

        private void CancelDragOperation()
        {
            //give target its binding back and source it's colour back
            _dragOperation.Source.ButtonImage.Opacity = 1;
            if (_dragOperation.Target != null)
            {
                ResetTargetBinding();
            }
        }

        private void ApplyMove(Button button)
        {
            Move theMove = GetMoveWithTarget(button);
            //give target back it's original binding, will be updated when the underlying board updates
            ResetTargetBinding();
            _window.RaiseMoveChosenEvent(new MoveProviderEventArgs(theMove));
        }

        private Move GetMoveWithTarget(Button target)
        {
            int toRow = Grid.GetRow(target);
            int toCol = Grid.GetColumn(target);
            int fromRow = Grid.GetRow(_dragOperation.Source.Button);
            int fromCol = Grid.GetColumn(_dragOperation.Source.Button);
            Move theMove = new Move(fromRow, fromCol, toRow, toCol);
            return theMove;
        }

        private void ResetTargetBinding()
        {
            BindingOperations.SetBinding(_dragOperation.Target.ButtonImage, Image.SourceProperty, _dragOperation.Target.OriginalBinding);
        }

        private void SetNewTarget(Button target)
        {
            DragButtonTarget theTargetButton = new DragButtonTarget(target);
            Image sourceImageClone = new Image
            {
                Source = _dragOperation.Source.ButtonImage.Source.Clone(),
                Opacity = 1
            };

            theTargetButton.ButtonImage = sourceImageClone;
            //set new target
            _dragOperation.Target = theTargetButton;
            _window.Cursor = Cursors.Hand;
        }
    }
}
