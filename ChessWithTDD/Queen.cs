using System;

namespace ChessWithTDD
{
    internal class Queen : Piece
    {
        private Colour _colour;

        public Queen(Colour colour)
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