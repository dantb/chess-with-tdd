using ChessWithTDD;
using System;
using System.Threading;

namespace ChessEngine
{
    public class Engine : IMoveProvider
    {
        public event MoveProviderEventHandler MoveChosenEvent;

        public Move CalculateBestMove(IBoard board)
        {
            foreach (ISquare ourTeamSquare  in board.MovingTeamPieceSquares)
            {
                foreach (var row in board.Squares)
                {
                    foreach (ISquare square in row)
                    {
                        if (board.MoveIsValid(ourTeamSquare, square))
                        {
                            Thread.Sleep(5000);
                            return new Move(ourTeamSquare.Row, ourTeamSquare.Col, square.Row, square.Col);
                        }
                    }
                }
            }
            return new Move(0, 0, 0, 0);
            throw new NotImplementedException();
        }
    }
}
