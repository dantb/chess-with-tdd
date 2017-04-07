namespace ChessWithTDD
{
    public interface ICheckManager
    {
        void UpdateCheckAndCheckMateStates(IBoard theBoard, ISquare toSquare);
    }
}
