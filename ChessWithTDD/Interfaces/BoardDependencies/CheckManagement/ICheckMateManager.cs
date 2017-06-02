namespace ChessWithTDD
{
    public interface ICheckMateManager
    {
        bool BoardIsInCheckMate(IBoard theBoard, ISquare threateningSquare);
    }
}
