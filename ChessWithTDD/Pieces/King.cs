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
            if (toSquare.IsAdjacentTo(fromSquare))
            {
                return true;
            }
            return false;
        }
    }
}