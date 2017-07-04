using System;
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
            'K', //King
            'Q', //Queen
            'R', //Rook
            'B', //Bishop
            'N'  //Knight
        };
        private static Dictionary<char, int> LetterNumberMap = new Dictionary<char, int>()
        {
            { 'a', 0 },
            { 'b', 1 },
            { 'c', 2 },
            { 'd', 3 },
            { 'e', 4 },
            { 'f', 5 },
            { 'g', 6 },
            { 'h', 7 }
        };
        private static List<char> SpecialCases = new List<char>()
        {
            '+',
            '#'
        };
        private static List<char> ConnectorCharacters = new List<char>()
        {
            '-', //move
            'x'  //capture
        };
        private static HashSet<int> ValidBoardRows = new HashSet<int>()
        {
            0, 1, 2, 3, 4, 5, 6, 7
        };

        public AlgebraicNotationParser(IBoard theBoard)
        {
            _theBoard = theBoard;
        }

        public AlgebraicNotationParser()
        {
        }

        /// <summary>
        /// Parses the string in chess algebraic notation and returns the move if valid notation
        /// or null otherwise
        /// </summary>
        public IMove Parse(string oneMoveInNotation)
        {
            //try
            //{
                IMove theMove = null;
                char firstChar = oneMoveInNotation.First();
                if (!PieceCharacters.Contains(firstChar))
                {
                    return PawnMove(oneMoveInNotation);
                }
                else
                {
                    return NonPawnMove(oneMoveInNotation);
                }

                return theMove;
            //}
            //catch
            //{
            //    return null;
            //}
        }

        private IMove NonPawnMove(string oneMoveInNotation)
        {
            if (ValidConnectorCharacter(oneMoveInNotation[3]))
            {
                string fromPos = oneMoveInNotation.Substring(1, 2);
                string toPos = oneMoveInNotation.Substring(4, 2);
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
            bool tooLong = oneMoveInNotation.Length > 7;
            bool tooLongWithoutCheckOrMate =
                oneMoveInNotation.Length == 7 && !SpecialCases.Contains(oneMoveInNotation[6]);
            return !tooLong && !tooLongWithoutCheckOrMate;
        }

        private IMove PawnMove(string oneMoveInNotation)
        {
            if (ValidConnectorCharacter(oneMoveInNotation[2]))
            {
                string fromPos = oneMoveInNotation.Substring(0, 2);
                string toPos = oneMoveInNotation.Substring(3, 2);
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
            bool tooLong = oneMoveInNotation.Length > 6;
            bool tooLongWithoutCheckOrMate =
                oneMoveInNotation.Length == 6 && !SpecialCases.Contains(oneMoveInNotation[5]);
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
