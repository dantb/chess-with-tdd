using System;

namespace ChessWithTDD
{
    internal class Knight : Piece
    {
        private Colour _colour;

        public Knight(Colour colour)
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
            if (MoveIsLShaped(fromSquare, toSquare))
            {
                return base.CanMove(fromSquare, toSquare);
            }
            return false;
        }

        private bool MoveIsLShaped(ISquare fromSquare, ISquare toSquare)
        {
            return (Math.Abs(fromSquare.Row - toSquare.Row) == 2 && Math.Abs(fromSquare.Col - toSquare.Col) == 1)
                || (Math.Abs(fromSquare.Row - toSquare.Row) == 1 && Math.Abs(fromSquare.Col - toSquare.Col) == 2);
        }
    }
}