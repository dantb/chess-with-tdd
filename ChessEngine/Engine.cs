using System;
using System.Collections.Generic;
using ChessWithTDD;
using Autofac;

namespace ChessEngine
{
    public class Engine : IMoveProvider
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

        public event MoveProviderEventHandler MoveChosenEvent;

        public Move CalculateBestMove(IBoard board)
        {
            List<SquaresForMoves> validMoves = new List<SquaresForMoves>();

            foreach (ISquare ourTeamSquare in board.MovingTeamPieceSquares)
            {
                foreach (var row in board.Squares)
                {
                    foreach (ISquare square in row)
                    {
                        if (board.MoveIsValid(ourTeamSquare, square))
                        {
                            validMoves.Add(new SquaresForMoves(ourTeamSquare, square));
                        }
                    }
                }
            }

            double bestMovePoints = -9999999;
            SquaresForMoves bestMove = null;

            foreach (SquaresForMoves validMove in validMoves)
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

            return new Move(bestMove.FromSquare.Row, bestMove.FromSquare.Col, bestMove.ToSquare.Row, bestMove.ToSquare.Col);
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

        public class SquaresForMoves
        {
            public ISquare FromSquare { get; }
            public ISquare ToSquare { get; }
            public SquaresForMoves(ISquare fromSquare, ISquare toSquare)
            {
                FromSquare = fromSquare;
                ToSquare = toSquare;
            }
        }
    }
}