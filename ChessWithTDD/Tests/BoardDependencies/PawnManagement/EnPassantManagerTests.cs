using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class EnPassantManagerTests
    {
        [TestCase(2, 4, 4, 4)]
        [TestCase(1, 3, 3, 3)]
        [Test]
        public void MarkPassedSquareWithEnPassantMarkIfMovingTwoSquaresUp(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard theBoard = MockBoard();
            ISquare squareToGiveMark = MockSquare();
            theBoard.Stub(b => b.GetSquare(rowFrom + 1, colFrom)).Return(squareToGiveMark);
            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            squareToGiveMark.AssertWasCalled(s => s.HasEnPassantMark = true);
        }

        [TestCase(6, 4, 4, 4)]
        [TestCase(5, 3, 3, 3)]
        [Test]
        public void MarkPassedSquareWithEnPassantMarkIfMovingTwoSquaresDown(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard theBoard = MockBoard();
            ISquare squareToGiveMark = MockSquare();
            theBoard.Stub(b => b.GetSquare(rowFrom - 1, colFrom)).Return(squareToGiveMark);
            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            squareToGiveMark.AssertWasCalled(s => s.HasEnPassantMark = true);
        }

        [TestCase(2, 4, 3, 4)]
        [TestCase(1, 3, 2, 3)]
        [Test]
        public void DoNotMarkPassedSquareWithEnPassantMarkIfMovingOneSquareUp(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard theBoard = MockBoard();
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            theBoard.Stub(b => b.GetSquare(rowFrom + 1, colFrom)).Return(toSquare);
            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = true);
        }

        [TestCase(6, 4, 5, 4)]
        [TestCase(5, 3, 4, 3)]
        [Test]
        public void DoNotMarkPassedSquareWithEnPassantMarkIfMovingOneSquareDown(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard theBoard = MockBoard();
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            theBoard.Stub(b => b.GetSquare(rowFrom - 1, colFrom)).Return(toSquare);
            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pawn);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = true);
        }

        [TestCase(2, 4, 4, 4, 2)]
        [TestCase(1, 3, 3, 3, 5)]
        [Test]
        public void IfBoardIsMarkedTwoTurnsAgoTheMarkIsRemovedForPawnMovingUp(int rowFrom, int colFrom, int rowTo, int colTo, int turnCounter)
        {
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard theBoard = MockBoard();
            ISquare squareToRemoveMark = MockSquare();
            theBoard.Stub(b => b.GetSquare(rowFrom + 1, colFrom)).Return(squareToRemoveMark);
            theBoard.Stub(b => b.TurnCounter).Return(turnCounter);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);
            enPassantManager.UnmarkEnPassantSquares(turnCounter + 2);

            squareToRemoveMark.AssertWasCalled(s => s.HasEnPassantMark = false);
        }

        [TestCase(6, 4, 4, 4, 2)]
        [TestCase(5, 3, 3, 3, 5)]
        [Test]
        public void IfBoardIsMarkedTwoTurnsAgoTheMarkIsRemovedForPawnMovingDown(int rowFrom, int colFrom, int rowTo, int colTo, int turnCounter)
        {
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard theBoard = MockBoard();
            ISquare squareToRemoveMark = MockSquare();
            theBoard.Stub(b => b.GetSquare(rowFrom - 1, colFrom)).Return(squareToRemoveMark);
            theBoard.Stub(b => b.TurnCounter).Return(turnCounter);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);
            enPassantManager.UnmarkEnPassantSquares(turnCounter + 2);

            squareToRemoveMark.AssertWasCalled(s => s.HasEnPassantMark = false);
        }


        [TestCase(6, 4, 4, 4, 2)]
        [TestCase(5, 3, 3, 3, 5)]
        [Test]
        public void IfBoardMarkedOneTurnAgoTheMarkIsNotRemoved(int rowFrom, int colFrom, int rowTo, int colTo, int turnCounter)
        {
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            IBoard theBoard = MockBoard();
            ISquare squareToRemoveMark = MockSquare();
            theBoard.Stub(b => b.GetSquare(rowFrom - 1, colFrom)).Return(squareToRemoveMark);
            theBoard.Stub(b => b.TurnCounter).Return(turnCounter);

            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);
            enPassantManager.UnmarkEnPassantSquares(turnCounter + 1);

            squareToRemoveMark.AssertWasNotCalled(s => s.HasEnPassantMark = false);
        }

        [TestCase(2, 4, 3, 5)]
        [TestCase(1, 3, 2, 2)]
        [Test]
        public void IfToSquareHasEnPassantMarkAndTheMoveIsDiagonallyUpThenSquareUnmarkedAndPieceBelowTakenAndSquareAddedToPendingUpdates(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(true);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo - 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo - 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);
            List<ISquare> pendingUpdates = new List<ISquare>();
            theBoard.Stub(b => b.PendingUpdates).Return(pendingUpdates);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasCalled(s => s.Piece = null);
            theBoard.AssertWasCalled(b => b.PendingUpdates.Add(squareWithPawnToTake));
            Assert.True(pendingUpdates.Contains(squareWithPawnToTake));
        }

        [TestCase(2, 4, 4, 5)]
        [TestCase(1, 3, 5, 2)]
        [Test]
        public void IfToSquareHasEnPassantMarkButMoveNotDiagonallyUpThenNothingHappens(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(true);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo + 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo + 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.Piece = null);
        }

        [TestCase(2, 4, 3, 5)]
        [TestCase(1, 3, 2, 2)]
        [Test]
        public void IfToSquareDoesNotHaveEnPassantMarkAndTheMoveIsDiagonallyUpThenNothingHappens(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(false);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo + 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo + 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.Piece = null);
        }

        [TestCase(6, 4, 5, 3)]
        [TestCase(5, 3, 4, 4)]
        [Test]
        public void IfToSquareHasEnPassantMarkAndTheMoveIsDiagonallyDownThenSquareUnmarkedAndPieceAboveTakenAndSquareAddedToPendingUpdates(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(true);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo + 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo + 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);
            List<ISquare> pendingUpdates = new List<ISquare>();
            theBoard.Stub(b => b.PendingUpdates).Return(pendingUpdates);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasCalled(s => s.Piece = null);
            theBoard.AssertWasCalled(b => b.PendingUpdates.Add(squareWithPawnToTake));
            Assert.True(pendingUpdates.Contains(squareWithPawnToTake));
        }

        [TestCase(6, 4, 3, 3)]
        [TestCase(5, 3, 2, 4)]
        [Test]
        public void IfToSquareHasEnPassantMarkButMoveNotDiagonallyDownThenNothingHappens(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(true);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo + 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo + 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.Piece = null);
        }

        [TestCase(6, 4, 5, 3)]
        [TestCase(5, 3, 4, 4)]
        [Test]
        public void IfToSquareDoesNotHaveEnPassantMarkAndTheMoveIsDiagonallyDownThenNothingHappens(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //Arrange
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);

            //give to square the mark
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            toSquare.Stub(s => s.HasEnPassantMark).Return(false);

            //square one above with pawn to be taken
            IPawn mockPawnToTake = MockPawn();
            ISquare squareWithPawnToTake = MockSquareWithPiece(rowTo + 1, colTo, mockPawnToTake);

            IBoard theBoard = MockBoard();
            theBoard.Stub(b => b.GetSquare(rowTo + 1, colTo)).Return(squareWithPawnToTake);
            theBoard.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);

            //Act
            EnPassantManager enPassantManager = new EnPassantManager();
            enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);

            //Assert
            toSquare.AssertWasNotCalled(s => s.HasEnPassantMark = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.ContainsPiece = false);
            squareWithPawnToTake.AssertWasNotCalled(s => s.Piece = null);
        }
    }
}
