namespace ChessWithTDD
{
    public interface IFakeMoveExecutor
    {
        void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare);
        void ResetBoard(IBoard board);
    }
}
