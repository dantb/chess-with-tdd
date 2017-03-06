using System;

namespace ChessWithTDD
{
    internal class King : Piece
    {
        private Colour _colour;

        public King(Colour colour)
        {
            _colour = colour;
        }

        public override Colour Colour
        {
            get
            {
                return _colour;
            }
        }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }
    }
}