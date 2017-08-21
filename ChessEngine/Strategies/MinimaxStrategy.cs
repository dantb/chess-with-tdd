using System;
using ChessWithTDD;

namespace ChessEngine
{
    public class MinimaxStrategy : StrategyBase
    {
        public override MoveData CalculateOptimalMove(IBoard board)
        {
            var moves = GetValidMovesFromBoard(board);
            MoveValue bestValue = new MoveValue(null, -9999);

            foreach (var move in moves)
            {
                IBoard newBoard = GetNewBoardWithThisMoveApplied(board, move.FromSquare, move.ToSquare);
                // calculate minimax for branch, starting with minimising player
                double minimaxForBranch = Minimax(1, newBoard, false);
                if (minimaxForBranch > bestValue.Value)
                {
                    bestValue = new MoveValue(move, minimaxForBranch);
                }
            }

            return bestValue.MoveData;
        }

        private double Minimax(int depthToGo, IBoard board, bool isMaximisingPlayer)
        {
            if (depthToGo == 0)
            {
                // gone as deep as we want to go, return the best value from this branch
                return isMaximisingPlayer 
                    ? EvaluateBoard(board, PieceTypeToPoints)  
                    : -EvaluateBoard(board, PieceTypeToPoints);
            }

            var moves = GetValidMovesFromBoard(board);

            if (isMaximisingPlayer)
            {
                // maximise the value we can extract from a board state
                double bestValue = -9999;

                foreach (var move in moves)
                {
                    IBoard newBoard = GetNewBoardWithThisMoveApplied(board, move.FromSquare, move.ToSquare);
                    double branchBestValue = Minimax(depthToGo - 1, newBoard, !isMaximisingPlayer);
                    bestValue = Math.Max(branchBestValue, bestValue);
                }

                return bestValue;
            }
            else
            {
                // minimise the value we can extract from a board state -  it's the turn of the other player
                double bestValue = 9999;

                foreach (var move in moves)
                {
                    IBoard newBoard = GetNewBoardWithThisMoveApplied(board, move.FromSquare, move.ToSquare);
                    double branchBestValue = Minimax(depthToGo - 1, newBoard, !isMaximisingPlayer);
                    bestValue = Math.Min(branchBestValue, bestValue);
                }

                return bestValue;
            }
        }
    }
}
