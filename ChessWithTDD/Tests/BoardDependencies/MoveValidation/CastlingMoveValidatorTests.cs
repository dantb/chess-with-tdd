using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
using static ChessWithTDD.BoardConstants;
using Rhino.Mocks;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CastlingMoveValidatorTests
    {
        [Test]
        public void InvalidCastleIfKingHasMoved()
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMoved(true);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [Test]
        public void InvalidCastleIfKingIsNotInFromSquare()
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMoved(false);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW + 1, KING_COLUMN + 2)] //different row
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW - 1, KING_COLUMN + 2)] //different row
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 1)]     //wrong col
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 3)]     //wrong col
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 1)]     //wrong col
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 3)]     //wrong col
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 1)]     //wrong col
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 3)]     //wrong col
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 1)]     //wrong col
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 3)]     //wrong col
        [Test]
        public void InvalidCastleIfToSquareIsNotTheSameRowAndTwoColsAwayFromKing(int kingRow, int kingCol, int toRow, int toCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [Test]
        public void InvalidCastleIfKingInCheck()
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, true); // show explicitly the king hasn't moved
            ISquare fromSquare = MockSquareWithPiece(king);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW)] // white king
        [TestCase(BLACK_BACK_ROW)] // black king
        [Test]
        public void InvalidKingSideCastleIfRightRookHasMoved(int kingRow)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(true);
            IBoard board = MockBoardWithPieceInSquare(kingRow, RIGHT_ROOK_COL, rook);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW)] // white king
        [TestCase(BLACK_BACK_ROW)] // black king
        [Test]
        public void InvalidQueenSideCastleIfLeftRookHasMoved(int kingRow)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(true);
            IBoard board = MockBoardWithPieceInSquare(kingRow, LEFT_ROOK_COL, rook);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN + 1)] // white king
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN + 2)] // white king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN + 1)] // black king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN + 2)] // black king
        [Test]
        public void InvalidKingSideCastleIfPieceBetweenKingAndRook(int kingRow, int kingCol,int blockedCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(false);                     // show explicitly the rook hasn't moved
            IBoard board = MockBoardWithPieceInSquare(kingRow, RIGHT_ROOK_COL, rook);
            StubSquareOnBoardWithPiece(board, kingRow, kingCol, king);
            StubSquareOnBoardWithPiece(board, kingRow, blockedCol, MockPiece());

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN - 1)] // white king
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN - 2)] // white king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN - 1)] // black king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN - 2)] // black king
        [Test]
        public void InvalidQueenSideCastleIfPieceBetweenKingAndRook(int kingRow, int kingCol, int blockedCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(false);                     // show explicitly the rook hasn't moved
            IBoard board = MockBoardWithPieceInSquare(kingRow, LEFT_ROOK_COL, rook);
            StubSquareOnBoardWithPiece(board, kingRow, kingCol, king);
            StubSquareOnBoardWithPiece(board, kingRow, blockedCol, MockPiece());

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN + 1)] // white king
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN + 2)] // white king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN + 1)] // black king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN + 2)] // black king
        [Test]
        public void InvalidKingSideCastleIfKingMovesThroughOrEndsUpOnAttackedSquare(int kingRow, int kingCol, int attackedCol)
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            CastlingMoveValidator validator = new CastlingMoveValidator(moveIntoCheckValidator);
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(false);                     // show explicitly the rook hasn't moved
            IBoard board = MockBoardWithPieceInSquare(kingRow, RIGHT_ROOK_COL, rook);
            ISquare attackedSquare = MockSquare(kingRow, attackedCol);
            StubSquareOnBoardWithPiece(board, attackedSquare);
            moveIntoCheckValidator.Stub(m => m.MoveCausesMovingTeamCheck(board, fromSquare, attackedSquare)).Return(true);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN - 1)] // white king
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, KING_COLUMN - 2)] // white king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN - 1)] // black king
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, KING_COLUMN - 2)] // black king
        [Test]
        public void InvalidQueenSideCastleIfKingMovesThroughOrEndsUpOnAttackedSquare(int kingRow, int kingCol, int attackedCol)
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            CastlingMoveValidator validator = new CastlingMoveValidator(moveIntoCheckValidator);
            ISquare toSquare = MockSquare();
            IKing king = MockKingWithHasMovedAndCheckState(false, false); // show explicitly the king hasn't moved and isn't in check
            ISquare fromSquare = MockSquareWithPiece(king);
            IRook rook = MockRookWithHasMoved(false);                     // show explicitly the rook hasn't moved
            IBoard board = MockBoardWithPieceInSquare(kingRow, LEFT_ROOK_COL, rook);
            ISquare attackedSquare = MockSquare(kingRow, attackedCol);
            StubSquareOnBoardWithPiece(board, attackedSquare);
            moveIntoCheckValidator.Stub(m => m.MoveCausesMovingTeamCheck(board, fromSquare, attackedSquare)).Return(true);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2)] 
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2)] 
        [Test]
        public void ValidKingSideCastle(int kingRow, int kingCol, int toRow, int toCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.True(isValidCastle);
        }

        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2)] 
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2)] 
        [Test]
        public void ValidQueenSideCastle(int kingRow, int kingCol, int toRow, int toCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IBoard board = MockBoard();

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.True(isValidCastle);
        }
    }
}