using System.Collections.Generic;

namespace ChessWithTDD
{
    internal class ParsingConstants
    {
        internal static HashSet<char> PieceCharacters = new HashSet<char>()
        {
            'K', //King
            'Q', //Queen
            'R', //Rook
            'B', //Bishop
            'N'  //Knight
        };

        internal static Dictionary<char, int> LetterNumberMap = new Dictionary<char, int>()
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

        internal static HashSet<char> SpecialCases = new HashSet<char>()
        {
            '+',
            '#'
        };

        internal static HashSet<char> ConnectorCharacters = new HashSet<char>()
        {
            '-', //move
            'x'  //capture
        };

        internal static HashSet<int> ValidBoardRows = new HashSet<int>()
        {
            0, 1, 2, 3, 4, 5, 6, 7
        };
    }
}
