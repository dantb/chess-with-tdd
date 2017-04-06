using NUnit.Framework;
using System;
using System.Collections.Generic;
using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CheckMateManagerTests
    {
        [Test]
        public void IfBoardNotInCheckThenNoCheckMate()
        {
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(false);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndKingCanEscapeThenNoCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.KingCanEscape(board, whiteKingSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndThreateningPieceCanBeTakenTheNoCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
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

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceCanBeCaptured(boardCache.WhitePieceSquares, board, threateningSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndKingCannotEscapeAndThreateningPieceCannotBeTakenAndIsUnblockableThenCheckMate()
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
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.BlackKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceIsUnblockable(threateningSquare, whiteKingSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.True(inCheckMate);
        }


        [Test]
        public void IfBlackKingAndBoardInCheckAndKingCanEscapeThenNoCheckMate()
        {
            //Give board cache mocked white king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.KingCanEscape(board, blackKingSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfBlackKingAndBoardInCheckAndThreateningPieceCanBeTakenTheNoCheckMate()
        {
            //Give board cache mocked white king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
            boardCache.Stub(bc => bc.BlackPieceSquares).Return(cacheWhitePieces);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceCanBeCaptured(boardCache.BlackPieceSquares, board, threateningSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfBlackKingAndBoardInCheckAndKingCannotEscapeAndThreateningPieceCannotBeTakenAndIsUnblockableThenCheckMate()
        {
            //Give board cache mocked white king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            IBoardCache boardCache = GenerateMock<IBoardCache>();
            boardCache.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            //give other king a mocked one in board cache
            IKing king = MockKing();
            ISquare otherKingSquare = MockSquareWithPiece(king);
            boardCache.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceIsUnblockable(threateningSquare, blackKingSquare)).Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, boardCache, threateningSquare);

            Assert.True(inCheckMate);
        }   
    }
}
