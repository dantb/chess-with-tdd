namespace ChessWithTDD
{
    public interface IMoveExecutor
    {
        void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare);
    }
}
