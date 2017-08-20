using Autofac;
using ChessWithTDD;
using System;
using System.Collections.Generic;

namespace ChessEngine
{
    /// <summary>
    /// Holds common logic that is used by several strategies, such as getting the valid moves for a given board.
    /// </summary>
    public abstract class StrategyBase : IMovementStrategy
    {
        public abstract MoveData CalculateOptimalMove(IBoard board);

        protected List<MoveData> GetValidMovesFromBoard(IBoard board)
        {
            List<MoveData> validMoves = new List<MoveData>();

            foreach (ISquare ourTeamSquare in board.MovingTeamPieceSquares)
            {
                foreach (var row in board.Squares)
                {
                    foreach (ISquare square in row)
                    {
                        if (board.MoveIsValid(ourTeamSquare, square))
                        {
                            validMoves.Add(new MoveData(ourTeamSquare, square));
                        }
                    }
                }
            }

            return validMoves;
        }

        protected IBoard GetNewBoardWithThisMoveApplied(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            IBoard newBoard;
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                newBoard = scope.Resolve<IBoard>();
            }
            foreach (MoveGenerationData data in theBoard.OrderedMoveData)
            {
                ISquare fs = newBoard.GetSquare(data.Move.FromRow, data.Move.FromCol);
                ISquare ts = newBoard.GetSquare(data.Move.ToRow, data.Move.ToCol);
                newBoard.Apply(fs, ts);
            }
            ISquare newBoardFromSquare = newBoard.GetSquare(fromSquare.Row, fromSquare.Col);
            ISquare newBoardToSquare = newBoard.GetSquare(toSquare.Row, toSquare.Col);
            newBoard.Apply(newBoardFromSquare, newBoardToSquare);
            return newBoard;
        }

        /// <summary>
        /// Evaluate the "value" of the board for the team currently moving. High positive value indicates a better
        /// position and a high negative value indicates a worse position for the moving team.
        /// </summary>
        protected double EvaluateBoard(IBoard board, Dictionary<Type, double> piecePointEvaluations)
        {
            double result = 0;

            foreach (ISquare movingTeamPieceSquare in board.MovingTeamPieceSquares)
            {
                result += piecePointEvaluations[movingTeamPieceSquare.Piece.GetType()];
            }

            foreach (ISquare otherTeamPieceSquare in board.OtherTeamPieceSquares)
            {
                result -= piecePointEvaluations[otherTeamPieceSquare.Piece.GetType()];
            }

            return result;
        }

        protected static Dictionary<Type, double> PieceTypeToPoints = new Dictionary<Type, double>()
        {
            { typeof(WhitePawn), 10 },
            { typeof(BlackPawn), 10 },
            { typeof(Knight), 30 },
            { typeof(Bishop), 30 },
            { typeof(Rook), 50 },
            { typeof(Queen), 90 },
            { typeof(King), 900 }
        };
    }
}
