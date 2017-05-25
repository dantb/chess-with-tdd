namespace ChessWithTDD
{
    /// <summary>
    /// A white pawn. The white team are at the bottom of the board in this model, occupying rows 0 and 1 initially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    public class WhitePawn : Pawn
    {
        public new Colour Colour { get { return Colour.White; } }

        public new bool HasMoved { get; set; }

        public new bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place up the board
            if (toSquare.Row == fromSquare.Row + 1
                    && toSquare.Col == fromSquare.Col)
            {
                return !BlackPieceInSquare(toSquare);
            }

            //Moving diagonally upwards
            if (toSquare.IsOneSquareDiagonallyAbove(fromSquare))
            {
                return toSquare.ContainsPiece || toSquare.HasEnPassantMark;
            }

            //Moving two spaces up the board
            if (toSquare.Row == fromSquare.Row + 2
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
