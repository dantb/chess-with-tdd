using System;

namespace ChessWithTDD
{
    public class King : IPiece
    {
        private Colour _colour;

        public King(Colour colour)
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
            throw new NotImplementedException();
        }
    }
}