using NUnit.Framework;
using static ChessWithTDD.CommonTestMethods;

namespace ChessWithTDD
{
    [TestFixture]
    public class BlackPawnTests
    {
        [TestCase(5, 2, 4, 2)]
        [TestCase(3, 3, 2, 3)]
        [Test]
        public void BlackPawnCanMoveOneVerticalPositionDownTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare =  MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 4, 2)]
        [TestCase(3, 3, 2, 3)]
        [Test]
        public void BlackPawnCannotMoveOneVerticalPositionDownTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, whitePiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(5, 2, 4, 2)]
        [TestCase(3, 3, 2, 3)]
        [Test]
        public void BlackPawnCannotMoveOneVerticalPositionDownTheBoardIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(0, 1, 1, 1)]
        [Test]
        public void BlackPawnCannotMoveOneVerticalPositionUpTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(5, 2, 5, 3)]
        [TestCase(3, 3, 3, 2)]
        [Test]
        public void BlackPawnCannotMoveOneHorizontalPositionAcrossTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        [Test]
        public void BlackPawnCanMoveDiagonallyDownTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, whitePiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        [Test]
        public void BlackPawnCannotMoveDiagonallyBelowIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        [Test]
        public void BlackPawnCannotMoveDiagonallyBelowIfNoPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            BlackPawn pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
