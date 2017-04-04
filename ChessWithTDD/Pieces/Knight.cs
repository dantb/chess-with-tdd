using System;

namespace ChessWithTDD
{
    public class Knight : IKnight
    {
        private Colour _colour;

        public Knight(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour { get { return _colour; } }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.IsAnLShapeAwayFrom(fromSquare))
            {
                return true;
            }
            return false;
        }
    }
}