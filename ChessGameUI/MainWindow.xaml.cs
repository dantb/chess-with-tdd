using ChessWithTDD;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessGameUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMoveProvider
    {
        IBoard _theBoard;
        bool _squareIsSelected = false;
        ISquare _selectedSquare;
        Button _selectedButton;
        Brush _selectedSquarePreviousBackground;
        DragManager _dragManager;

        public event MoveProviderEventHandler MoveChosenEvent;

        public MainWindow(IBoard board, Colour playerColour)
        {
            InitializeComponent();
            _theBoard = board;
            _dragManager = new DragManager();
            PlayerColour = playerColour;
            DataContext = _theBoard;
        }

        public static Colour PlayerColour
        {
            get; private set;
        }

        private void MarkSquareDirty(object sender, RoutedEventArgs e)
        {
            //Button theButton = sender as Button;
            //string rowCol = theButton.Tag.ToString();
            //int row = int.Parse(rowCol[0].ToString());
            //int col = int.Parse(rowCol[1].ToString());

            //if (_squareIsSelected)
            //{
            //    IMove move = new Move(_selectedSquare.Row, _selectedSquare.Col, row, col);
            //    MoveChosenEvent?.Invoke(this, new MoveProviderEventArgs(move));
            //    _selectedButton.Background = _selectedSquarePreviousBackground;
            //    _squareIsSelected = false;
            //    _selectedSquare = null;
            //    _selectedSquarePreviousBackground = null;
            //}
            //else if (_theBoard.GetSquare(row, col).ContainsPiece)
            //{
            //    _selectedSquarePreviousBackground = theButton.Background;
            //    Color colour = Colors.CadetBlue;
            //    Brush brush = new SolidColorBrush(colour);
            //    theButton.Background = brush;
            //    _selectedSquare = _theBoard.GetSquare(row, col);
            //    _squareIsSelected = true;
            //    _selectedButton = theButton;
            //}
        }

        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    if (!_dragManager.InDrag && button.Content is Image)
                    {
                        _dragManager.BeginDrag(button, e);
                        Cursor = Cursors.Hand;
                    }
                }
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Debug.Print("Mouse enter before pressed fired");

                if (e.LeftButton == MouseButtonState.Pressed &&
                    _dragManager.InDrag)
                {
                    Debug.Print("Mouse enter fired");
                    _dragManager.ButtonDragEnter(button, e);
                }
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
                    _dragManager.ButtonDragLeave(button, e);
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
                    _dragManager.ButtonDrop(button, e);
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }
    }
}
