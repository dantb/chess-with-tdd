using Autofac;
using ChessWithTDD;
using System;
using System.Collections.Generic;

namespace ChessEngine
{
    public partial class Engine
    {
        private static Dictionary<Type, double> PieceTypeToPoints = new Dictionary<Type, double>()
        {
            { typeof(WhitePawn), 10 },
            { typeof(BlackPawn), 10 },
            { typeof(Knight), 30 },
            { typeof(Bishop), 30 },
            { typeof(Rook), 50 },
            { typeof(Queen), 90 },
            { typeof(King), 900 }
        };

        public Move CalculateBestMove(IBoard board)
        {
            List<MoveData> validMoves = GetValidMovesFromBoard(board);

            MoveData bestMove = CalculateMoveWithHighestPoints(board, validMoves);

            return new Move(bestMove.FromSquare.Row, bestMove.FromSquare.Col, bestMove.ToSquare.Row, bestMove.ToSquare.Col);
        }

        private MoveData CalculateMoveWithHighestPoints(IBoard board, List<MoveData> validMoves)
        {
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

            // we have no move, something went horribly wrong
            if (bestMove == null)
            {
                throw new MoveNotFoundException("No move could be found for the board provided.");
            }

            return bestMove;
        }

        private static List<MoveData> GetValidMovesFromBoard(IBoard board)
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

        /// <summary>
        /// Evaluate the "value" of the board for the team currently moving. High positive value indicates a better
        /// position and a high negative value indicates a worse position for the moving team.
        /// </summary>
        private double EvaluateBoard(IBoard board, Dictionary<Type, double> piecePointEvaluations)
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

        private IBoard GetNewBoardWithThisMoveApplied(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
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
    }
}