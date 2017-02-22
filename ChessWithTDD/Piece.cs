namespace ChessWithTDD
{
    /// <summary>
    /// Generic piece class, contains logic common to all types of piece.
    /// Cannot be initialised with a valid colour and therefore will never be on a board.
    /// Should not be initialised at all outside of unit testing, in order to test functionality common to all pieces.
    /// </summary>
    public class Piece : IPiece
    {
        internal Piece()
        {
        }

        public virtual Colour Colour
        {
            get
            {
                return Colour.Invalid;
            }
        }

        /// <summary>
        /// Determines whether this Piece can execute the given move. 
        /// Contains moving logic that is generic among all types of pieces. 
        /// </summary>
        public virtual bool CanMove(IMove theMove)
        {
            if (theMove.ToSquare.ContainsPiece
                && theMove.ToSquare.Piece.Colour == Colour)
            {
                return false;
            }
            return true;
        }
    }
}
