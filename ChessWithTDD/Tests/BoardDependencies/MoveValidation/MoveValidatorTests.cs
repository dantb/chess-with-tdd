using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveValidatorTests
    {
        [Test]
        public void MoveIsValidReturnsTrueIfAllValidationPasses()
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
            IMoveIntoCheckValidator moveIntoCheckValidator = GenerateMock<IMoveIntoCheckValidator>();
            moveIntoCheckValidator.Stub(m => 
                m.MoveIsIntoCheck(board, fromSquare, toSquare))
                .Return(false);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator, moveIntoCheckValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.True(isValidMove);
        }

        [Test]
        public void MoveIsValidReturnsFalseIfJustGenericMoveValidationFails()
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
            IMoveIntoCheckValidator moveIntoCheckValidator = GenerateMock<IMoveIntoCheckValidator>();
            moveIntoCheckValidator.Stub(m =>
                m.MoveIsIntoCheck(board, fromSquare, toSquare))
                .Return(false);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator, moveIntoCheckValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsValidReturnsFalseIfJustMultiSquareValidationFails()
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
            IMoveIntoCheckValidator moveIntoCheckValidator = GenerateMock<IMoveIntoCheckValidator>();
            moveIntoCheckValidator.Stub(m =>
                m.MoveIsIntoCheck(board, fromSquare, toSquare))
                .Return(false);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator, moveIntoCheckValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsValidReturnsFalseIfJustMoveIntoCheckValidationFails()
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
            IMoveIntoCheckValidator moveIntoCheckValidator = GenerateMock<IMoveIntoCheckValidator>();
            moveIntoCheckValidator.Stub(m =>
                m.MoveIsIntoCheck(board, fromSquare, toSquare))
                .Return(true);

            MoveValidator moveValidator = new MoveValidator(genericMoveValidator, multiMoveValidator, moveIntoCheckValidator);
            bool isValidMove = moveValidator.MoveIsValid(fromSquare, toSquare, board);

            Assert.False(isValidMove);
        }
    }
}