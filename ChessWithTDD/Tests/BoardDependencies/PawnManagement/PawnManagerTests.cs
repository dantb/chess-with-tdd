using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class PawnManagerTests
    {
        [Test]
        public void MakePawnAmendmentsWhereHasMovedIsFalseSetsHasMovedToTrue()
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();            
            IPawn pawn = MockPawnWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            pawn.AssertWasCalled(p => p.HasMoved = true);
        }

        [Test]
        public void MakePawnAmendmentsWhereHasMovedIsTrueDoesNothing()
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            pawn.AssertWasNotCalled(p => p.HasMoved = true);
        }

        [Test]
        public void MakePawnAmendmentsCallsEnPassantManagerToMarkSquares()
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            mockEnPassantManager.AssertWasCalled(epm => epm.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard));
        }

        [Test]
        public void MakePawnAmendmentsCallsEnPassantManagerToCapturePiecesThroughEnPassant()
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            mockEnPassantManager.AssertWasCalled(epm => epm.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard));
        }

        [Test]
        public void UnmarkEnPassantCallsEnPassantManagerToUnmark()
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            int turnCounter = 99;

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.UnmarkEnPassantSquares(turnCounter);

            mockEnPassantManager.AssertWasCalled(epm => epm.UnmarkEnPassantSquares(turnCounter));
        }
    }
}
