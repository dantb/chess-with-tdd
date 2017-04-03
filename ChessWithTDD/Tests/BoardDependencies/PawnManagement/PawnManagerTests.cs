using NUnit.Framework;
using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;
using static ChessWithTDD.Tests.CommonTestMethods;

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
    }
}
