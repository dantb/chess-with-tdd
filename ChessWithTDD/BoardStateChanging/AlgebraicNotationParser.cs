using System.Collections.Generic;
using System.Linq;

namespace ChessWithTDD
{
    /// <summary>
    /// This parser of algebraic chess notation uses long notation.
    /// Input should use a '-' for a move, and an 'x' for a capture.
    /// See http://www.chesscorner.com/tutorial/basic/notation/notate.htm for more details.
    /// </summary>
    public class AlgebraicNotationParser
    {
        private IBoard _theBoard;
        private static List<char> PieceCharacters = new List<char>()
        {
            'K',
            'Q',
            'R',
            'B',
            'N'
        };
        private static Dictionary<char, int> LetterNumberMap = new Dictionary<char, int>()
        {
            { 'a', 1 },
            { 'b', 2 },
            { 'c', 3 },
            { 'd', 4 },
            { 'e', 5 },
            { 'f', 6 },
            { 'g', 7 },
            { 'h', 8 }
        };
        private static List<string> SpecialCases = new List<string>()
        {
            "+",
            "++",
            "#"
        };

        public AlgebraicNotationParser(IBoard theBoard)
        {
            _theBoard = theBoard;
        }

        /// <summary>
        /// Parses the string in chess algebraic notation and returns the move if valid notation
        /// or null otherwise
        /// </summary>
        public IMove Parse(string oneMoveInNotation)
        {
            try
            {
                IMove theMove = null;
                char firstChar = oneMoveInNotation.First();
                if (!PieceCharacters.Contains(firstChar))
                {
                    //this is a pawn move
                    string piecePos = oneMoveInNotation.Substring(0, 2);
                    int row = LetterNumberMap[piecePos[0]];
                    int col = int.Parse(piecePos[1].ToString());
                    string toPos = oneMoveInNotation.Substring(3, 2);
                    int rowTo = LetterNumberMap[toPos[0]];
                    int colTo = int.Parse(toPos[1].ToString());
                    if (oneMoveInNotation.Length > 6)
                    {
                        //not well formed
                        return null;
                    }
                    else if (oneMoveInNotation.Length == 6 && !SpecialCases.Contains(oneMoveInNotation[5].ToString()))
                    {
                        //not an allowed special character
                        return null;
                    }
                    return new Move(row, col, rowTo, colTo);
                }

                return theMove;
            }
            catch
            {
                return null;
            }
        } 
    }
}
