using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.BoardConstants;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CastlingExecutorTests
    {
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 1, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 1)]
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 1, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)]
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW + 1, KING_COLUMN, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)]
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW + 1, KING_COLUMN + 1, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 1)]
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW + 1, KING_COLUMN - 1, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)]
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 1, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 1)]
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 1, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)]
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW - 1, KING_COLUMN, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)]
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW - 1, KING_COLUMN + 1, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 1)]
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW - 1, KING_COLUMN - 1, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)]
        [Test]
        public void KingMoveToAdjacentSquareDoesNothingExceptSetKingHasMovedTrue(int kingRow, int kingCol, int toRow, int toCol,
            int rookRow, int rookCol, int rookFinalRow, int rookFinalCol)
        {
            CastlingExecutor executor = new CastlingExecutor();
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            ISquare rookFinalSquare = MockSquare(rookFinalRow, rookFinalCol);
            IBoard board = MockBoardWithGetSquaresMocked();
            List<ISquare> pendingUpdates = new List<ISquare>();
            board.Stub(b => b.PendingUpdates).Return(pendingUpdates);
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);
            StubSquareOnBoard(board, rookFinalSquare);

            executor.ExecuteCastlingMove(fromSquare, toSquare, board);

            // assert not moved
            rookFinalSquare.AssertWasNotCalled(r => r.ContainsPiece = true);
            rookFinalSquare.AssertWasNotCalled(r => r.Piece = rook);
            rookSquare.AssertWasNotCalled(r => r.ContainsPiece = false);
            rookSquare.AssertWasNotCalled(r => r.Piece = null);

            // assert that HasMoved states not changed
            rook.AssertWasNotCalled(r => r.HasMoved = true);

            // important - king HasMoved should have changed
            king.AssertWasCalled(k => k.HasMoved = true);

            // assert rook from and rook final squares not added to pending updates
            Assert.False(pendingUpdates.Contains(rookSquare));
            Assert.False(pendingUpdates.Contains(rookFinalSquare));
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 1)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 1)]  //black queenside
        [Test]
        public void KingMoveTwoSquaresMovesRookAndSetsHasMovedStatesToTrue(int kingRow, int kingCol, int toRow, int toCol, 
            int rookRow, int rookCol, int rookFinalRow, int rookFinalCol)
        {
            CastlingExecutor executor = new CastlingExecutor();
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            ISquare rookFinalSquare = MockSquare(rookFinalRow, rookFinalCol);
            IBoard board = MockBoardWithGetSquaresMocked();
            List<ISquare> pendingUpdates = new List<ISquare>();
            board.Stub(b => b.PendingUpdates).Return(pendingUpdates);
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);
            StubSquareOnBoard(board, rookFinalSquare);

            executor.ExecuteCastlingMove(fromSquare, toSquare, board);

            // assert rook was moved correctly
            rookFinalSquare.AssertWasCalled(r => r.ContainsPiece = true);
            rookFinalSquare.AssertWasCalled(r => r.Piece = rook);
            rookSquare.AssertWasCalled(r => r.ContainsPiece = false);
            rookSquare.AssertWasCalled(r => r.Piece = null);

            // assert that HasMoved states were change correctly
            king.AssertWasCalled(k => k.HasMoved = true);
            rook.AssertWasCalled(r => r.HasMoved = true);

            // assert rook from and rook final squares added to pending updates
            Assert.True(pendingUpdates.Contains(rookSquare));
            Assert.True(pendingUpdates.Contains(rookFinalSquare));
        }
    }
}
