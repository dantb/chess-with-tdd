using System.ComponentModel;

namespace ChessWithTDD
{
    public interface ISquare : INotifyPropertyChanged
    {
        IPiece Piece { get; set; }

        bool HasEnPassantMark { get; set; }

        bool ContainsPiece { get; set; }

        int Row { get; }

        int Col { get; }
    }
}
