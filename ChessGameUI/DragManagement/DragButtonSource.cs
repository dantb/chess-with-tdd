using System.Windows.Controls;

namespace ChessGameUI
{
    public class DragButtonSource
    {
        public DragButtonSource(Button button)
        {
            Button = button;
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
    }
}
