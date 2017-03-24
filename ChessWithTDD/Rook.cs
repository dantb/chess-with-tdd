using System;

namespace ChessWithTDD
{
    public class Rook : IPiece
    {
        private Colour _colour;

        public Rook(Colour colour)
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