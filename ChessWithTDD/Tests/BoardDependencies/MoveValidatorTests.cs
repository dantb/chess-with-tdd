using NUnit.Framework;
using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveValidatorTests
    {
        #region Generic move validation

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

        #endregion Generic move validation


        #region Multi-square move validation

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

        #endregion Multi-square move validation


        #region Combined move validation

        [Test]
        public void MoveIsValidReturnsTrueIfGenericMoveValidationPassesAndMultiSquareValidationPasses()
        {
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            IBoard board = MockBoard();
            IGenericMoveValidator genericMoveValidator = GenerateMock<IGenericMoveValidator>();
            genericMoveValidator.Stub(gmv => 
                gmv.GenericSquareMoveValidationPasses(fromSquare, toSquare))
                .Return(true);
            IMultiSquareMoveValidator multiMoveValidator = GenerateMock<IMultiSquareMoveValidator>();
            multiMoveValidator.Stub(mmv =>
                mmv.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board))
                .Return(false);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.True(isValidMove);
        }

        [Test]
        public void MoveIsValidReturnsFalseIfGenericMoveValidationFailsButMultiSquareValidationPasses()
        {
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            IBoard board = MockBoard();
            IGenericMoveValidator genericMoveValidator = GenerateMock<IGenericMoveValidator>();
            genericMoveValidator.Stub(gmv =>
                gmv.GenericSquareMoveValidationPasses(fromSquare, toSquare))
                .Return(false);
            IMultiSquareMoveValidator multiMoveValidator = GenerateMock<IMultiSquareMoveValidator>();
            multiMoveValidator.Stub(mmv =>
                mmv.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board))
                .Return(false);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsValidReturnsFalseIfMultiSquareValidationFailsButGenericMoveValidationPasses()
        {
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            IBoard board = MockBoard();
            IGenericMoveValidator genericMoveValidator = GenerateMock<IGenericMoveValidator>();
            genericMoveValidator.Stub(gmv =>
                gmv.GenericSquareMoveValidationPasses(fromSquare, toSquare))
                .Return(true);
            IMultiSquareMoveValidator multiMoveValidator = GenerateMock<IMultiSquareMoveValidator>();
            multiMoveValidator.Stub(mmv =>
                mmv.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, board))
                .Return(true);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.False(isValidMove);
        }

        #endregion Combined move validation

    }
}