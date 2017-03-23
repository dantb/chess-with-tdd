namespace ChessWithTDD
{
    /// <summary>
    /// A white pawn. The white team are at the bottom of the board in this model, occupying rows 0 and 1 initially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    internal class WhitePawn : Piece, IPawn
    {
        public override Colour Colour
        {
            get
            {
                return Colour.White;
            }
        }

        public bool HasMoved { get; set; }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place up the board
            if (toSquare.Row == fromSquare.Row + 1
                    && toSquare.Col == fromSquare.Col)
            {
                return base.CanMove(fromSquare, toSquare) && !BlackPieceInSquare(toSquare);
            }

            //Moving diagonally upwards
            if (toSquare.Row == fromSquare.Row + 1
                    && ((toSquare.Col == fromSquare.Col - 1)
                    || toSquare.Col == fromSquare.Col + 1))
            {
                return toSquare.ContainsPiece && base.CanMove(fromSquare, toSquare);
            }

            //Moving two spaces up the board
            if (toSquare.Row == fromSquare.Row + 2
                && toSquare.Col == fromSquare.Col)
            {
                if (!HasMoved && !toSquare.ContainsPiece)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        private bool BlackPieceInSquare(ISquare theSquare)
        {
            if (theSquare.ContainsPiece)
            {
                return theSquare.Piece.Colour == Colour.Black;
            }
            return false;
        }
    }
}
