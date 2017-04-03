namespace ChessWithTDD
{
    public interface IEnPassantManager
    {
        void MarkSquareWithEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare, IBoard theBoard);
        void CapturePieceThroughEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare, IBoard theBoard);
        void UnmarkEnPassantSquares(int turnCounter);
    }
}
