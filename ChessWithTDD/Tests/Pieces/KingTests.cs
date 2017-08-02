using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class KingTests
    {
        [TestCase(3, 3, 3, 4)]
        [TestCase(3, 3, 4, 3)]
        [TestCase(3, 3, 3, 2)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(3, 3, 4, 4)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(3, 3, 4, 2)]
        [TestCase(3, 3, 2, 4)]
        public void KingCanMoveToAdjacentSquares(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            King king = new King(Colour.Invalid, MockCastlingMoveValidator(), MockBoard());
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, king);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = king.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 2, 2)]
        [TestCase(2, 2, 5, 2)]
        public void KingCannotMoveVerticallyMoreThanOneSquare(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            King king = new King(Colour.Invalid, MockCastlingMoveValidator(), MockBoard());
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, king);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = king.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(2, 6, 2, 0)]
        [TestCase(2, 2, 2, 7)]
        public void KingCannotMoveHorizontallyMoreThanOneSquare(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            King king = new King(Colour.Invalid, MockCastlingMoveValidator(), MockBoard());
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, king);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = king.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(2, 5, 5, 2)]
        [TestCase(2, 3, 5, 6)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(5, 2, 2, 5)]
        [Test]
        public void KingCannotMoveDiagonallyMoreThanOneSquare(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            King king = new King(Colour.Invalid, MockCastlingMoveValidator(), MockBoard());
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, king);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = king.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
