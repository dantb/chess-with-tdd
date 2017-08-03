using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.BoardConstants;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CastlingMoveValidatorTests
    {
        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special cases marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.                         *** TESTED HERE ***
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void InvalidCastleIfKingHasMoved(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(true, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square                                    *** TESTED HERE ***
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void InvalidCastleIfKingIsNotInFromSquare(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        ///10) Rook is not in expected square                                        *** TESTED HERE ***
        ///     (implicit from (2) but only with assumption of board initial position which we shouldn't make)
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void InvalidCastleIfRookIsNotInExpectedSquare(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            ISquare rookSquare = MockSquare(rookRow, rookCol);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king                          *** TESTED HERE ***
        /// 9) The to square is not 2 columns away from the king                     *** TESTED HERE ***
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW + 1, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside row big
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW - 1, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside row small
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 1, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside col big
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 1, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside col small
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW + 1, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside row big
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW - 1, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside row small
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 1, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside col big
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 1, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside col small
        [Test]
        public void InvalidCastleIfToSquareIsNotTheSameRowAndTwoColsAwayFromKing(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }


        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.                                                 *** TESTED HERE ***
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void InvalidCastleIfKingInCheck(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, true);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }


        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.             *** TESTED HERE ***
        /// 3) There are pieces standing between your king and rook                  *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void InvalidCastleIfRookHasMoved(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(true);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** TESTED HERE ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 1)]  //white queenside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 3)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 1)]  //black queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 3)]  //black queenside
        [Test]
        public void InvalidCastleIfPieceBetweenKingAndRookAndToSquareNotBlockedSquare(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol, int blockedRow, int blockedCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);
            StubSquareOnBoardWithPiece(board, blockedRow, blockedCol, MockPiece()); //blocking piece

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                  *** TESTED HERE ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece. *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                            *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 2)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 2)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 2)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 2)]  //black queenside
        [Test]
        public void InvalidCastleIfPieceBetweenKingAndRookAndToSquareIsBlockedSquare(int kingRow, int kingCol, int rookRow, int rookCol, int blockedRow, int blockedCol)
        {
            CastlingMoveValidator validator = new CastlingMoveValidator(MockMoveIntoCheckValidator());
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, rookSquare);
            ISquare blockedSquare = MockSquare(blockedRow, blockedCol);
            StubSquareOnBoardWithPiece(board, blockedRow, blockedCol, MockPiece()); //blocking piece

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, blockedSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                     *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece.    *** TESTED HERE ***
        /// 6) The king would be in check after castling.                               *** TESTED HERE ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 1)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 1)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 1)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 1)]  //black queenside
        [Test]
        public void InvalidCastleIfKingMovesThroughOrEndsUpOnAttackedSquareAndToSquareIsNotAttackedSquare(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol, int attackedRow, int attackedCol)
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            CastlingMoveValidator validator = new CastlingMoveValidator(moveIntoCheckValidator);
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);
            ISquare attackedSquare = MockSquare(attackedRow, attackedCol);
            StubSquareOnBoard(board, attackedSquare);
            moveIntoCheckValidator.Stub(m => m.MoveCausesMovingTeamCheck(board, fromSquare, attackedSquare)).Return(true);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                     *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece.    *** TESTED HERE ***
        /// 6) The king would be in check after castling.                               *** TESTED HERE ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, RIGHT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN + 2)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, LEFT_ROOK_COL, WHITE_BACK_ROW, KING_COLUMN - 2)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, RIGHT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN + 2)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, LEFT_ROOK_COL, BLACK_BACK_ROW, KING_COLUMN - 2)]  //black queenside
        [Test]
        public void InvalidCastleIfKingMovesThroughOrEndsUpOnAttackedSquareAndToSquareIsAttackedSquare(int kingRow, int kingCol, int rookRow, int rookCol, int attackedRow, int attackedCol)
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            CastlingMoveValidator validator = new CastlingMoveValidator(moveIntoCheckValidator);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, rookSquare);
            ISquare attackedSquare = MockSquare(attackedRow, attackedCol);
            StubSquareOnBoard(board, attackedSquare);
            moveIntoCheckValidator.Stub(m => m.MoveCausesMovingTeamCheck(board, fromSquare, attackedSquare)).Return(true);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, attackedSquare);

            Assert.False(isValidCastle);
        }

        /// <summary>
        /// The conditions for which castling is not allowed are listed below. 
        /// The invalid case for this particular test is marked. The other conditions should all pass where possible - special assumptions marked with stars.
        /// 
        /// 1) Your king has been moved earlier in the game.
        /// 2) The rook that castles has been moved earlier in the game.
        /// 3) There are pieces standing between your king and rook                     *** ContainsPiece is false by default. ***
        /// 4) The king is in check.
        /// 5) The king moves through a square that is attacked by a opponent piece.    *** MoveIntoCheckValidator returns false by default. ***
        /// 6) The king would be in check after castling.                               *** MoveIntoCheckValidator returns false by default. ***
        /// 7) The king is not in the from square
        /// 8) The to square is a different row to the king
        /// 9) The to square is not 2 columns away from the king
        /// 
        /// This tests the case that all of the above are not true, so we should have a valid castling move.
        /// 
        /// </summary>
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN + 2, WHITE_BACK_ROW, RIGHT_ROOK_COL)] //white kingside
        [TestCase(WHITE_BACK_ROW, KING_COLUMN, WHITE_BACK_ROW, KING_COLUMN - 2, WHITE_BACK_ROW, LEFT_ROOK_COL)]  //white queenside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN + 2, BLACK_BACK_ROW, RIGHT_ROOK_COL)] //black kingside
        [TestCase(BLACK_BACK_ROW, KING_COLUMN, BLACK_BACK_ROW, KING_COLUMN - 2, BLACK_BACK_ROW, LEFT_ROOK_COL)]  //black queenside
        [Test]
        public void ValidCastle(int kingRow, int kingCol, int toRow, int toCol, int rookRow, int rookCol)
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            CastlingMoveValidator validator = new CastlingMoveValidator(moveIntoCheckValidator);
            ISquare toSquare = MockSquare(toRow, toCol);
            IKing king = MockKingWithHasMovedAndCheckState(false, false);
            ISquare fromSquare = MockSquareWithPiece(kingRow, kingCol, king);
            IRook rook = MockRookWithHasMoved(false);
            ISquare rookSquare = MockSquareWithPiece(rookRow, rookCol, rook);
            IBoard board = MockBoardWithGetSquaresMocked();
            StubSquareOnBoard(board, fromSquare);
            StubSquareOnBoard(board, toSquare);
            StubSquareOnBoard(board, rookSquare);

            bool isValidCastle = validator.IsValidCastlingMove(king, board, fromSquare, toSquare);

            Assert.True(isValidCastle);
        }
    }
}