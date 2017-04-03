using System;

namespace ChessWithTDD
{
    public class King : IKing
    {
        private Colour _colour;

        public King(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour { get { return _colour; } }

        public bool InCheckState { get; set; } = false;

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {            
            if (MoveIsToAdjacentSquare(fromSquare, toSquare))
            {
                return true;
            }
            return false;
        }

        internal static bool MoveIsToAdjacentSquare(ISquare fromSquare, ISquare toSquare)
        {
            int rowDifference = Math.Abs(fromSquare.Row - toSquare.Row);
            int colDifference = Math.Abs(fromSquare.Col - toSquare.Col);
            return rowDifference <= 1 && colDifference <= 1;
        }
    }
}