namespace ChessWithTDD
{
    public interface IPawnManager
    {
        void MakePawnSpecificAmendments(ISquare fromSquare, ISquare toSquare, IBoard theBoard);

        void UnmarkEnPassantSquares(int turnCounter);
    }
}
