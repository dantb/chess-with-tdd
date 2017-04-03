using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;
using static Rhino.Mocks.MockRepository;
using Rhino.Mocks;
using System.Collections.Generic;
using System;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CheckManagerTests
    {
        #region Check

        [Test]
        public void IfWhitePieceMovedToCheckTheBlackKingThenBoardAndBlackKingPutInCheckState()
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, blackKingSquare)).Return(true);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = true);
            blackKing.AssertWasCalled(b => b.InCheckState = true);
            checkMateManager.AssertWasCalled(cmm => cmm.BoardIsInCheckMate(board, boardCache, toSquare));
        }

        [TestCase(true)]
        [TestCase(false)]
        [Test]
        public void IfWhitePieceMovedToCheckTheBlackKingThenCheckMateManagerCalledAndBoardCheckMateStateSetToValue(bool checkMate)
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, blackKingSquare)).Return(true);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            checkMateManager.Stub(cmm => cmm.BoardIsInCheckMate(board, boardCache, toSquare)).Return(checkMate);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = true);
            //check mate should be called with the value returned by check mate manager
            board.AssertWasCalled(b => b.CheckMate = checkMate);
            blackKing.AssertWasCalled(b => b.InCheckState = true);
        }

        [Test]
        public void IfBlackPieceMovedToCheckTheWhiteKingThenBoardAndWhiteKingPutInCheckState()
        {
            //Give board cache mocked black king
            IKing whiteKing = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, whiteKingSquare)).Return(true);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = true);
            whiteKing.AssertWasCalled(b => b.InCheckState = true);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Test]
        public void IfBlackPieceMovedToCheckTheWhiteKingThenCheckMateManagerCalledAndBoardCheckMateStateSetToValue(bool checkMate)
        {
            //Give board cache mocked black king
            IKing whiteKing = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, whiteKingSquare)).Return(true);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            checkMateManager.Stub(cmm => cmm.BoardIsInCheckMate(board, boardCache, toSquare)).Return(checkMate);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = true);
            //check mate should be called with the value returned by check mate manager
            board.AssertWasCalled(b => b.CheckMate = checkMate);
            whiteKing.AssertWasCalled(b => b.InCheckState = true);
        }

        [Test]
        public void IfBoardAndWhiteKingInCheckStateRemoveCheckStates()
        {
            //Give board cache mocked black king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            //Give black king square a piece although we don't care about it
            IKing king = MockKing();
            ISquare square = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(square);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            //Don't care about square, stop add check states from causing problems
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Invalid);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = false);
            whiteKing.AssertWasCalled(b => b.InCheckState = false);
        }

        [Test]
        public void IfBoardAndBlackKingInCheckStateRemoveCheckStates()
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            //Give white king square a piece although we don't care about it
            IKing king = MockKing();
            ISquare square = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(square);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            //Don't care about square, stop add check states from causing problems
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Invalid);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            CheckManager checkManager = new CheckManager(checkMateManager, boardCache);
            checkManager.UpdateCheckStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = false);
            blackKing.AssertWasCalled(b => b.InCheckState = false);
        }

        #endregion Check

        [Test]
        public void IfBoardNotInCheckThenNoCheckMate()
        {
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(false);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [TestCase(3, 3, 3, 4)]
        [TestCase(3, 3, 3, 2)]
        [TestCase(3, 3, 4, 3)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(3, 3, 4, 4)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(3, 3, 4, 2)]
        [TestCase(3, 3, 2, 4)]
        [Test]
        public void IfWhiteKingAndBoardInCheckAndKingCanEscapeThenNoCheckMate(int kingRow, int kingCol, int adjacentRow, int adjacentCol)
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(kingRow, kingCol, whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(otherKingSquare);

            ISquare adjacentSquare = MockSquareWithoutPiece(adjacentRow, adjacentCol);
            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.GetSquare(adjacentSquare.Row, adjacentSquare.Col)).Return(adjacentSquare);

            board.Stub(b => b.MoveIsValid(whiteKingSquare, adjacentSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndKingCannotEscapeButThreateningPieceCanBeTaken()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            //piece that can take threatening piece
            IPiece savingPiece = MockPiece();
            ISquare savingSquare = MockSquareWithPiece(savingPiece);
            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare> { savingSquare };
            boardCache.Stub(bc => bc.WhitePieceSquares).Return(cacheWhitePieces);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.MoveIsValid(savingSquare, threateningSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        /// <summary>
        /// Instead of making multiple long tests to test the exact same thing, I'm passing the type in and making the mock threatening piece from that.
        /// It's not nice but it's less testing code than one for every piece type that can't be blocked
        /// </summary>
        /// <param name="threateningPieceType">Type of the piece that just checked the king, type is unblockable</param>
        [TestCase(typeof(WhitePawn))]
        [TestCase(typeof(BlackPawn))]
        [TestCase(typeof(Knight))]
        [TestCase(typeof(King))]
        [Test]
        public void IfWhiteKingAndBoardInCheckAndKingCannotEscapeAndThreateningPieceCannotBeTakenAndIsUnblockableThenCheckMate(Type threateningPieceType)
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            boardCache.Stub(b => b.WhitePieceSquares).Return(new HashSet<ISquare>());

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            if (threateningPieceType == typeof(WhitePawn) || threateningPieceType == typeof(BlackPawn))
            {
                threateningPiece = MockPawn();
            }
            else if (threateningPieceType == typeof(Knight))
            {
                threateningPiece = MockKnight();
            }
            else if (threateningPieceType == typeof(King))
            {
                threateningPiece = MockKing();
            }

            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.True(inCheckMate);
        }


        /// <summary>
        /// Instead of making multiple long tests to test the exact same thing, I'm passing the type in and making the mock threatening piece from that.
        /// It's not nice but it's less testing code than one for every piece type that can't be blocked
        /// </summary>
        /// <param name="threateningPieceType">Type of the piece that just checked the king, type is unblockable</param>
        [TestCase(typeof(WhitePawn))]
        [TestCase(typeof(BlackPawn))]
        [TestCase(typeof(Knight))]
        [TestCase(typeof(King))]
        [Test]
        public void IfBlackKingAndBoardInCheckAndKingCannotEscapeAndThreateningPieceCannotBeTakenAndIsUnblockableThenCheckMate(Type threateningPieceType)
        {
            //Give board cache mocked white king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            boardCache.Stub(b => b.BlackPieceSquares).Return(new HashSet<ISquare>());

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            if (threateningPieceType == typeof(WhitePawn) || threateningPieceType == typeof(BlackPawn))
            {
                threateningPiece = MockPawn();
            }
            else if (threateningPieceType == typeof(Knight))
            {
                threateningPiece = MockKnight();
            }
            else if (threateningPieceType == typeof(King))
            {
                threateningPiece = MockKing();
            }

            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.True(inCheckMate);
        }

        [TestCase(3, 3, 3, 4)]
        [TestCase(3, 3, 3, 2)]
        [TestCase(3, 3, 4, 3)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(3, 3, 4, 4)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(3, 3, 4, 2)]
        [TestCase(3, 3, 2, 4)]
        [Test]
        public void IfBlackKingAndBoardInCheckAndKingCanEscapeThenNoCheckMate(int kingRow, int kingCol, int adjacentRow, int adjacentCol)
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(kingRow, kingCol, blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            ISquare adjacentSquare = MockSquareWithoutPiece(adjacentRow, adjacentCol);
            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.GetSquare(adjacentSquare.Row, adjacentSquare.Col)).Return(adjacentSquare);
            board.Stub(b => b.MoveIsValid(blackKingSquare, adjacentSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfBlackKingAndBoardInCheckAndKingCannotEscapeButThreateningPieceCanBeTaken()
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            //piece that can take threatening piece
            IPiece savingPiece = MockPiece();
            ISquare savingSquare = MockSquareWithPiece(savingPiece);
            HashSet<ISquare> cacheBlackPieces = new HashSet<ISquare> { savingSquare };
            boardCache.Stub(bc => bc.BlackPieceSquares).Return(cacheBlackPieces);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.MoveIsValid(savingSquare, threateningSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager();
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }
    }
}
