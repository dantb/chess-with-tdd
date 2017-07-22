using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class BishopTests
    {
        [TestCase(2, 5, 5, 2)]
        [TestCase(2, 3, 5, 6)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(5, 2, 2, 5)]
        [TestCase(3, 3, 4, 4)]
        public void BishopCanMoveDiagonally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Bishop bishop = new Bishop(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, bishop);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = bishop.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 2, 2)]
        [TestCase(2, 2, 5, 2)]
        public void BishopCannotMoveVertically(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Bishop bishop = new Bishop(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, bishop);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = bishop.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(2, 6, 2, 0)]
        [TestCase(2, 2, 2, 7)]
        public void BishopCannotMoveHorizontally(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Bishop bishop = new Bishop(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, bishop);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = bishop.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(2, 6, 3, 3)]
        [TestCase(3, 1, 4, 5)]
        [TestCase(6, 6, 2, 7)]
        public void BishopCannotMoveRandomlyIfNotDiagonal(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Bishop bishop = new Bishop(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, bishop);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = bishop.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }
    }
}
