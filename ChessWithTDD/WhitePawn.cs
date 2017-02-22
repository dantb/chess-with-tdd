namespace ChessWithTDD
{
    /// <summary>
    /// A white pawn. The white team are at the bottom of the board in this model, occupying rows 0 and 1 initially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    internal class WhitePawn : Piece
    {
        public override Colour Colour
        {
            get
            {
                return Colour.White;
            }
        }

        public override bool CanMove(IMove theMove)
        {
            //Normal move, one place up the board
            if (theMove.ToSquare.Row == theMove.FromSquare.Row + 1
                    && theMove.ToSquare.Col == theMove.FromSquare.Col)
            {
                return base.CanMove(theMove) && !BlackPieceInSquare(theMove.ToSquare);
            }

            //Moving diagonally upwards
            if (theMove.ToSquare.Row == theMove.FromSquare.Row + 1
                    && ((theMove.ToSquare.Col == theMove.FromSquare.Col - 1)
                    || theMove.ToSquare.Col == theMove.FromSquare.Col + 1))
            {
                return theMove.ToSquare.ContainsPiece && base.CanMove(theMove);
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
