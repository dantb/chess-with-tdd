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