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
        /// <para>Converts the move provided as input to its string representation. </para> 
        /// <para>Does no move validation for specific pieces, this should be ensured when the move is provided.</para> 
        /// <para>The only case where a move can be invalid is if the row or col dimensions on the moves are out 
        /// of a board's dimensions. In this case an empty string is returned.</para>
        /// </summary>
        /// <returns>Move as a string in algebraic notation, or empty string for an invalid move.</returns>
        public string Convert(IMoveConversionData data)
        {
            string result = string.Empty;

            return result;
        }
    }
}
