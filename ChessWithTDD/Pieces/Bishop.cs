using System;

namespace ChessWithTDD
{
    public class Bishop : IPiece
    {
        private Colour _colour;

        public Bishop(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour
        {
            get
            {
                return _colour;
            }
        }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            int rowDifference = Math.Abs(fromSquare.Row - toSquare.Row);
            int colDifference = Math.Abs(fromSquare.Col - toSquare.Col);
            if (rowDifference == colDifference)
            {
                return true;
            }
            return false;
        }
    }
}