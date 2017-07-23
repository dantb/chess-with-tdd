using System.Linq;
using static ChessWithTDD.ParsingConstants;

namespace ChessWithTDD
{
    /// <summary>
    /// This parser of algebraic chess notation uses long notation.
    /// Input should use a '-' for a move, and an 'x' for a capture.
    /// See http://www.chesscorner.com/tutorial/basic/notation/notate.htm for more details.
    /// </summary>
    public class AlgebraicNotationParser : IAlgebraicNotationParser
    {
        /// <summary>
        /// Parses the string in chess algebraic notation and returns the move if valid notation,
        /// or null otherwise
        /// </summary>
        public MoveConversionData Parse(string oneMoveInNotation)
        {
            char firstChar = oneMoveInNotation.First();
            Move move = !NonPawnPieces.Contains(firstChar) 
                ? PawnMove(oneMoveInNotation) 
                : NonPawnMove(oneMoveInNotation);
            if (move != null)
            {
                //only do work if this is a valid string and start with checkmate (since this implies check)
                var result = GetCheckAndCheckMateFromString(oneMoveInNotation, firstChar);
                return new MoveConversionData(move, result.Check, result.CheckMate);
            }
            return new MoveConversionData(move, false, false);
        }

        private (bool Check, bool CheckMate) GetCheckAndCheckMateFromString(string oneMoveInNotation, char firstChar)
        {
            bool check = false;
            bool checkMate = false;
            //only do work if this is a valid string and start with checkmate (since this implies check)
            if (oneMoveInNotation.Contains(CheckMateChar))
            {
                checkMate = NonPawnPieces.Contains(firstChar)
                    ? oneMoveInNotation[NonPawnMaxLength - 1] == CheckMateChar
                    : oneMoveInNotation[PawnMaxLength - 1] == CheckMateChar;
                check = checkMate;
            }
            else if (oneMoveInNotation.Contains(CheckChar))
            {
                check = NonPawnPieces.Contains(firstChar)
                    ? oneMoveInNotation[NonPawnMaxLength - 1] == CheckChar
                    : oneMoveInNotation[PawnMaxLength - 1] == CheckChar;
                checkMate = false; //would have contained check mate char otherwise
            }
            return (check, checkMate);
        }

        private Move NonPawnMove(string oneMoveInNotation)
        {
            if (ValidConnectorCharacter(oneMoveInNotation[NonPawnConnectorIndex]))
            {
                string fromPos = oneMoveInNotation.Substring(NonPawnFromStartIndex, 2);
                string toPos = oneMoveInNotation.Substring(NonPawnToStartIndex, 2);
                if (ValidColumns(fromPos[0], toPos[0]))
                {
                    int colFrom = LetterNumberMap[fromPos[0]];
                    int colTo = LetterNumberMap[toPos[0]];
                    int rowFrom = int.Parse(fromPos[1].ToString()) - 1;
                    int rowTo = int.Parse(toPos[1].ToString()) - 1;
                    if (NonPawnStringHasValidLength(oneMoveInNotation) &&
                        ValidRows(rowFrom, rowTo))
                    {
                        return new Move(rowFrom, colFrom, rowTo, colTo);
                    }
                }
            }
            return null;
        }

        private bool NonPawnStringHasValidLength(string oneMoveInNotation)
        {
            bool tooLong = oneMoveInNotation.Length > NonPawnMaxLength;
            bool tooLongWithoutCheckOrMate =
                oneMoveInNotation.Length == NonPawnMaxLength && !SpecialCases.Contains(oneMoveInNotation[6]);
            return !tooLong && !tooLongWithoutCheckOrMate;
        }

        private Move PawnMove(string oneMoveInNotation)
        {
            if (ValidConnectorCharacter(oneMoveInNotation[PawnConnectorIndex]))
            {
                string fromPos = oneMoveInNotation.Substring(PawnFromStartIndex, 2);
                string toPos = oneMoveInNotation.Substring(PawnToStartIndex, 2);
                if (ValidColumns(fromPos[0], toPos[0]))
                {
                    int colFrom = LetterNumberMap[fromPos[0]];
                    int colTo = LetterNumberMap[toPos[0]];
                    int rowFrom = int.Parse(fromPos[1].ToString()) - 1;
                    int rowTo = int.Parse(toPos[1].ToString()) - 1;
                    if (PawnStringHasValidLength(oneMoveInNotation) &&
                        ValidRows(rowFrom, rowTo))
                    {
                        return new Move(rowFrom, colFrom, rowTo, colTo);
                    }
                }
            }
            return null;
        }

        private bool PawnStringHasValidLength(string oneMoveInNotation)
        {
            bool tooLong = oneMoveInNotation.Length > PawnMaxLength;
            bool tooLongWithoutCheckOrMate =
                oneMoveInNotation.Length == PawnMaxLength && !SpecialCases.Contains(oneMoveInNotation[5]);
            return !tooLong && !tooLongWithoutCheckOrMate;
        }

        private bool ValidConnectorCharacter(char con)
        {
            return ConnectorCharacters.Contains(con);
        }

        private bool ValidColumns(char colFrom, char colTo)
        {
            if (LetterNumberMap.ContainsKey(colFrom) &&
                LetterNumberMap.ContainsKey(colTo))
            {
                return true;
            }
            return false;
        }

        private bool ValidRows(int rowFrom, int rowTo)
        {
            if (ValidBoardRows.Contains(rowFrom) &&
                ValidBoardRows.Contains(rowTo))
            {
                return true;
            }
            return false;
        }
    }
}
