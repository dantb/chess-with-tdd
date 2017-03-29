using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class BlackPawnTests
    {
        #region Normal move

        [TestCase(5, 2, 4, 2)]
        [TestCase(3, 3, 2, 3)]
        [Test]
        public void BlackPawnCanMoveOneVerticalPositionDownTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(5, 2, 4, 2)]
        [TestCase(3, 3, 2, 3)]
        [Test]
        public void BlackPawnCannotMoveOneVerticalPositionDownTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, whitePiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Normal move


        #region Taking a piece

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        [Test]
        public void BlackPawnCanMoveDiagonallyDownTheBoardIfWhitePieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, whitePiece);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        [Test]
        public void BlackPawnCannotMoveDiagonallyBelowIfNoPieceThere(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Taking a piece

        #region Taking a white pawn using en passant capture

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        public void BlackPawnCanMoveDiagonallyDownwardsToEmptySquareIfToSquareHasEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            //to square contains no piece but is marked with an EnPassantMark
            ISquare toSquare = MockSquareWithHasEnPassantMark(rowTo, colTo, true);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(6, 6, 5, 7)]
        [TestCase(6, 6, 5, 5)]
        public void BlackPawnCannotMoveDiagonallyDownwardsToEmptySquareIfToSquareHasNoEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithHasEnPassantMark(rowTo, colTo, false);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Taking a white pawn using en passant capture

        #region Double move for first turn

        [TestCase(4, 4, 2, 4)]
        [TestCase(6, 1, 4, 1)]
        [Test]
        public void BlackPawnCanMoveTwoVerticalSpacesDownTheBoardIfItHasNotMovedBefore(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new BlackPawn();
            pawn.HasMoved = false;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.True(canPawnMove);
        }

        [TestCase(4, 4, 2, 4)]
        [TestCase(6, 1, 4, 1)]
        [Test]
        public void BlackPawnCannotMoveTwoVerticalSpacesDownTheBoardIfItHasMovedBefore(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new BlackPawn();
            pawn.HasMoved = true;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(4, 4, 2, 4)]
        [TestCase(6, 1, 4, 1)]
        [Test]
        public void BlackPawnCannotMoveTwoVerticalSpacesDownTheBoardIfItHasNotMovedButToSquareContainsAPiece(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPawn pawn = new BlackPawn();
            pawn.HasMoved = false;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Double move for first turn


        #region Other invalid moves

        [TestCase(0, 1, 1, 1)]
        [Test]
        public void BlackPawnCannotMoveOneVerticalPositionUpTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        [TestCase(5, 2, 5, 3)]
        [TestCase(3, 3, 3, 2)]
        [Test]
        public void BlackPawnCannotMoveOneHorizontalPositionAcrossTheBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece pawn = new BlackPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool canPawnMove = pawn.CanMove(fromSquare, toSquare);

            Assert.False(canPawnMove);
        }

        #endregion Other invalid moves
    }
}
