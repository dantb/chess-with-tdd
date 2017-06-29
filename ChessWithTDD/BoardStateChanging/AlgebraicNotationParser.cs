﻿using System.Collections.Generic;
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
        private static List<string> SpecialCases = new List<string>()
        {
            "+",
            "++",
            "#"
        };
        private static List<char> ConnectorCharacters = new List<char>()
        {
            '-',
            'x'
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
            try
            {
                IMove theMove = null;
                char firstChar = oneMoveInNotation.First();
                if (!PieceCharacters.Contains(firstChar))
                {
                    //this is a pawn move
                    if (!ConnectorCharacters.Contains(oneMoveInNotation[2]))
                    {
                        return null;
                    }
                    string piecePos = oneMoveInNotation.Substring(0, 2);
                    int col = LetterNumberMap[piecePos[0]];
                    int row = int.Parse(piecePos[1].ToString()) - 1;
                    string toPos = oneMoveInNotation.Substring(3, 2);
                    int colTo = LetterNumberMap[toPos[0]];
                    int rowTo = int.Parse(toPos[1].ToString()) - 1;
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
                    if (!ValidBoardRows.Contains(row) ||
                        !ValidBoardRows.Contains(rowTo))
                    {
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