using System.Windows.Controls;
using System.Windows.Data;

namespace ChessGameUI
{
    public class DragButtonTarget
    {
        public DragButtonTarget(Button button)
        {
            Button = button;
            OriginalBinding = BindingOperations.GetBinding(button.Content as Image, Image.SourceProperty);
        }

        public Button Button { get; }

        public Image ButtonImage 
        {
            get 
            {
                return (Image) Button.Content;
            }
            set 
            {
                Button.Content = value;
            }
        }

        /// <summary>
        /// Retain the original binding of the target square's contents with the board. It will be temporarily disabled
        /// when the drag operation is in progress in order to show potential move
        /// </summary>
        public Binding OriginalBinding { get; }
    }
}
