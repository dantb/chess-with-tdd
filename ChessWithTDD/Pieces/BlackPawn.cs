namespace ChessWithTDD
{
    /// <summary>
    /// A black pawn. The black team are at the top of the board in this model, occupying rows 6 and 7 intially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    public class BlackPawn : Pawn
    {
        public override Colour Colour { get { return Colour.Black; } }

        public override bool HasMoved { get; set; }

        public override bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            //Normal move, one place down the board
            if (toSquare.Row == fromSquare.Row - 1
                    && toSquare.Col == fromSquare.Col)
            {
                return !OppositeColouredPieceInSquare(toSquare);
            }

            //Moving diagonally downwards
            if (toSquare.IsOneSquareDiagonallyBelow(fromSquare))
            {
                return SquareContainsPieceOrHasEnPassantMark(toSquare);
            }

            //Moving two spaces up the board
            if (toSquare.Row == fromSquare.Row - 2
                && toSquare.Col == fromSquare.Col)
            {
                return IsValidTwoSpaceInitialMove(toSquare);
            }

            return false;
        }
    }
}
