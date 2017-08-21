using ChessWithTDD;
using System.Collections.Generic;

namespace ChessEngine
{
    /// <summary>
    /// Basic moving strategy that simply prioritises a capture over a normal move.
    /// </summary>
    public class BasicCaptureStrategy : StrategyBase
    {
        public override MoveData CalculateOptimalMove(IBoard board)
        {
            List<MoveData> validMoves = GetValidMovesFromBoard(board);

            double bestMovePoints = -9999999;
            MoveData bestMove = null;

            foreach (MoveData validMove in validMoves)
            {
                IBoard newBoard = GetNewBoardWithThisMoveApplied(board, validMove.FromSquare, validMove.ToSquare);

                // make this negative since the team whose turn it is is now the other team
                double boardValue = -1 * EvaluateBoard(newBoard, PieceTypeToPoints);
                if (bestMovePoints < boardValue)
                {
                    bestMovePoints = boardValue;
                    bestMove = validMove;
                }
            }

            return bestMove;
        }
    }
}
