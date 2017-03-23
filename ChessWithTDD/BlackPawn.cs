using System;

namespace ChessWithTDD
{
    /// <summary>
    /// A black pawn. The black team are at the top of the board in this model, occupying rows 6 and 7 intially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    internal class BlackPawn : Piece, IPawn
    {
        public override Colour Colour
        {
            get
            {
                return Colour.Black;
            }
        }

        public bool HasMoved { get; set; }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place down the board
            if (toSquare.Row == fromSquare.Row - 1
                    && toSquare.Col == fromSquare.Col)
            {
                return base.CanMove(fromSquare, toSquare) && !WhitePieceInSquare(toSquare);
            }

            //Moving diagonally downwards
            if (toSquare.Row == fromSquare.Row - 1
                    && ((toSquare.Col == fromSquare.Col - 1)
                    || toSquare.Col == fromSquare.Col + 1))
            {
                return toSquare.ContainsPiece && base.CanMove(fromSquare, toSquare);
            }

            return false;
        }

        private bool WhitePieceInSquare(ISquare theSquare)
        {
            if (theSquare.ContainsPiece)
            {
                return theSquare.Piece.Colour == Colour.White;
            }
            return false;
        }
    }
}
