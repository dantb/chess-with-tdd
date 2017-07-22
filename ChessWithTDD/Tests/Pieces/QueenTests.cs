using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class QueenTests
    {
        [TestCase(2, 5, 5, 2)]
        [TestCase(2, 3, 5, 6)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(5, 2, 2, 5)]
        [TestCase(3, 3, 4, 4)]
        public void QueenCanMoveDiagonally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Queen queen = new Queen(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, queen);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = queen.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(2, 6, 2, 0)]
        [TestCase(2, 2, 2, 7)]
        [TestCase(3, 3, 3, 4)]
        [Test]
        public void QueenCanMoveHorizontally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Queen queen = new Queen(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, queen);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = queen.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 2, 2)]
        [TestCase(2, 2, 5, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void QueenCanMoveVertically(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Queen queen = new Queen(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, queen);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = queen.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(2, 6, 3, 3)]
        [TestCase(3, 1, 4, 5)]
        [TestCase(6, 6, 2, 7)]
        public void QueenCannotMoveRandomly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Queen queen = new Queen(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, queen);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = queen.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
