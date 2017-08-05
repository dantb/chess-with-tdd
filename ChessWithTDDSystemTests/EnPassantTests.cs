using Autofac;
using ChessWithTDD;
using NUnit.Framework;
using System;
using System.IO;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class EnPassantTests
    {
        private const string EnPassantFolder = "EnPassant";
        private const string WhitePawnCapturesBlackPawnUsingEnPassantFile = "WhitePawnCapturesBlackPawnUsingEnPassant.txt";
        private const string BlackPawnCapturesWhitePawnUsingEnPassantFile = "BlackPawnCapturesWhitePawnUsingEnPassant.txt";

        [Test]
        public void WhitePawnCapturesBlackPawnUsingEnPassant()
        {
            string path = GetPositionFilePath(EnPassantFolder, WhitePawnCapturesBlackPawnUsingEnPassantFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check the black pawn has been captured
            ISquare takenBlackPawnSquare = board.GetSquare(4, 5);
            Assert.False(takenBlackPawnSquare.ContainsPiece);

            // check the white pawn has moved diagonally
            ISquare whitePawnSquare = board.GetSquare(5, 5);
            Assert.True(whitePawnSquare.ContainsPiece);
            Assert.True(whitePawnSquare.Piece is WhitePawn);
        }

        [Test]
        public void BlackPawnCapturesWhitePawnUsingEnPassant()
        {
            string path = GetPositionFilePath(EnPassantFolder, BlackPawnCapturesWhitePawnUsingEnPassantFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check the white pawn has been captured
            ISquare takenWhitePawnSquare = board.GetSquare(3, 2);
            Assert.False(takenWhitePawnSquare.ContainsPiece);

            // check the black pawn has moved diagonally
            ISquare blackPawnSquare = board.GetSquare(2, 2);
            Assert.True(blackPawnSquare.ContainsPiece);
            Assert.True(blackPawnSquare.Piece is BlackPawn);
        }
    }
}
