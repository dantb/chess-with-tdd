using ChessWithTDD.Tests.TestHelpers;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveExecutorTests
    {
        [Test]
        public void WhenApplyMoveIsCalledAndFromSquareContainsAPawnCallPawnManager()
        {
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServicePawnManager()).Return(pawnManager).OverridePrevious();
            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            pawnManager.AssertWasCalled(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board));
        }

        [Test]
        public void WhenApplyMoveIsCalledAndFromSquareContainsAnyPieceDoNotCallPawnManager()
        {
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServicePawnManager()).Return(pawnManager).OverridePrevious();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            pawnManager.AssertWasNotCalled(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board));
        }

        [Test]
        public void WhenApplyMoveIsCalledUnmarkEnPassantSquaresIsCalledWithTurnCounter()
        {
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServicePawnManager()).Return(pawnManager).OverridePrevious();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();
            int turnCounter = 5;
            board.Stub(b => b.TurnCounter).Return(turnCounter);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            pawnManager.AssertWasCalled(pm => pm.UnmarkEnPassantSquares(turnCounter));
        }

        [Test]
        public void WhenApplyMoveIsCalledUpdateBoardCacheIsCalled()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            board.AssertWasCalled(b => b.UpdateBoardCache());
        }

        [Test]
        public void WhenApplyMoveIsCalledUpdateCheckStatesIsCalled()
        {
            ICheckManager checkManager = GenerateMock<ICheckManager>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceCheckManager()).Return(checkManager).OverridePrevious();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            checkManager.AssertWasCalled(cm => cm.UpdateCheckAndCheckMateStates(board, toSquare));
        }

        /// <summary>
        /// This is a system level test to ensure that the board cache is updated with black king after an apply.
        /// Otherwise the order of calling isn't enforced by any test.
        /// </summary>
        [Test]
        public void WhenApplyMoveIsCalledBoardCacheUpdatesBlackKingSquareIfBlackKingInFromSquareIsCalled()
        {
            BoardCache boardCache = new BoardCache();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            IKing piece = MockKingWithColour(Colour.Black);
            Square fromSquare = new Square(3, 3);
            fromSquare.ContainsPiece = true;
            fromSquare.Piece = piece;
            Square toSquare = new Square(3, 4);
            Board board = new Board(serviceLocator);
            board.SetSquare(fromSquare);
            board.SetSquare(toSquare);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            Assert.AreEqual(boardCache.BlackKingSquare, toSquare);
        }

        /// <summary>
        /// This is a system level test to ensure that the board cache is updated with white king after an apply.
        /// Otherwise the order of calling isn't enforced by any test.
        /// </summary>
        [Test]
        public void WhenApplyMoveIsCalledBoardCacheUpdatesWhiteKingSquareIfWhiteKingInFromSquareIsCalled()
        {
            BoardCache boardCache = new BoardCache();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            IKing piece = MockKingWithColour(Colour.White);
            Square fromSquare = new Square(3, 3);
            fromSquare.ContainsPiece = true;
            fromSquare.Piece = piece;
            Square toSquare = new Square(3, 4);
            Board board = new Board(serviceLocator);
            board.SetSquare(fromSquare);
            board.SetSquare(toSquare);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            Assert.AreEqual(boardCache.WhiteKingSquare, toSquare);
        }

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveToBoardChangesBoardStateCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            IPiece capturedPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, capturedPiece);
            Board board = new Board(serviceLocator);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            Assert.That(!board.GetSquare(rowFrom, colFrom).ContainsPiece && board.GetSquare(rowFrom, colFrom).Piece == null);
            Assert.That(board.GetSquare(rowTo, colTo).ContainsPiece && board.GetSquare(rowTo, colTo).Piece == thePiece);
            Assert.IsNotNull(board.GetSquare(rowTo, colTo).Piece);
        }

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveAddsToAndFromSquaresToPendingUpdatesForBoard(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            IPiece capturedPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, capturedPiece);
            Board board = new Board(serviceLocator);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            Assert.True(board.PendingUpdates.Contains(fromSquare));
            Assert.True(board.PendingUpdates.Contains(toSquare));
        }

        /// <summary>
        /// This tests forces the order of the apply method to be a certain way.
        /// It does NOT ensure that the board cache is called after the apply happens, that's what ths integration tests above are for.
        /// Combining the two test guarantees the order is as required.
        /// </summary>
        [Test]
        public void TestOrderingOfCallsInApplyMethod()
        {
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServicePawnManager()).Return(pawnManager).OverridePrevious();
            serviceLocator.Stub(s => s.GetServiceCheckManager()).Return(checkManager).OverridePrevious();

            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();
            IBoard board = MockBoardWithGetSquareAndPendingUpdates();

            List<object> callOrder = new List<object>();

            //Delegates used to add mocks to list
            Action<ISquare, ISquare, IBoard> addPMMakePawnAmendments = (frSq, toSq, bo) => callOrder.Add(pawnManager);
            Action<int> addPMUnmark = (i) => callOrder.Add(pawnManager);
            Action addB = () => callOrder.Add(board);
            Action<IBoard, ISquare> addCM = (bo, toSq) => callOrder.Add(checkManager);

            //Add mocks to list as they're called
            pawnManager.Stub(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board)).Do(addPMMakePawnAmendments);
            pawnManager.Stub(pm => pm.UnmarkEnPassantSquares(Arg<int>.Is.Anything)).Do(addPMUnmark);
            board.Stub(b => b.UpdateBoardCache()).Do(addB);
            checkManager.Stub(cm => cm.UpdateCheckAndCheckMateStates(board, toSquare)).Do(addCM);
            MoveExecutor moveExecutor = new MoveExecutor(serviceLocator);

            moveExecutor.ExecuteMove(board, fromSquare, toSquare);

            Assert.AreEqual(callOrder[0], pawnManager);
            Assert.AreEqual(callOrder[1], pawnManager);
            Assert.AreEqual(callOrder[2], board);
            Assert.AreEqual(callOrder[3], checkManager);
        }
    }
}
