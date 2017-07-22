using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class WhitePawnTests
    {
        #region Normal move

        [TestCase(5, 2, 6, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void WhitePawnCanMoveOneVerticalPositionUpTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 6, 2)]
        [TestCase(3, 3, 4, 3)]
        [Test]
        public void WhitePawnCannotMoveOneVerticalPositionUpTheBoardIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Normal move


        #region Taking a piece

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        [Test]
        public void WhitePawnCanMoveDiagonallyUpTheBoardIfBlackPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, blackPiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        [Test]
        public void WhitePawnCannotMoveDiagonallyUpTheBoardIfNoPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Taking a piece

        #region Taking a white pawn using en passant capture

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        public void WhitePawnCanMoveDiagonallyUpwardsToEmptySquareIfToSquareHasEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            //to square contains no piece but is marked with an EnPassantMark
            ISquare toSquare = MockSquareWithHasEnPassantMark(rowTo, colTo, true);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(4, 4, 5, 5)]
        [TestCase(4, 4, 5, 3)]
        public void WhitePawnCannotMoveDiagonallyUpwardsToEmptySquareIfToSquareHasNoEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithHasEnPassantMark(rowTo, colTo, false);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Taking a white pawn using en passant capture


        #region Double move for first turn

        [TestCase(4, 4, 6, 4)]
        [TestCase(2, 1, 4, 1)]
        [Test]
        public void WhitePawnCanMoveTwoVerticalSpacesUpTheBoardIfItHasNotMovedBefore(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new WhitePawn();
            pawn.HasMoved = false;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(4, 4, 6, 4)]
        [TestCase(2, 1, 4, 1)]
        [Test]
        public void WhitePawnCannotMoveTwoVerticalSpacesUpTheBoardIfItHasMovedBefore(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new WhitePawn();
            pawn.HasMoved = true;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(4, 4, 6, 4)]
        [TestCase(2, 1, 4, 1)]
        [Test]
        public void WhitePawnCannotMoveTwoVerticalSpacesUpTheBoardIfItHasNotMovedButToSquareContainsAPiece(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new WhitePawn();
            pawn.HasMoved = false;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Double move for first turn


        #region Other invalid moves

        [TestCase(5, 2, 5, 3)]
        [TestCase(3, 3, 3, 2)]
        [Test]
        public void WhitePawnCannotMoveOneHorizontalPositionAcrossTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(1, 1, 0, 1)]
        [Test]
        public void WhitePawnCannotMoveOneVerticalPositionDownTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new WhitePawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Other invalid moves
    }
}
