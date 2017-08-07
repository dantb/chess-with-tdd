using ChessWithTDD;
using System;

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
                            return new Move(ourTeamSquare.Row, ourTeamSquare.Col, square.Row, square.Col);
                        }
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
