using System;

namespace ChessWithTDD
{
    public abstract class Pawn : IPawn
    {
        public Colour Colour { get; }

        public bool HasMoved { get; set; }

        public bool CanMove(ISquare fromSquare, ISquare toSquare, bool movingUp)
        {
            return false;
        }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }
    }
}
