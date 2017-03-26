using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class RookTests
    {
        [TestCase(2, 6, 2, 0)]
        [TestCase(2, 2, 2, 7)]
        [TestCase(3, 3, 3, 4)]
        [Test]
        public void RookCanMoveHorizontally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Rook rook = new Rook(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, rook);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = rook.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 2, 2)]
        [TestCase(2, 2, 5, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void RookCanMoveVertically(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Rook rook = new Rook(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, rook);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = rook.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(2, 5, 5, 2)]
        [TestCase(2, 3, 5, 6)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(5, 2, 2, 5)]
        [TestCase(3, 3, 4, 4)]
        [Test]
        public void RookCannotMoveDiagonally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Rook rook = new Rook(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, rook);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = rook.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(2, 6, 3, 3)]
        [TestCase(3, 1, 4, 5)]
        [TestCase(6, 6, 2, 7)]
        [Test]
        public void RookCannotMoveRandomly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Rook rook = new Rook(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, rook);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = rook.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
