using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.BoardConstants;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class PawnManagerTests
    {
        [TestCase(1, 3)]
        [TestCase(6, 6)]
        [Test]
        public void MakePawnAmendmentsWhereHasMovedIsFalseSetsHasMovedToTrue(int toRow, int toCol)
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();            
            IPawn pawn = MockPawnWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare(toRow, toCol);

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            pawn.AssertWasCalled(p => p.HasMoved = true);
        }

        [TestCase(1, 3)]
        [TestCase(6, 6)]
        [Test]
        public void MakePawnAmendmentsWhereHasMovedIsTrueDoesNothing(int toRow, int toCol)
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare(toRow, toCol);

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            pawn.AssertWasNotCalled(p => p.HasMoved = true);
        }

        [TestCase(1, 3)]
        [TestCase(6, 6)]
        [Test]
        public void MakePawnAmendmentsCallsEnPassantManagerToMarkSquares(int toRow, int toCol)
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare(toRow, toCol);

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            mockEnPassantManager.AssertWasCalled(epm => epm.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard));
        }

        [TestCase(1, 3)]
        [TestCase(6, 6)]
        [Test]
        public void MakePawnAmendmentsCallsEnPassantManagerToCapturePiecesThroughEnPassant(int toRow, int toCol)
        {
            IEnPassantManager mockEnPassantManager = GenerateMock<IEnPassantManager>();
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare(toRow, toCol);

            PawnManager pawnManager = new PawnManager(mockEnPassantManager);
            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            mockEnPassantManager.AssertWasCalled(epm => epm.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard));
        }

        [TestCase(WHITE_BACK_ROW + 1, 2, WHITE_BACK_ROW, 2, Colour.Black)] // black pawn normal move
        [TestCase(WHITE_BACK_ROW + 1, 2, WHITE_BACK_ROW, 1, Colour.Black)] // black pawn capture
        [TestCase(WHITE_BACK_ROW + 1, 2, WHITE_BACK_ROW, 3, Colour.Black)] // black pawn capture
        [TestCase(BLACK_BACK_ROW - 1, 2, BLACK_BACK_ROW, 2, Colour.White)] // white pawn normal move
        [TestCase(BLACK_BACK_ROW - 1, 2, BLACK_BACK_ROW, 1, Colour.White)] // white pawn capture
        [TestCase(BLACK_BACK_ROW - 1, 2, BLACK_BACK_ROW, 3, Colour.White)] // white pawn capture
        [Test]
        public void MakePawnAmendmentsChangesPawnToQueenIfPromotionRow(int fromRow, int fromCol, int toRow, int toCol, Colour movingColour)
        {
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(fromRow, fromCol, pawn);
            ISquare toSquare = MockSquare(toRow, toCol);
            StubSquareOnBoard(theBoard, fromSquare);
            StubSquareOnBoard(theBoard, toSquare);
            PawnManager pawnManager = new PawnManager(MockEnPassantManager());

            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            theBoard.GetSquare(fromRow, fromCol).AssertWasCalled(
                s => s.Piece = Arg<IPiece>.Matches(p => p is Queen && p.Colour == movingColour));
        }

        [TestCase(WHITE_BACK_ROW + 3, 2, WHITE_BACK_ROW + 2, 2, Colour.Black)] // black pawn normal move
        [TestCase(WHITE_BACK_ROW + 4, 2, WHITE_BACK_ROW + 3, 3, Colour.Black)] // black pawn capture
        [TestCase(WHITE_BACK_ROW + 5, 2, WHITE_BACK_ROW + 5, 4, Colour.Black)] // black pawn capture
        [TestCase(BLACK_BACK_ROW - 5, 2, BLACK_BACK_ROW - 4, 2, Colour.White)] // white pawn normal move
        [TestCase(BLACK_BACK_ROW - 4, 2, BLACK_BACK_ROW - 4, 1, Colour.White)] // white pawn capture
        [TestCase(BLACK_BACK_ROW - 3, 2, BLACK_BACK_ROW - 3, 3, Colour.White)] // white pawn capture
        [Test]
        public void MakePawnAmendmentsDoesNotChangePawnToQueenIfNotPromotionRow(int fromRow, int fromCol, int toRow, int toCol, Colour movingColour)
        {
            IBoard theBoard = MockBoard();
            IPawn pawn = MockPawnWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(fromRow, fromCol, pawn);
            ISquare toSquare = MockSquare(toRow, toCol);
            StubSquareOnBoard(theBoard, fromSquare);
            StubSquareOnBoard(theBoard, toSquare);
            PawnManager pawnManager = new PawnManager(MockEnPassantManager());

            pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, theBoard);

            theBoard.GetSquare(fromRow, fromCol).AssertWasNotCalled(
                s => s.Piece = Arg<IPiece>.Matches(p => p is Queen && p.Colour == movingColour));
            Assert.True(theBoard.GetSquare(fromRow, fromCol).ContainsPiece);
            Assert.AreEqual(pawn, theBoard.GetSquare(fromRow, fromCol).Piece);
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
