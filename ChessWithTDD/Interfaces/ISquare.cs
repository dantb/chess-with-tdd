namespace ChessWithTDD
{
    public interface ISquare
    {
        IPiece Piece
        {
            get; set;
        }
        bool ContainsPiece
        {
            get; set;
        }
        int Row
        {
            get;
        }
        int Col
        {
            get;
        }
    }
}
