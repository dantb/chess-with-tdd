using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    /// <summary>
    /// Generic piece class, contains logic common to all types of piece.
    /// Cannot be initialised with a valid colour and therefore will never be on a board.
    /// Should not be initialised at all outside of unit testing, in order to test functionality common to all pieces.
    /// </summary>
    internal class Piece : IPiece
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
        public virtual bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.ContainsPiece
                && toSquare.Piece.Colour == Colour)
            {
                return false;
            }
            else if (toSquare.Row < BOARD_LOWER_DIMENSION || toSquare.Col < BOARD_LOWER_DIMENSION
                || toSquare.Row >= BOARD_DIMENSION || toSquare.Col >= BOARD_DIMENSION)
            {
                return false;
            }
            return true;
        }
    }
}
