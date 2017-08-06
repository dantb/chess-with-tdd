using ChessWithTDD;
using NUnit.Framework;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class PawnPromotionTests
    {
        private const string PawnPromotionFolder = "PawnPromotion";
        private const string BlackPawnPromotionFile = "BlackPawnPromotion.txt";
        private const string WhitePawnPromotionFile = "WhitePawnPromotion.txt";
        private const string WhitePawnPromotionCausingCheckMateInSixTurnsFile = "WhitePawnPromotionCausingCheckMateInSixTurns.txt";

        [Test]
        public void BlackPawnPromotion()
        {
            string path = GetPositionFilePath(PawnPromotionFolder, BlackPawnPromotionFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check pawn has been promoted to a black queen
            ISquare newQueenSquare = board.GetSquare(0, 1);
            Assert.True(newQueenSquare.ContainsPiece);
            Assert.True(newQueenSquare.Piece is Queen);
            Assert.True(newQueenSquare.Piece.Colour == Colour.Black);

            // check no piece in previous square
            ISquare oldPawnSquare = board.GetSquare(1, 1);
            Assert.False(oldPawnSquare.ContainsPiece);
        }

        [Test]
        public void WhitePawnPromotion()
        {
            string path = GetPositionFilePath(PawnPromotionFolder, WhitePawnPromotionFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check pawn has been promoted to a white queen
            ISquare newQueenSquare = board.GetSquare(7, 6);
            Assert.True(newQueenSquare.ContainsPiece);
            Assert.True(newQueenSquare.Piece is Queen);
            Assert.True(newQueenSquare.Piece.Colour == Colour.White);

            // check no piece in previous square
            ISquare oldPawnSquare = board.GetSquare(6, 6);
            Assert.False(oldPawnSquare.ContainsPiece);
        }

        [Test]
        public void WhitePawnPromotionCausingCheckMateInSixTurns()
        {
            string path = GetPositionFilePath(PawnPromotionFolder, WhitePawnPromotionCausingCheckMateInSixTurnsFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            // check pawn has been promoted to a white queen
            ISquare newQueenSquare = board.GetSquare(7, 2);
            Assert.True(newQueenSquare.ContainsPiece);
            Assert.True(newQueenSquare.Piece is Queen);
            Assert.True(newQueenSquare.Piece.Colour == Colour.White);

            // check no piece in previous square
            ISquare oldPawnSquare = board.GetSquare(6, 1);
            Assert.False(oldPawnSquare.ContainsPiece);

            // check the board is in check and check mate
            Assert.True(board.InCheck);
            Assert.True(board.CheckMate);
        }
    }
}
