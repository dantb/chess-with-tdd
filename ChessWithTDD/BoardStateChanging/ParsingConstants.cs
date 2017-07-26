using System;
using System.Collections.Generic;

namespace ChessWithTDD
{
    internal class ParsingConstants
    {
        internal static HashSet<char> NonPawnPieces = new HashSet<char>()
        {
            KingChar,
            QueenChar,
            RookChar,
            BishopChar,
            KnightChar
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

        internal static Dictionary<Type, char> PieceTypeToCharacterMap = new Dictionary<Type, char>()
        {
            { typeof(King), KingChar },
            { typeof(Queen), QueenChar },
            { typeof(Rook), RookChar},
            { typeof(Bishop), BishopChar},
            { typeof(Knight), KnightChar}
        };


        internal static HashSet<char> SpecialCases = new HashSet<char>()
        {
            CheckChar,
            CheckMateChar
        };

        internal static HashSet<char> ConnectorCharacters = new HashSet<char>()
        {
            MoveChar,
            CaptureChar
        };

        internal static HashSet<int> ValidBoardRows = new HashSet<int>()
        {
            0, 1, 2, 3, 4, 5, 6, 7
        };

        internal const char KingChar = 'K';
        internal const char QueenChar = 'Q';
        internal const char RookChar = 'R';
        internal const char BishopChar = 'B';
        internal const char KnightChar = 'N';

        internal const char MoveChar = '-';
        internal const char CaptureChar = 'x';

        internal const char CheckChar = '+';
        internal const char CheckMateChar = '#';

        //numeric constants for parsed string

        internal const int PawnConnectorIndex = 2;
        internal const int NonPawnConnectorIndex = 3;

        internal const int PawnMaxLength = 6;
        internal const int NonPawnMaxLength = 7;

        internal const int PawnFromStartIndex = 0;
        internal const int NonPawnFromStartIndex = 1;

        internal const int PawnToStartIndex = 3;
        internal const int NonPawnToStartIndex = 4;
    }
}
