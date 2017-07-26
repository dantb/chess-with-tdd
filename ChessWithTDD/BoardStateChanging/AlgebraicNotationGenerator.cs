using System.Linq;
using static ChessWithTDD.BoardConstants;
using static ChessWithTDD.ParsingConstants;

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
        /// <para>The cases where a move can be invalid are if the row or col dimensions on the moves are out
        /// of a board's dimensions, or the data has checkmate true and check false. In this case an empty string is returned.</para>
        /// </summary>
        /// <returns>Move as a string in algebraic notation, or empty string for invalid data.</returns>
        public string Convert(MoveGenerationData data)
        {
            int fromRow = data.Move.FromRow;
            int fromCol = data.Move.FromCol;
            int toRow = data.Move.ToRow;
            int toCol = data.Move.ToCol;

            if (!DataInvalid(data, fromRow, fromCol, toRow, toCol))
            {
                string specialCase = data.CheckMate
                    ? CheckMateChar.ToString()
                    : (data.Check ? CheckChar.ToString() : string.Empty);

                string piecePart = data.Piece == null || data.Piece is IPawn
                    ? string.Empty
                    : PieceTypeToCharacterMap[data.Piece.GetType()].ToString();

                char fromColChar = LetterNumberMap.First(p => p.Value == fromCol).Key;
                char toColChar = LetterNumberMap.First(p => p.Value == toCol).Key;
                char connector = data.Capture ? CaptureChar : MoveChar;

                return string.Concat(piecePart, fromColChar, fromRow + 1, connector, toColChar, toRow + 1, specialCase);
            }
            return string.Empty;
        }

        private bool DataInvalid(MoveGenerationData data, int fromRow, int fromCol, int toRow, int toCol)
        {
            return MoveInvalid(fromRow, fromCol, toRow, toCol) || (data.CheckMate && !data.Check);
        }

        private bool MoveInvalid(int fromRow, int fromCol, int toRow, int toCol)
        {
            return fromRow < BOARD_LOWER_DIMENSION || fromCol < BOARD_LOWER_DIMENSION ||
                   toRow < BOARD_LOWER_DIMENSION || toCol < BOARD_LOWER_DIMENSION ||
                   fromRow >= BOARD_DIMENSION || fromCol >= BOARD_DIMENSION ||
                   toRow >= BOARD_DIMENSION || toCol >= BOARD_DIMENSION;
        }
    }
}