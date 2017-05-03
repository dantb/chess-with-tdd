using ChessWithTDD;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace ChessGameUI
{
    public class DragManager
    {
        private IBoard _theBoard;
        private DragOperation _dragOperation;
        private MainWindow _window;

        public DragManager(IBoard theBoard, MainWindow window)
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

        internal void ButtonDrop(Button button)
        {
            if (button == _dragOperation.Target?.Button)
            {
                if (button.Content is Image)
                {
                    Debug.Print("Button Drop image to drag target");
                    int toRow = Grid.GetRow(button);
                    int toCol = Grid.GetColumn(button);
                    int fromRow = Grid.GetRow(_dragOperation.Source.Button);
                    int fromCol = Grid.GetColumn(_dragOperation.Source.Button);
                    Move theMove = new Move(fromRow, fromCol, toRow, toCol);
                    BindingOperations.SetBinding(_dragOperation.Target.ButtonImage, Image.SourceProperty, _dragOperation.Target.OriginalBinding);
                    _window.RaiseMoveChosenEvent(new MoveProviderEventArgs(theMove));
                }
            }
            else
            {
                Debug.Print("Button drop anywhere else");
                _dragOperation.Source.ButtonImage.Opacity = 1;
                if (_dragOperation.Target != null)
                {
                    BindingOperations.SetBinding(_dragOperation.Target.ButtonImage, Image.SourceProperty, _dragOperation.Target.OriginalBinding);
                }
            }
            _window.Cursor = Cursors.Arrow;
            InDrag = false;
            _dragOperation = null;
        }

        internal void ButtonDragLeave(Button button)
        {
            if (button == _dragOperation.Target?.Button)
            {
                Debug.Print("Button Mouse leave drag target");
                //set target piece back to what it was before
                BindingOperations.SetBinding(_dragOperation.Target.ButtonImage, Image.SourceProperty, _dragOperation.Target.OriginalBinding);
                _dragOperation.Target = null;
            }
            else if (button == _dragOperation.Source.Button)
            {
                Debug.Print("Button Mouse leave drag target");
                //set target piece back to what it was before
                _dragOperation.Source.ButtonImage.Opacity = 0.5;
            }
        }

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
                    Debug.Print("Button Mouse enter not drag source");
                    DragButtonTarget theTargetButton = new DragButtonTarget(button);
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
    }
}
