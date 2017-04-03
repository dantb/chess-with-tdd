using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MultiSquareMoveValidatorTests
    {
        [TestCase(3, 2, 3, 7)]
        [Test]
        public void MoveMultipleSquaresHorizontallyRightIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowFrom, colTo - 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(3, 6, 3, 0)]
        [Test]
        public void MoveMultipleSquaresHorizontallyLeftIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowFrom, colTo + 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(2, 6, 2, 0)]
        [TestCase(2, 2, 2, 7)]
        [Test]
        public void MoveMultipleSquaresHorizontallyIsValidIfThereAreNoObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithGetSquaresMocked();

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.False(isBlocked);
        }

        [TestCase(2, 2, 6, 2)]
        [Test]
        public void MoveMultipleSquaresVerticallyUpIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo - 1, colFrom, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(5, 2, 2, 2)]
        [Test]
        public void MoveMultipleSquaresVerticallyDownIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo + 1, colFrom, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(5, 2, 2, 2)]
        [TestCase(2, 2, 5, 2)]
        [Test]
        public void MoveMultipleSquaresVerticallyIsValidIfThereAreNoObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithGetSquaresMocked();

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.False(isBlocked);
        }

        [TestCase(2, 5, 5, 2)]
        [Test]
        public void MoveMultipleSquaresNorthWestIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo - 1, colTo + 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(2, 3, 5, 6)]
        [Test]
        public void MoveMultipleSquaresNorthEastIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo - 1, colTo - 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(5, 5, 2, 2)]
        [Test]
        public void MoveMultipleSquaresSouthhWestIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo + 1, colTo + 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(5, 2, 2, 5)]
        [Test]
        public void MoveMultipleSquaresSouthEastIsNotValidIfThereAreObstructions(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            IPiece obstructionPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithPieceInSquare(rowTo + 1, colTo - 1, obstructionPiece);

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.True(isBlocked);
        }

        [TestCase(2, 5, 5, 2)]
        [TestCase(2, 3, 5, 6)]
        [TestCase(5, 5, 2, 2)]
        [TestCase(5, 2, 2, 5)]
        [Test]
        public void MoveMultipleSquaresDiagonallyIsValidIfThereAreNoObstructionsAndCanMoveOfPieceIsTrue(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard board = MockBoardWithGetSquaresMocked();

            MultiSquareMoveValidator multiMoveValidator = new MultiSquareMoveValidator();
            bool isBlocked = multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board);

            Assert.False(isBlocked);
        }
    }
}
