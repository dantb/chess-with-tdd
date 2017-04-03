namespace ChessWithTDD
{
    public interface IMultiSquareMoveValidator
    {
        bool MultiSquareMoveIsBlockedByAnObstacle(ISquare fromSquare, ISquare toSquare, IBoard theBoard);
    }
}
