using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class GenericMoveValidatorTests
    {
        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquarePieceDoesNotHaveAValidColourIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            IPiece thePiece = MockPieceWithColour(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 9, 5)]
        [TestCase(5, 3, 6, 8)]
        [TestCase(7, 8, 2, 2)]
        [TestCase(9, 1, 2, 2)]
        [TestCase(1, 1, -1, 5)]
        [TestCase(5, 3, 6, -1)]
        [TestCase(7, -1, 2, 2)]
        [TestCase(-1, 1, 2, 2)]
        [Test]
        public void MoveWhereFromSquareOrToSquareIsOffTheBoardIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            IPiece pieceWithColour = MockPieceWithColour(Colour.White);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pieceWithColour);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquareDoesNotContainPieceIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            ISquare fromSquare = MockSquareWithoutPiece(rowFrom, colFrom);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(5, 3, 5, 3)]
        [Test]
        public void MoveWhereFromSquareIsSamePositionAsToSquareIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            IPiece piece = MockPieceWithColour(Colour.White);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowFrom, colFrom);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(2, 2, 3, 2, Colour.White)]
        [TestCase(5, 3, 4, 3, Colour.Black)]
        [TestCase(5, 3, 4, 3, Colour.Invalid)]
        [Test]
        public void MoveWherePieceInToSquareIsOfSameColourAsMovingPieceIsInvalid(int rowFrom, int colFrom, int rowTo, int colTo, Colour theColour)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            IPiece piece = MockPieceWithColour(theColour);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            IPiece toSquarePiece = MockPieceWithColour(theColour);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, toSquarePiece);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        /// <summary>
        /// Tests that if none of the other criteria are met, the move is valid.
        /// </summary>
        [TestCase(2, 2, 2, 3)]
        [TestCase(5, 3, 6, 3)]
        [Test]
        public void MoveWhereFromSquareHasAPieceOfDifferentValidColourToToSquareIsValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            GenericMoveValidator moveValidator = new GenericMoveValidator();
            IPiece piece = MockPieceWithColour(Colour.White);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = moveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare);

            Assert.True(isValidMove);
        }
    }
}
