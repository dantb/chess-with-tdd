namespace ChessWithTDD
{
    public interface ICheckManager
    {
        void UpdateCheckStates(IBoard theBoard, ISquare toSquare);
        bool BoardIsInCheckMate(IBoard theBoard);
    }
}
