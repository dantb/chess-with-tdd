namespace ChessWithTDD
{
    public interface ICastlingExecutor
    {
        void ExecuteCastlingMove(ISquare fromSquare, ISquare toSquare, IBoard board);
    }
}
