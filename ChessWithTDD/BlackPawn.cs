namespace ChessWithTDD
{
    /// <summary>
    /// A black pawn. The black team are at the top of the board in this model, occupying rows 6 and 7 intially.
    /// TODO - when it reaches end of board should be swappable. Not sure where this logic will go yet.
    /// </summary>
    internal class BlackPawn : Piece
    {
        public override Colour Colour
        {
            get
            {
                return Colour.Black;
            }
        }

        public override bool CanMove(IMove theMove)
        {
            //Normal move, one place down the board
            if (theMove.ToSquare.Row == theMove.FromSquare.Row - 1
                    && theMove.ToSquare.Col == theMove.FromSquare.Col)
            {
                return base.CanMove(theMove) && !WhitePieceInSquare(theMove.ToSquare);
            }

            //Moving diagonally downwards
            if (theMove.ToSquare.Row == theMove.FromSquare.Row - 1
                    && ((theMove.ToSquare.Col == theMove.FromSquare.Col - 1)
                    || theMove.ToSquare.Col == theMove.FromSquare.Col + 1))
            {
                return theMove.ToSquare.ContainsPiece && base.CanMove(theMove);
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
