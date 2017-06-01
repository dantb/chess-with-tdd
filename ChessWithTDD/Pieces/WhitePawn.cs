namespace ChessWithTDD
{
    /// <summary>
    /// A white pawn. The white team are at the bottom of the board in this model, occupying rows 0 and 1 initially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    public class WhitePawn : Pawn
    {
        public override Colour Colour { get { return Colour.White; } }

        public override bool HasMoved { get; set; }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place up the board
            if (toSquare.Row == fromSquare.Row + 1
                    && toSquare.Col == fromSquare.Col)
            {
                return !OppositeColouredPieceInSquare(toSquare);
            }

            //Moving diagonally upwards
            if (toSquare.IsOneSquareDiagonallyAbove(fromSquare))
            {
                return SquareContainsPieceOrHasEnPassantMark(toSquare);
            }

            //Moving two spaces up the board
            if (toSquare.Row == fromSquare.Row + 2
                && toSquare.Col == fromSquare.Col)
            {
                return IsValidTwoSpaceInitialMove(toSquare);
            }

            return false;
        }
    }
}
