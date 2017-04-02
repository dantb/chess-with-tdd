using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD.Tests.BoardDependencies
{
    [TestFixture]
    public class BoardCacheTests
    {
        [Test]
        public void BlackKingIsSavedToBlackKingSquareIfInPendingUpdatesOfBoardAndUpdatesCleared()
        {
            IKing theKing = MockKingWithColour(Colour.Black);
            ISquare kingSquare = MockSquareWithPiece(theKing);
            IBoard board = MockBoard();
            List<ISquare> pendingUpdates = new List<ISquare> { kingSquare };
            board.Stub(b => b.PendingUpdates).Return(pendingUpdates);
            board.Stub(b => b.GetSquare(kingSquare.Row, kingSquare.Col)).Return(kingSquare);

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);
            boardCache.UpdateBoardCache();

            Assert.AreEqual(boardCache.BlackKingSquare, kingSquare);
            Assert.AreEqual(pendingUpdates.Count, 0);
        }

        [Test]
        public void WhiteKingIsSavedToWhiteKingSquareIfInPendingUpdatesOfBoardAndUpdatesCleared()
        {
            IKing theKing = MockKingWithColour(Colour.White);
            ISquare kingSquare = MockSquareWithPiece(theKing);
            IBoard board = MockBoard();
            List<ISquare> pendingUpdates = new List<ISquare> { kingSquare };
            board.Stub(b => b.PendingUpdates).Return(pendingUpdates);
            board.Stub(b => b.GetSquare(kingSquare.Row, kingSquare.Col)).Return(kingSquare);

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);
            boardCache.UpdateBoardCache();

            Assert.AreEqual(boardCache.WhiteKingSquare, kingSquare);
            Assert.AreEqual(pendingUpdates.Count, 0);
        }

        [Test]
        public void NothingIsSavedForSquaresWithNoPieceAndItIsNotRemoved()
        {
            ISquare square = MockSquare();
            IBoard board = MockBoard();
            List<ISquare> pendingUpdates = new List<ISquare> { square };
            board.Stub(b => b.PendingUpdates).Return(pendingUpdates);

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);
            boardCache.UpdateBoardCache();

            Assert.IsNull(boardCache.WhiteKingSquare);
            Assert.IsNull(boardCache.BlackKingSquare);
            Assert.True(board.PendingUpdates.Contains(square));
        }

        [Test]
        public void BoardCacheInitialisedWithCorrectBoard()
        {
            IBoard board = MockBoard();

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);

            Assert.AreEqual(boardCache.TheBoard, board);
        }

        [Test]
        public void BoardCacheInitialisedWithWhiteKingCorrectly()
        {
            IKing king = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(WHITE_BACK_ROW, KING_COLUMN, king);
            IBoard board = MockBoard();
            board.Stub(b => b.GetSquare(WHITE_BACK_ROW, KING_COLUMN)).Return(whiteKingSquare);

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);

            Assert.AreEqual(boardCache.WhiteKingSquare, whiteKingSquare);
        }
        [Test]
        public void BoardCacheInitialisedWithBlackKingCorrectly()
        {
            IKing king = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(BLACK_BACK_ROW, KING_COLUMN, king);
            IBoard board = MockBoard();
            board.Stub(b => b.GetSquare(BLACK_BACK_ROW, KING_COLUMN)).Return(blackKingSquare);

            BoardCache boardCache = new BoardCache();
            boardCache.InitialiseBoardCache(board);

            Assert.AreEqual(boardCache.BlackKingSquare, blackKingSquare);
        }
    }
}
