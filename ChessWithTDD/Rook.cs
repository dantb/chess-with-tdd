using System;

namespace ChessWithTDD
{
    public class Rook : Piece
    {
        private Colour _colour;

        public Rook(Colour colour)
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

        public override bool CanMove(IMove theMove)
        {
            throw new NotImplementedException();
        }
    }
}