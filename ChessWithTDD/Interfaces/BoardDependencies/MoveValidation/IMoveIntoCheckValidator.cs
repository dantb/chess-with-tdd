namespace ChessWithTDD
{
    public interface IMoveIntoCheckValidator
    {
        bool MoveIsIntoCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare);
    }
}
