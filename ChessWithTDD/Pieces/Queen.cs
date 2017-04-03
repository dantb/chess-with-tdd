using System;

namespace ChessWithTDD
{
    public class Queen : IPiece
    {
        private Colour _colour;

        public Queen(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour { get { return _colour; } }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            int rowDifference = Math.Abs(fromSquare.Row - toSquare.Row);
            int colDifference = Math.Abs(fromSquare.Col - toSquare.Col);
            if (rowDifference == colDifference)
            {
                //diagonal
                return true;
            }
            else if (fromSquare.Row == toSquare.Row
                || fromSquare.Col == toSquare.Col)
            {
                //vertical or horizontal
                return true;
            }
            return false;
        }
    }
}