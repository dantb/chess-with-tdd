using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    class BoardTests
    {
        private const int WhiteBackRow = 0;
        private const int BlackBackRow = 7;
        private const int LeftRookColumn = 0;
        private const int RightRookColumn = 7;
        private const int LeftKnightColumn = 1;
        private const int RightKnightColumn = 6;
        private const int LeftBishopColumn = 2;
        private const int RightBishopColumn = 5;
        private const int QueenColumn = 3;
        private const int KingColumn = 4;
        private const int WhitePawnInitialRow = 1;
        private const int BlackPawnInitialRow = 6;


        #region Board initialisation

        [Test]
        public void BoardIsInitialisedWithCorrectDimensions()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            Assert.True(board.RowCount == 8 && board.ColCount == 8);
        }       

        [Test]
        public void SquareAtPositionFiveSixOnBoardHasRowFiveAndColSix()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            Assert.True(board.GetSquare(5, 6).Row == 5 && board.GetSquare(5, 6).Col == 6);
        }

        [Test]
        public void InitialiseBoardIsCalledWhenCreatingABoardInstance()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            mockBoardInitialiser.AssertWasCalled(mbi => mbi.InitialiseBoardPieces(board));
        }

        [Test]
        public void InitialiseBoardCacheIsCalledWhenCreatingABoardInstance()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            boardCache.AssertWasCalled(bc => bc.InitialiseBoardCache(board));
        }

        #endregion Board initialisation


        #region Move validation

        [Test]
        public void MoveValidatorIsCalledWhenMoveIsValidIsCalled()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            mockMoveValidator.AssertWasCalled(mmv => mmv.MoveIsValid(fromSquare, toSquare, board));
        }

        [Test]
        public void MoveIsNotValidIfMoveValidatorReturnsFalse()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(false);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsNotValidIfMoveValidatorReturnsTrueButFromSquarePieceCannotMove()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece pieceThatCannotMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece();
            ISquare toSquare = MockSquare();
            StubPieceCanMoveForSpecificSquares(pieceThatCannotMove, false, fromSquare, toSquare);
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(true);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsValidIfMoveValidatorReturnsTrueAndFromSquarePieceCanMove()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();
            IPiece pieceThatCanMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(pieceThatCanMove);
            ISquare toSquare = MockSquare();
            StubPieceCanMoveForSpecificSquares(pieceThatCanMove, true, fromSquare, toSquare);
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(true);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.True(isValidMove);
        }

        #endregion Move validation


        #region Applying moves

        /// <summary>
        /// TODO: There's an assumption here that UpdateBoardCache is called after the pawn amendments happen.
        /// This is crucial and should be tested. Perhaps an integration test with those two dependencies not mocked.
        /// </summary>
        [Test]
        public void WhenApplyMoveIsCalledAndFromSquareContainsAPawnCallPawnManager()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            board.Apply(fromSquare, toSquare);

            pawnManager.AssertWasCalled(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board));
        }

        [Test]
        public void WhenApplyMoveIsCalledAndFromSquareContainsAnyPieceDoNotCallPawnManager()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            board.Apply(fromSquare, toSquare);

            pawnManager.AssertWasNotCalled(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board));
        }

        [Test]
        public void WhenApplyMoveIsCalledUnmarkEnPassantSquaresIsCalledWithTurnCounter()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            int turnCounter = 5;
            board.TurnCounter = turnCounter;

            board.Apply(fromSquare, toSquare);

            pawnManager.AssertWasCalled(pm => pm.UnmarkEnPassantSquares(turnCounter));
        }

        [Test]
        public void WhenApplyMoveIsCalledUpdateBoardCacheIsCalled()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            board.Apply(fromSquare, toSquare);

            boardCache.AssertWasCalled(pm => pm.UpdateBoardCache());
        }

        [Test]
        public void WhenApplyMoveIsCalledUpdateCheckStatesIsCalled()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(piece);
            ISquare toSquare = MockSquare();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            board.Apply(fromSquare, toSquare);

            checkManager.AssertWasCalled(cm => cm.UpdateCheckAndCheckMateStates(board, toSquare));
        }

        /// <summary>
        /// This is a system level test to ensure that the board cache is updated with black king after an apply.
        /// Otherwise the order of calling isn't enforced by any test.
        /// </summary>
        [Test]
        public void WhenApplyMoveIsCalledBoardCacheUpdatesBlackKingSquareIfBlackKingInFromSquareIsCalled()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IKing piece = MockKingWithColour(Colour.Black);
            Square fromSquare = new Square(3, 3);
            fromSquare.ContainsPiece = true;
            fromSquare.Piece = piece;
            Square toSquare = new Square(3, 4);

            BoardCache boardCache = new BoardCache();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            board.SetSquare(fromSquare);
            board.SetSquare(toSquare);
            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(boardCache.BlackKingSquare, toSquare);
        }

        /// <summary>
        /// This is a system level test to ensure that the board cache is updated with white king after an apply.
        /// Otherwise the order of calling isn't enforced by any test.
        /// </summary>
        [Test]
        public void WhenApplyMoveIsCalledBoardCacheUpdatesWhiteKingSquareIfWhiteKingInFromSquareIsCalled()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IKing piece = MockKingWithColour(Colour.White);
            Square fromSquare = new Square(3, 3);
            fromSquare.ContainsPiece = true;
            fromSquare.Piece = piece;
            Square toSquare = new Square(3, 4);

            BoardCache boardCache = new BoardCache();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            board.SetSquare(fromSquare);
            board.SetSquare(toSquare);
            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(boardCache.WhiteKingSquare, toSquare);
        }

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveToBoardChangesBoardStateCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece thePiece = MockPiece();
            IPiece capturedPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, capturedPiece);
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            board.Apply(fromSquare, toSquare);

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
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece thePiece = MockPiece();
            IPiece capturedPiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, capturedPiece);
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            board.Apply(fromSquare, toSquare);

            Assert.True(board.PendingUpdates.Contains(fromSquare));
            Assert.True(board.PendingUpdates.Contains(toSquare));
        }

        [Test]
        public void ApplyingMoveIncrementsTurnCounter()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(thePiece);
            ISquare toSquare = MockSquareWithPiece();

            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);
            int turnCounter = board.TurnCounter;
            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(board.TurnCounter, turnCounter + 1);
        }

        /// <summary>
        /// This tests forces the order of the apply method to be a certain way.
        /// It does NOT ensure that the board cache is called after the apply happens, that's what ths integration tests above are for.
        /// Combining the two test guarantees the order is as required.
        /// </summary>
        [Test]
        public void TestOrderingOfCallsInApplyMethod()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IMoveValidator mockMoveValidator = GenerateMock<IMoveValidator>();
            IPawnManager pawnManager = GenerateMock<IPawnManager>();
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckManager checkManager = GenerateMock<ICheckManager>();

            IPawn pawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(pawn);
            ISquare toSquare = MockSquare();
            Board board = new Board(mockBoardInitialiser, mockMoveValidator, pawnManager, boardCache, checkManager);

            List<object> callOrder = new List<object>();

            //Delegates used to add mocks to list
            Action<ISquare, ISquare, IBoard> addPMMakePawnAmendments = (frSq, toSq, bo) => callOrder.Add(pawnManager);
            Action<int> addPMUnmark = (i) => callOrder.Add(pawnManager);
            Action addBC = () => callOrder.Add(boardCache);
            Action<IBoard, ISquare> addCM = (bo, toSq) => callOrder.Add(checkManager);

            //Add mocks to list as they're called
            pawnManager.Stub(pm => pm.MakePawnSpecificAmendments(fromSquare, toSquare, board)).Do(addPMMakePawnAmendments);
            pawnManager.Stub(pm => pm.UnmarkEnPassantSquares(Arg<int>.Is.Anything)).Do(addPMUnmark);
            boardCache.Stub(bc => bc.UpdateBoardCache()).Do(addBC);
            checkManager.Stub(cm => cm.UpdateCheckAndCheckMateStates(board, toSquare)).Do(addCM);

            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(callOrder[0], pawnManager);
            Assert.AreEqual(callOrder[1], pawnManager);
            Assert.AreEqual(callOrder[2], boardCache);
            Assert.AreEqual(callOrder[3], checkManager);
        }


        #endregion Applying moves

    }
}
