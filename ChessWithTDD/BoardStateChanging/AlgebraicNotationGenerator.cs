namespace ChessWithTDD
{
    /// <summary>
    /// Converts moves into algebraic notation strings. Uses long notation.
    /// Input should use a '-' for a move, and an 'x' for a capture.
    /// See http://www.chesscorner.com/tutorial/basic/notation/notate.htm for more details.
    /// </summary>
    public class AlgebraicNotationGenerator
    {
        /// <summary>
        /// Converts the move provided as input to its string representation. 
        /// Does no move validation, this should be ensured when the move is provided.
        /// </summary>
        /// <param name="move">The move to be converted to string format.</param>
        /// <returns>Move as a string in algebraic notation.</returns>
        public string Convert(IMove move)
        {
            string result = string.Empty;

            return result;
        }
    }
}
