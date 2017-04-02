namespace ChessWithTDD
{
    public interface IMoveValidator
    {
        bool MoveIsValid(ISquare fromSquare, ISquare toSquare, IBoard theBoard);
    }
}
