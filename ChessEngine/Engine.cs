using ChessWithTDD;

namespace ChessEngine
{
    public class Engine
    {
        private IMovementStrategy _movementStrategy;

        public Engine (IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public Move CalculateBestMove(IBoard board)
        {
            MoveData bestMove = _movementStrategy.CalculateOptimalMove(board);

            // we have no move, something went horribly wrong
            if (bestMove == null)
            {
                throw new MoveNotFoundException("No move could be found for the board provided.");
            }

            return new Move(bestMove.FromSquare.Row, bestMove.FromSquare.Col, bestMove.ToSquare.Row, bestMove.ToSquare.Col);
        }
    }
}