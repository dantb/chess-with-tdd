using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    internal class KnightTests
    {
        [TestCase(1, 2, 2, 4)]
        [TestCase(1, 2, 0, 4)]
        [TestCase(2, 3, 3, 1)]
        [TestCase(2, 3, 1, 1)]
        [Test]
        public void KnightCanMoveOneVerticalAndTwoHorizontalPositions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Knight knight = new Knight(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, knight);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canKnightMove = knight.CanMove(fromSquare, toSquare);

            Assert.True(canKnightMove);
        }

        [TestCase(1, 2, 3, 3)]
        [TestCase(1, 2, 3, 1)]
        [TestCase(2, 3, 0, 4)]
        [TestCase(2, 3, 0, 2)]
        [Test]
        public void KnightCanMoveOneHorizontalAndTwoVerticalPositions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Knight knight = new Knight(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, knight);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canKnightMove = knight.CanMove(fromSquare, toSquare);

            Assert.True(canKnightMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(1, 1, 3, 3)]
        [TestCase(1, 1, 4, 4)]
        [TestCase(4, 4, 0, 0)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(1, 2, 6, 7)]
        [TestCase(4, 8, 2, 6)]
        [TestCase(5, 1, 3, 4)]
        [Test]
        public void KnightCannotMoveIfNotLShaped(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Knight knight = new Knight(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, knight);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canKnightMove = knight.CanMove(fromSquare, toSquare);

            Assert.False(canKnightMove);
        }

        [TestCase(1, 2, 3, 1)]
        [TestCase(2, 3, 0, 4)]
        [TestCase(1, 2, 0, 4)]
        [TestCase(2, 3, 3, 1)]
        [Test]
        public void KnightCannotMoveIfLShapedAndToSquareContainsPieceOfSameColour(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Knight knight = new Knight(Colour.Invalid);
            IPiece piece = MockPieceWithColour(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, knight);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, piece);

            bool canKnightMove = knight.CanMove(fromSquare, toSquare);

            Assert.False(canKnightMove);
        }

        [TestCase(1, 2, -1, 1)]
        [TestCase(2, 7, 0, 8)]
        [TestCase(0, 2, -1, 0)]
        [TestCase(2, 6, 3, 8)]
        [Test]
        public void KnightCannotMoveIfLShapedAndToSquareOffTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Knight knight = new Knight(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, knight);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canKnightMove = knight.CanMove(fromSquare, toSquare);

            Assert.False(canKnightMove);
        }
    }
}
