using System.Windows.Controls;

namespace ChessGameUI
{
    public class DragOperation
    {
        public DragOperation(Button dragSource)
        {
            Source = new DragButtonSource(dragSource);
        }

        /// <summary>
        /// Square that is the source of the drag, cannot be changed during one drag operation.
        /// </summary>
        public DragButtonSource Source { get; }

        /// <summary>
        /// Target square for the drag, can be changed in one drag operation.
        /// </summary>
        public DragButtonTarget Target { get; set; }
    }
}
