namespace ChessWithTDD
{
    public interface IMoveExecuter
    {
        void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare);
    }
}
