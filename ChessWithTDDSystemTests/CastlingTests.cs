using ChessWithTDD;
using NUnit.Framework;
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

        [Test]
        public void BlackKingCastlesKingSide()
        {
            string path = GetPositionFilePath(CastlingFolder, BlackKingCastlesKingSideFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check king has move two squares across to the right
            ISquare kingSquareAfterCastling = board.GetSquare(7, 6);
            Assert.True(kingSquareAfterCastling.ContainsPiece);
            Assert.True(kingSquareAfterCastling.Piece is King);
            Assert.True(kingSquareAfterCastling.Piece.Colour == Colour.Black);

            // check rook has moved two spaces left after castling, to the other side of the king
            ISquare rookSquareAfterCastling = board.GetSquare(7, 5);
            Assert.True(rookSquareAfterCastling.ContainsPiece);
            Assert.True(rookSquareAfterCastling.Piece is Rook);
            Assert.True(rookSquareAfterCastling.Piece.Colour == Colour.Black);
        }

        [Test]
        public void BlackKingCastlesQueenSide()
        {
            string path = GetPositionFilePath(CastlingFolder, BlackKingCastlesQueenSideFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check king has move two squares across to the left
            ISquare kingSquareAfterCastling = board.GetSquare(7, 2);
            Assert.True(kingSquareAfterCastling.ContainsPiece);
            Assert.True(kingSquareAfterCastling.Piece is King);
            Assert.True(kingSquareAfterCastling.Piece.Colour == Colour.Black);

            // check rook has moved three spaces right after castling, to the other side of the king
            ISquare rookSquareAfterCastling = board.GetSquare(7, 3);
            Assert.True(rookSquareAfterCastling.ContainsPiece);
            Assert.True(rookSquareAfterCastling.Piece is Rook);
            Assert.True(rookSquareAfterCastling.Piece.Colour == Colour.Black);
        }

        [Test]
        public void WhiteKingCastlesKingSide()
        {
            string path = GetPositionFilePath(CastlingFolder, WhiteKingCastlesKingSideFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check king has move two squares across to the right
            ISquare kingSquareAfterCastling = board.GetSquare(0, 6);
            Assert.True(kingSquareAfterCastling.ContainsPiece);
            Assert.True(kingSquareAfterCastling.Piece is King);
            Assert.True(kingSquareAfterCastling.Piece.Colour == Colour.White);

            // check rook has moved two spaces left after castling, to the other side of the king
            ISquare rookSquareAfterCastling = board.GetSquare(0, 5);
            Assert.True(rookSquareAfterCastling.ContainsPiece);
            Assert.True(rookSquareAfterCastling.Piece is Rook);
            Assert.True(rookSquareAfterCastling.Piece.Colour == Colour.White);
        }


        [Test]
        public void WhiteKingCastlesQueenSide()
        {
            string path = GetPositionFilePath(CastlingFolder, WhiteKingCastlesQueenSideFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check king has move two squares across to the right
            ISquare kingSquareAfterCastling = board.GetSquare(0, 2);
            Assert.True(kingSquareAfterCastling.ContainsPiece);
            Assert.True(kingSquareAfterCastling.Piece is King);
            Assert.True(kingSquareAfterCastling.Piece.Colour == Colour.White);

            // check rook has moved two spaces left after castling, to the other side of the king
            ISquare rookSquareAfterCastling = board.GetSquare(0, 3);
            Assert.True(rookSquareAfterCastling.ContainsPiece);
            Assert.True(rookSquareAfterCastling.Piece is Rook);
            Assert.True(rookSquareAfterCastling.Piece.Colour == Colour.White);
        }
    }
}
