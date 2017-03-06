using NUnit.Framework;
using static ChessWithTDD.CommonTestMethods;

namespace ChessWithTDD
{
    [TestFixture]
    public class WhitePawnTests
    {
        [TestCase(5, 2, 6, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void WhitePawnCanMoveOneVerticalPositionUpTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 6, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void WhitePawnCannotMoveOneVerticalPositionUpTheBoardIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(5, 2, 6, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void WhitePawnCannotMoveOneVerticalPositionUpTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, whitePiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(5, 2, 5, 3)]
        [TestCase(3, 3, 3, 2)]
        [Test]
        public void WhitePawnCannotMoveOneHorizontalPositionAcrossTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(1, 1, 0, 1)]
        [Test]
        public void WhitePawnCannotMoveOneVerticalPositionDownTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        [Test]
        public void WhitePawnCanMoveDiagonallyUpTheBoardIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        [Test]
        public void WhitePawnCannotMoveDiagonallyUpTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }


        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        [Test]
        public void WhitePawnCannotMoveDiagonallyUpTheBoardIfNoPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            WhitePawn pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
