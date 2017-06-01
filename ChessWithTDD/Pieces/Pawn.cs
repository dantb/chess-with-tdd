using System;

namespace ChessWithTDD
{
    public abstract class Pawn : IPawn
    {
        public abstract Colour Colour { get; }

        public abstract bool HasMoved { get; set; }

        public abstract bool CanMove(ISquare fromSquare, ISquare toSquare);

        protected bool IsValidTwoSpaceInitialMove(ISquare toSquare)
        {
            return !HasMoved && !toSquare.ContainsPiece;
        }

        protected bool SquareContainsPieceOrHasEnPassantMark(ISquare theSquare)
        {
            return theSquare.ContainsPiece || theSquare.HasEnPassantMark;
        }

        protected bool OppositeColouredPieceInSquare(ISquare theSquare)
        {
            if (theSquare.ContainsPiece)
            {
                return Colour == Colour.White 
                    ? theSquare.Piece.Colour == Colour.Black 
                    : theSquare.Piece.Colour == Colour.White;
            }
            return false;
        }
    }
}
