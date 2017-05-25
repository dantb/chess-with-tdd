using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChessWithTDD
{
    public class Square : ISquare
    {
        private IPiece _thePiece;

        public Square(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool HasEnPassantMark { get; set; }

        public bool ContainsPiece { get; set; }

        public IPiece Piece
        {
            get
            {
                return _thePiece;
            }
            set
            {
                _thePiece = value;
                OnPropertyChanged();
            }
        }

        public int Col { get; }

        public int Row { get; }

        public void AddPiece(IPiece piece)
        {
            ContainsPiece = true;
            Piece = piece;
        }

        private void OnPropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(caller));
        }
    }
}
