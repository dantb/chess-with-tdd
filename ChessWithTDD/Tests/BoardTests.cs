using ChessWithTDD.Tests.TestHelpers;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
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
            IStrictServiceLocator serviceLocator = MockServiceLocator();

            Board board = new Board(serviceLocator);

            Assert.True(board.RowCount == 8 && board.ColCount == 8);
        }       

        [Test]
        public void SquareAtPositionFiveSixOnBoardHasRowFiveAndColSix()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();

            Board board = new Board(serviceLocator);

            Assert.True(board.GetSquare(5, 6).Row == 5 && board.GetSquare(5, 6).Col == 6);
        }

        [Test]
        public void InitialiseBoardIsCalledWhenCreatingABoardInstance()
        {
            IBoardInitialiser mockBoardInitialiser = GenerateMock<IBoardInitialiser>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceBoardInitialiser()).Return(mockBoardInitialiser).OverridePrevious();

            Board board = new Board(serviceLocator);

            mockBoardInitialiser.AssertWasCalled(mbi => mbi.InitialiseBoardPieces(board));
        }

        [Test]
        public void InitialiseBoardCacheIsCalledWhenCreatingABoardInstance()
        {
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();

            Board board = new Board(serviceLocator);

            boardCache.AssertWasCalled(bc => bc.InitialiseBoardCache(board));
        }

        #endregion Board initialisation


        #region Move validation

        [Test]
        public void MoveValidatorIsCalledWhenMoveIsValidIsCalled()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();

            Board board = new Board(serviceLocator);
            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            mockMoveValidator.AssertWasCalled(mmv => mmv.MoveIsValid(fromSquare, toSquare, board));
        }

        [Test]
        public void MoveIsNotValidIfMoveValidatorReturnsFalse()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            ISquare fromSquare = MockSquare();
            ISquare toSquare = MockSquare();
            Board board = new Board(serviceLocator);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(false);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsNotValidIfMoveValidatorReturnsTrueButFromSquarePieceCannotMove()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            IPiece pieceThatCannotMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece();
            ISquare toSquare = MockSquare();
            StubPieceCanMoveForSpecificSquares(pieceThatCannotMove, false, fromSquare, toSquare);
            Board board = new Board(serviceLocator);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(true);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsNotValidIfMoveValidatorAndPiecePassButMoveIntoCheckValidatorFails()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            serviceLocator.Stub(s => s.GetServiceMoveIntoCheckValidator()).Return(moveIntoCheckValidator).OverridePrevious();
            IPiece pieceThatCanMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(pieceThatCanMove);
            ISquare toSquare = MockSquare();
            StubPieceCanMoveForSpecificSquares(pieceThatCanMove, true, fromSquare, toSquare);
            Board board = new Board(serviceLocator);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(true);
            moveIntoCheckValidator.Stub(mmv => mmv.MoveCausesMovingTeamCheck(board, fromSquare, toSquare)).Return(true);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [Test]
        public void MoveIsValidIfAllValidationPasses()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            serviceLocator.Stub(s => s.GetServiceMoveIntoCheckValidator()).Return(moveIntoCheckValidator).OverridePrevious();
            IPiece pieceThatCanMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(pieceThatCanMove);
            ISquare toSquare = MockSquare();
            StubPieceCanMoveForSpecificSquares(pieceThatCanMove, true, fromSquare, toSquare);
            Board board = new Board(serviceLocator);
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Return(true);
            moveIntoCheckValidator.Stub(mmv => mmv.MoveCausesMovingTeamCheck(board, fromSquare, toSquare)).Return(false);

            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.True(isValidMove);
        }

        [Test]
        public void TestOrderingOfCallsInMoveIsValidMethod()
        {
            IMoveValidator mockMoveValidator = MockMoveValidator();
            IMoveIntoCheckValidator moveIntoCheckValidator = MockMoveIntoCheckValidator();
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(mockMoveValidator).OverridePrevious();
            serviceLocator.Stub(s => s.GetServiceMoveIntoCheckValidator()).Return(moveIntoCheckValidator).OverridePrevious();

            IPiece pieceThatCanMove = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(pieceThatCanMove);
            ISquare toSquare = MockSquare();
            Board board = new Board(serviceLocator);

            List<object> callOrder = new List<object>();

            //Delegates used to add mocks to list
            Func<ISquare, ISquare, IBoard, bool> callMoveValidator = (frSq, toSq, bo) =>
            {
                callOrder.Add(mockMoveValidator);
                return true;
            };

            Func<ISquare, ISquare, bool> askPieceIfItCanMove = (fs, ts) =>
            {
                callOrder.Add(pieceThatCanMove);
                return true;
            };

            Func<IBoard, ISquare, ISquare, bool> callMoveIntoCheckValidator = (bo, fs, ts) =>
            {
                callOrder.Add(moveIntoCheckValidator);
                return false;
            };

            //Add mocks to list as they're called
            mockMoveValidator.Stub(mmv => mmv.MoveIsValid(fromSquare, toSquare, board)).Do(callMoveValidator);
            pieceThatCanMove.Stub(p => p.CanMove(fromSquare, toSquare)).Do(askPieceIfItCanMove);
            moveIntoCheckValidator.Stub(mmv => mmv.MoveCausesMovingTeamCheck(board, fromSquare, toSquare)).Do(callMoveIntoCheckValidator);

            //Act
            bool isValidMove = board.MoveIsValid(fromSquare, toSquare);

            Assert.AreEqual(callOrder[0], mockMoveValidator);
            Assert.AreEqual(callOrder[1], pieceThatCanMove);
            Assert.AreEqual(callOrder[2], moveIntoCheckValidator);
        }


        #endregion Move validation


        #region Applying moves

        [Test]
        public void ApplyingMoveCallsMoveExecutorWithCorrectArguments()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IMoveExecutor moveExecutor = MockMoveExecutor();
            serviceLocator.Stub(s => s.GetServiceMoveExecutor()).Return(moveExecutor).OverridePrevious();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(thePiece);
            ISquare toSquare = MockSquareWithPiece();
            Board board = new Board(serviceLocator);
            int turnCounter = board.TurnCounter;

            board.Apply(fromSquare, toSquare);

            moveExecutor.AssertWasCalled(m => m.ExecuteMove(board, fromSquare, toSquare));
        }

        [Test]
        public void ApplyingMoveIncrementsTurnCounter()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(thePiece);
            ISquare toSquare = MockSquareWithPiece();
            Board board = new Board(serviceLocator);
            int turnCounter = board.TurnCounter;

            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(board.TurnCounter, turnCounter + 1);
        }

        [TestCase(1, 2, 3, 4, false, false, false)]
        [TestCase(1, 2, 3, 4, false, true, false)]
        [TestCase(1, 2, 3, 4, false, true, true)]
        [TestCase(1, 2, 3, 4, true, false, false)]
        [TestCase(1, 2, 3, 4, true, true, false)]
        [TestCase(1, 2, 3, 4, true, true, true)]
        [Test]
        public void ApplyingMoveFiresMoveAppliedEvent(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;
            MoveAppliedEventArgs theArgs = null;
            board.MoveAppliedEvent += (_, e) => { theArgs = e; };
            
            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(new Move(rowFrom, colFrom, rowTo, colTo), theArgs.Data.Move);
            Assert.AreEqual(capture, theArgs.Data.Capture);
            Assert.AreEqual(check, theArgs.Data.Check);
            Assert.AreEqual(checkMate, theArgs.Data.CheckMate);
            Assert.AreEqual(thePiece, theArgs.Data.Piece);
        }

        [TestCase(1, 2, 3, 4, true, false, false)]
        [TestCase(1, 2, 3, 4, true, true, false)]
        [Test]
        public void ApplyingMoveAddsMoveDataToMoveListAtTheEnd(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;
            MoveAppliedEventArgs theArgs = null;
            board.MoveAppliedEvent += (_, e) => { theArgs = e; };

            board.Apply(fromSquare, toSquare);
            Assert.AreEqual(theArgs.Data, board.OrderedMoveData[board.OrderedMoveData.Count - 1]);

            board.Apply(fromSquare, toSquare);
            Assert.AreEqual(theArgs.Data, board.OrderedMoveData[board.OrderedMoveData.Count - 1]);
        }

        [Test]
        public void ApplyingWithoutCheckAndMateCallsMoveExecutorWithCorrectArguments()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IMoveExecutor moveExecutor = MockMoveExecutor();
            serviceLocator.Stub(s => s.GetServiceMoveExecutor()).Return(moveExecutor).OverridePrevious();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(thePiece);
            ISquare toSquare = MockSquareWithPiece();
            Board board = new Board(serviceLocator);
            int turnCounter = board.TurnCounter;

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);

            moveExecutor.AssertWasCalled(m => m.ExecuteMoveWithoutUpdatingCheckAndMate(board, fromSquare, toSquare));
        }

        [Test]
        public void ApplyingWithoutCheckAndMateIncrementsTurnCounter()
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(thePiece);
            ISquare toSquare = MockSquareWithPiece();
            Board board = new Board(serviceLocator);
            int turnCounter = board.TurnCounter;

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);

            Assert.AreEqual(board.TurnCounter, turnCounter + 1);
        }

        [TestCase(1, 2, 3, 4, false, false, false)]
        [TestCase(1, 2, 3, 4, false, true, false)]
        [TestCase(1, 2, 3, 4, false, true, true)]
        [TestCase(1, 2, 3, 4, true, false, false)]
        [TestCase(1, 2, 3, 4, true, true, false)]
        [TestCase(1, 2, 3, 4, true, true, true)]
        [Test]
        public void ApplyingWithoutCheckAndMateFiresMoveAppliedEvent(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;
            MoveAppliedEventArgs theArgs = null;
            board.MoveAppliedEvent += (_, e) => { theArgs = e; };

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);

            Assert.AreEqual(new Move(rowFrom, colFrom, rowTo, colTo), theArgs.Data.Move);
            Assert.AreEqual(capture, theArgs.Data.Capture);
            Assert.AreEqual(check, theArgs.Data.Check);
            Assert.AreEqual(checkMate, theArgs.Data.CheckMate);
            Assert.AreEqual(thePiece, theArgs.Data.Piece);
        }

        [TestCase(1, 2, 3, 4, true, false, false)]
        [TestCase(1, 2, 3, 4, true, true, false)]
        [Test]
        public void ApplyingWithoutCheckAndMateAddsMoveDataToMoveListAtTheEnd(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;
            MoveAppliedEventArgs theArgs = null;
            board.MoveAppliedEvent += (_, e) => { theArgs = e; };

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);
            Assert.AreEqual(theArgs.Data, board.OrderedMoveData[board.OrderedMoveData.Count - 1]);

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);
            Assert.AreEqual(theArgs.Data, board.OrderedMoveData[board.OrderedMoveData.Count - 1]);
        }

        [TestCase(1, 2, 3, 4, true, true, true)]
        [Test]
        public void TestOrderingOfCallsInApplyMethod(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IMoveExecutor moveExecutor = MockMoveExecutor();
            serviceLocator.Stub(s => s.GetServiceMoveExecutor()).Return(moveExecutor).OverridePrevious();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;


            MoveAppliedEventArgs theArgs = null;
            List<object> callOrder = new List<object>();
            board.MoveAppliedEvent += (_, e) => 
            {
                theArgs = e;
                callOrder.Add(e);
            };

            Action<IBoard, ISquare, ISquare> callOrderAddMoveExecutor = (b, fs, ts) => { callOrder.Add(moveExecutor); };
            moveExecutor.Stub(me => me.ExecuteMove(board, fromSquare, toSquare)).Do(callOrderAddMoveExecutor);

            board.OrderedMoveData.CollectionChanged += (_, e) => { callOrder.Add(e.NewItems[0]); };

            board.Apply(fromSquare, toSquare);

            Assert.AreEqual(moveExecutor, callOrder[0]);
            Assert.AreEqual(theArgs, callOrder[1]);
            Assert.AreEqual(theArgs.Data, callOrder[2]);
        }

        [TestCase(1, 2, 3, 4, true, true, true)]
        [Test]
        public void TestOrderingOfCallsInApplyWithoutCheckAndMateMethod(int rowFrom, int colFrom, int rowTo, int colTo, bool capture, bool check, bool checkMate)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IMoveExecutor moveExecutor = MockMoveExecutor();
            serviceLocator.Stub(s => s.GetServiceMoveExecutor()).Return(moveExecutor).OverridePrevious();
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(ts => ts.ContainsPiece).Return(capture);
            Board board = new Board(serviceLocator);
            board.InCheck = check;
            board.CheckMate = checkMate;

            MoveAppliedEventArgs theArgs = null;
            List<object> callOrder = new List<object>();
            board.MoveAppliedEvent += (_, e) =>
            {
                theArgs = e;
                callOrder.Add(e);
            };

            Action<IBoard, ISquare, ISquare> callOrderAddMoveExecutor = (b, fs, ts) => { callOrder.Add(moveExecutor); };
            moveExecutor.Stub(me => me.ExecuteMoveWithoutUpdatingCheckAndMate(board, fromSquare, toSquare)).Do(callOrderAddMoveExecutor);

            board.OrderedMoveData.CollectionChanged += (_, e) => { callOrder.Add(e.NewItems[0]); };

            board.ApplyWithoutUpdatingCheckAndMate(fromSquare, toSquare);

            Assert.AreEqual(moveExecutor, callOrder[0]);
            Assert.AreEqual(theArgs, callOrder[1]);
            Assert.AreEqual(theArgs.Data, callOrder[2]);
        }

        #endregion Applying moves


        #region Properties

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(19)]
        [Test]
        public void MovingTeamKingSquareIsBlackKingOfBoardCacheForOddTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            ISquare blackKingSquare = MockSquare();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            ISquare currentTeamKingSquare = board.MovingTeamKingSquare;

            Assert.AreEqual(currentTeamKingSquare, blackKingSquare);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(22)]
        [Test]
        public void MovingTeamKingSquareIsWhiteKingOfBoardCacheForEvenTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            ISquare whiteKingSquare = MockSquare();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            ISquare currentTeamKingSquare = board.MovingTeamKingSquare;

            Assert.AreEqual(currentTeamKingSquare, whiteKingSquare);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(22)]
        [Test]
        public void OtherTeamKingSquareIsBlackKingOfBoardCacheForEvenTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            ISquare blackKingSquare = MockSquare();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            ISquare otherTeamKingSquare = board.OtherTeamKingSquare;

            Assert.AreEqual(otherTeamKingSquare, blackKingSquare);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(19)]
        [Test]
        public void OtherTeamKingSquareIsWhiteKingOfBoardCacheForOddTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            ISquare whiteKingSquare = MockSquare();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            ISquare otherTeamKingSquare = board.OtherTeamKingSquare;

            Assert.AreEqual(otherTeamKingSquare, whiteKingSquare);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(19)]
        [Test]
        public void MovingTeamPieceSquaresIsBlackTeamOfBoardCacheForOddTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            HashSet<ISquare> blackTeam = new HashSet<ISquare>();
            boardCache.Stub(b => b.BlackPieceSquares).Return(blackTeam);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            HashSet<ISquare> currentTeam = board.MovingTeamPieceSquares;

            Assert.AreEqual(currentTeam, blackTeam);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(22)]
        [Test]
        public void MovingTeamPieceSquaresIsWhiteTeamOfBoardCacheForEvenTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            HashSet<ISquare> whiteTeam = new HashSet<ISquare>();
            boardCache.Stub(b => b.WhitePieceSquares).Return(whiteTeam);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            HashSet<ISquare> currentTeam = board.MovingTeamPieceSquares;

            Assert.AreEqual(currentTeam, whiteTeam);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(22)]
        [Test]
        public void OtherTeamPieceSquaresIsBlackTeamOfBoardCacheForEvenTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            HashSet<ISquare> blackTeam = new HashSet<ISquare>();
            boardCache.Stub(b => b.BlackPieceSquares).Return(blackTeam);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            HashSet<ISquare> currentTeam = board.OtherTeamPieceSquares;

            Assert.AreEqual(currentTeam, blackTeam);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(19)]
        [Test]
        public void OtherTeamPieceSquaresIsWhiteTeamOfBoardCacheForOddTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            IBoardCache boardCache = MockBoardCache();
            HashSet<ISquare> whiteTeam = new HashSet<ISquare>();
            boardCache.Stub(b => b.WhitePieceSquares).Return(whiteTeam);
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(boardCache).OverridePrevious();
            Board board = new Board(serviceLocator);
            board.TurnCounter = turnCounter;

            HashSet<ISquare> currentTeam = board.OtherTeamPieceSquares;

            Assert.AreEqual(currentTeam, whiteTeam);
        }

        [TestCase(0)]
        [TestCase(2)]
        [TestCase(22)]
        [Test]
        public void TeamWithTurnIsWhiteForEvenTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            Board board = new Board(serviceLocator);

            board.TurnCounter = turnCounter;

            Assert.AreEqual(board.TeamWithTurn, Colour.White);
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(19)]
        [Test]
        public void TeamWithTurnIsBlackForOddTurnCounters(int turnCounter)
        {
            IStrictServiceLocator serviceLocator = MockServiceLocator();
            Board board = new Board(serviceLocator);

            board.TurnCounter = turnCounter;

            Assert.AreEqual(board.TeamWithTurn, Colour.Black);
        }

        #endregion Properties

    }
}
