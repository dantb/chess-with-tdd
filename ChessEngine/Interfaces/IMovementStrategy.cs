using ChessWithTDD;

namespace ChessEngine
{
    public interface IMovementStrategy
    {
        MoveData CalculateOptimalMove(IBoard board);
    }
}
