using ChessWithTDD;
using NUnit.Framework;
using System;
using System.IO;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class CastlingTests
    {
        private const string CastlingFolder = "Castling";
        private const string BlackKingCastlesKingSideFile = "BlackKingCastlesKingSide.txt";
        private const string BlackKingCastlesQueenSideFile = "BlackKingCastlesQueenSide.txt";
        private const string WhiteKingCastlesKingSideFile = "WhiteKingCastlesKingSide.txt";
        private const string WhiteKingCastlesQueenSideFile = "WhiteKingCastlesQueenSide.txt";

        //[Test]
        //public void BlackKingCastlesKingSide()
        //{
        //    string path = GetPositionFilePath(CastlingFolder, BlackKingCastlesKingSideFile);
        //    IBoard board = NewBoard();

        //    PositionLoaderService.LoadPositionIntoBoard(board, path);

        //    ISquare takenBlackPawnSquare = board.GetSquare(4, 5);
        //    Assert.False(takenBlackPawnSquare.ContainsPiece);
        //}
    }
}
