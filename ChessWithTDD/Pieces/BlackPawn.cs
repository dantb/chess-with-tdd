namespace ChessWithTDD
{
    /// <summary>
    /// A black pawn. The black team are at the top of the board in this model, occupying rows 6 and 7 intially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    internal class BlackPawn : IPawn
    {
        public Colour Colour
        {
            get
            {
                return Colour.Black;
            }
        }

        public bool HasMoved { get; set; }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place down the board
            if (toSquare.Row == fromSquare.Row - 1
                    && toSquare.Col == fromSquare.Col)
            {
                return !WhitePieceInSquare(toSquare);
            }

            //Moving diagonally downwards
            if (MoveIsDiagonallyDownwards(fromSquare, toSquare))
            {
                return toSquare.ContainsPiece || toSquare.HasEnPassantMark;
            }

            //Moving two spaces up the board
            if (toSquare.Row == fromSquare.Row - 2
                && toSquare.Col == fromSquare.Col)
            {
                if (HasMoved || toSquare.ContainsPiece)
                {
                    return false;
                }
                return true;
            }

            return false;
        }

        internal static bool MoveIsDiagonallyDownwards(ISquare fromSquare, ISquare toSquare)
        {
            return toSquare.Row == fromSquare.Row - 1
                    && ((toSquare.Col == fromSquare.Col - 1) || (toSquare.Col == fromSquare.Col + 1));
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
