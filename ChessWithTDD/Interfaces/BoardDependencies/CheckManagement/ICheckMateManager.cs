namespace ChessWithTDD
{
    public interface ICheckMateManager
    {
        bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache, ISquare threateningSquare);
    }
}
