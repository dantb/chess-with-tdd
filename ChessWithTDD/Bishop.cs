using System;

namespace ChessWithTDD
{
    internal class Bishop : Piece
    {
        private Colour _colour;

        public Bishop(Colour colour)
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