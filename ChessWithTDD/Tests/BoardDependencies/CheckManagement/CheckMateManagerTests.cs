using NUnit.Framework;
using System.Collections.Generic;
using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;
using static ChessWithTDD.Tests.CommonTestMethods;
using System;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CheckMateManagerTests
    {
        [Test]
        public void IfBoardNotInCheckThenNoCheckMate()
        {
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(false);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

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

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(whiteKingSquare);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.KingCanEscape(board, whiteKingSquare)).Return(true);
            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);

            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndThreateningPieceCanBeTakenThenNoCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(whiteKingSquare);
            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
            board.Stub(bc => bc.OtherTeamPieceSquares).Return(cacheWhitePieces);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceCanBeCaptured(board.OtherTeamPieceSquares, board, threateningSquare))
                .Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndThreateningPieceIsUnblockableThenCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
 
            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(whiteKingSquare);
            board.Stub(b => b.OtherTeamPieceSquares).Return(new HashSet<ISquare>());

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.ThreateningPieceIsUnblockable(threateningSquare, whiteKingSquare)).
                Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.True(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndAttackingMoveCanBeBlockedThenNoCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(whiteKingSquare);
            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
            board.Stub(bc => bc.OtherTeamPieceSquares).Return(cacheWhitePieces);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.
                Stub(c => c.LineOfSightToKingCanBeBlockedByFriendlyPiece(board, threateningSquare, whiteKingSquare, board.OtherTeamPieceSquares))
                .Return(true);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.False(inCheckMate);
        }

        [Test]
        public void IfWhiteKingAndBoardInCheckAndAllEscapeManagerMethodsReturnFalseThenCheckMate()
        {
            //Give board cache mocked white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            whiteKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(whiteKingSquare);
            HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
            board.Stub(bc => bc.OtherTeamPieceSquares).Return(cacheWhitePieces);
            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.True(inCheckMate);
        }


        //[Test]
        //public void IfBlackKingAndBoardInCheckAndKingCanEscapeThenNoCheckMate()
        //{
        //    //Give board cache mocked white king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    blackKing.Stub(wk => wk.InCheckState).Return(true);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);

        //    //square with threatening piece in
        //    IPiece threateningPiece = MockPiece();
        //    ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

        //    //give other king a mocked one in board cache
        //    IKing king = MockKing();
        //    ISquare otherKingSquare = MockSquareWithPiece(king);

        //    IBoard board = MockBoard();
        //    board.Stub(b => b.InCheck).Return(true);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    board.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

        //    ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
        //    checkMateEscapeManager.Stub(c => c.KingCanEscape(board, blackKingSquare)).Return(true);

        //    CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
        //    bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

        //    Assert.False(inCheckMate);
        //}

        //[Test]
        //public void IfBlackKingAndBoardInCheckAndThreateningPieceCanBeTakenThenNoCheckMate()
        //{
        //    //Give board cache mocked white king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    blackKing.Stub(wk => wk.InCheckState).Return(true);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);

        //    //square with threatening piece in
        //    IPiece threateningPiece = MockPiece();
        //    ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

        //    //give other king a mocked one in board cache
        //    IKing king = MockKing();
        //    ISquare otherKingSquare = MockSquareWithPiece(king);

        //    IBoard board = MockBoard();
        //    board.Stub(b => b.InCheck).Return(true);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    HashSet<ISquare> cacheWhitePieces = new HashSet<ISquare>();
        //    board.Stub(bc => bc.BlackPieceSquares).Return(cacheWhitePieces);
        //    board.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

        //    ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
        //    checkMateEscapeManager.Stub(c => c.ThreateningPieceCanBeCaptured(board.BlackPieceSquares, board, threateningSquare)).Return(true);

        //    CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
        //    bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

        //    Assert.False(inCheckMate);
        //}

        //[Test]
        //public void IfBlackKingAndBoardInCheckAndThreateningPieceIsUnblockableThenCheckMate()
        //{
        //    //Give board cache mocked white king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    blackKing.Stub(wk => wk.InCheckState).Return(true);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);

        //    //square with threatening piece in
        //    IPiece threateningPiece = MockPiece();
        //    ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

        //    //give other king a mocked one in board cache
        //    IKing king = MockKing();
        //    ISquare otherKingSquare = MockSquareWithPiece(king);

        //    IBoard board = MockBoard();
        //    board.Stub(b => b.InCheck).Return(true);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    board.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

        //    ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
        //    checkMateEscapeManager.Stub(c => c.ThreateningPieceIsUnblockable(threateningSquare, blackKingSquare)).Return(true);

        //    CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
        //    bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

        //    Assert.True(inCheckMate);
        //}

        //[Test]
        //public void IfBlackKingAndBoardInCheckAndAttackingMoveCanBeBlockedThenNoCheckMate()
        //{
        //    //Give board cache mocked white king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    blackKing.Stub(wk => wk.InCheckState).Return(true);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);

        //    //square with threatening piece in
        //    IPiece threateningPiece = MockPiece();
        //    ISquare threateningSquare = MockSquareWithPiece(threateningPiece);
        //    //give other king a mocked one in board cache
        //    IKing king = MockKing();
        //    ISquare otherKingSquare = MockSquareWithPiece(king);

        //    IBoard board = MockBoard();
        //    board.Stub(b => b.InCheck).Return(true);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    HashSet<ISquare> cacheBlackPieces = new HashSet<ISquare>();
        //    board.Stub(bc => bc.BlackPieceSquares).Return(cacheBlackPieces);
        //    board.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

        //    ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
        //    checkMateEscapeManager.Stub(c => c.LineOfSightToKingCanBeBlockedByFriendlyPiece(board, threateningSquare, blackKingSquare, board.BlackPieceSquares)).Return(true);

        //    CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
        //    bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

        //    Assert.False(inCheckMate);
        //}

        //[Test]
        //public void IfBlackKingAndBoardInCheckAndAllEscapeManagerMethodsReturnFalseThenCheckMate()
        //{
        //    //Give board cache mocked white king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    blackKing.Stub(wk => wk.InCheckState).Return(true);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);

        //    //square with threatening piece in
        //    IPiece threateningPiece = MockPiece();
        //    ISquare threateningSquare = MockSquareWithPiece(threateningPiece);
        //    //give other king a mocked one in board cache
        //    IKing king = MockKing();
        //    ISquare otherKingSquare = MockSquareWithPiece(king);

        //    IBoard board = MockBoard();
        //    board.Stub(b => b.InCheck).Return(true);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    HashSet<ISquare> cacheBlackPieces = new HashSet<ISquare>();
        //    board.Stub(bc => bc.BlackPieceSquares).Return(cacheBlackPieces);
        //    board.Stub(b => b.WhiteKingSquare).Return(otherKingSquare);

        //    ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();

        //    CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
        //    bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

        //    Assert.True(inCheckMate);
        //}

        /// <summary>
        /// This test ensures that the call order evaluating checkmate is both correct and optimal.
        /// We need to be sure that the king can't escape and the piece can't be taken before saying an unblockable piece means checkmate.
        /// Also the last stage is the most expensive since it requires checking every square between the king an attacker for a valid move
        /// for any of the pieces on the king's team. This is why it should be called last.
        /// </summary>
        [Test]
        public void TestOrderingOfCheckMateManagerCallsForBlackKing()
        {
            //Give board cache mocked white king
            IKing blackKing = MockKingWithColour(Colour.White);
            blackKing.Stub(wk => wk.InCheckState).Return(true);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);

            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            List<int> callOrder = new List<int>();
            int kingEscapeKey = 0;
            int captureKey = 1;
            int unblockableKey = 2;
            int blockAttackKey = 3;

            //Delegates used to add mocks to list
            Func<IBoard, ISquare, bool> addKingEscapeKey = (b, square) =>
            {
                callOrder.Add(kingEscapeKey);
                return false;
            };
            Func<HashSet<ISquare>, IBoard, ISquare, bool> addCaptureKey = (fs, b, square) =>
            {
                callOrder.Add(captureKey);
                return false;
            };
            Func<ISquare, ISquare, bool> addUnblockableKey = (square, square2) =>
            {
                callOrder.Add(unblockableKey);
                return false;
            };
            Func<IBoard, ISquare, ISquare, HashSet<ISquare>, bool> addBlockAttackKey = (b, s1, s2, fs) =>
            {
                callOrder.Add(blockAttackKey);
                return false;
            };

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.OtherTeamKingSquare).Return(blackKingSquare);
            HashSet<ISquare> cacheBlackPieces = new HashSet<ISquare>();
            board.Stub(bc => bc.OtherTeamPieceSquares).Return(cacheBlackPieces);

            ICheckMateEscapeManager checkMateEscapeManager = GenerateMock<ICheckMateEscapeManager>();
            checkMateEscapeManager.Stub(c => c.KingCanEscape(board, blackKingSquare))
                .Do(addKingEscapeKey);
            checkMateEscapeManager.Stub(c => c.ThreateningPieceCanBeCaptured(board.OtherTeamPieceSquares, board, threateningSquare))
                .Do(addCaptureKey);
            checkMateEscapeManager.Stub(c => c.ThreateningPieceIsUnblockable(threateningSquare, blackKingSquare))
                .Do(addUnblockableKey);
            checkMateEscapeManager.Stub(c => c.LineOfSightToKingCanBeBlockedByFriendlyPiece(board, threateningSquare, blackKingSquare, board.OtherTeamPieceSquares))
                .Do(addBlockAttackKey);

            CheckMateManager checkMateManager = new CheckMateManager(checkMateEscapeManager);
            bool inCheckMate = checkMateManager.BoardIsInCheckMate(board, threateningSquare);

            Assert.AreEqual(callOrder[0], kingEscapeKey);
            Assert.AreEqual(callOrder[1], captureKey);
            Assert.AreEqual(callOrder[2], unblockableKey);
            Assert.AreEqual(callOrder[3], blockAttackKey);
        }
    }
}
