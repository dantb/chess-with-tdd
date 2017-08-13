using ChessWithTDD;
using DeepCopyExtensions;
using NUnit.Framework;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    /// <summary>
    /// Performs various system tests and clones the board to ensure that the deep copy is working correctly
    /// </summary>
    [TestFixture]
    public class DeepCopyByExpressionTreesTests
    {
        private const string GeneralTestsFolder = "GeneralTests";
        private const string FullGamePlayingTheEngineFile = "FullGamePlayingTheEngine.txt";

        [Test]
        public void DeepCopyDoesNotCopyByReferenceAtAnyDepth()
        {
            string path = GetPositionFilePath(GeneralTestsFolder, FullGamePlayingTheEngineFile);

            IBoard board = NewBoard();
            IBoard clonedBoardFromScratch = board.DeepCopyByExpressionTree();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            /***
            check that the cloned board hasn't changed, since there should be no references
            ***/

            // check that it's the white team's turn and turn counter is 0
            Assert.AreEqual(clonedBoardFromScratch.TeamWithTurn, Colour.White);
            Assert.AreEqual(0, clonedBoardFromScratch.TurnCounter);

            // let's see if the white queen has moved
            ISquare whiteQueenSquare = clonedBoardFromScratch.GetSquare(0, 3);
            Assert.True(whiteQueenSquare.ContainsPiece);
            Assert.True(whiteQueenSquare.Piece is Queen);
            Assert.True(whiteQueenSquare.Piece.Colour == Colour.White);

            // let's see if the black king has moved, using the board cache
            ISquare blackKingSquare = clonedBoardFromScratch.OtherTeamKingSquare;
            Assert.True(blackKingSquare.Piece is King);
            Assert.False((blackKingSquare.Piece as King).HasMoved);
        }

        [Test]
        public void DeepCopyCopiesSquareAndBoardStateCorrectly()
        {
            string path = GetPositionFilePath(GeneralTestsFolder, FullGamePlayingTheEngineFile);

            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            /***
              let's get a clone of the board now and check that the state is correct
            ***/

            IBoard clonedBoardAfterGame = board.DeepCopyByExpressionTree();

            // board in checkmate
            Assert.True(clonedBoardAfterGame.InCheck);
            Assert.True(clonedBoardAfterGame.CheckMate);

            // get black king out of board cache and verify that is in check, and the same as the one on the board
            ISquare checkedBlackKingSquareFromBoardCache = clonedBoardAfterGame.MovingTeamKingSquare;
            ISquare checkedBlackKingSquareFromBoardDirectly = clonedBoardAfterGame.GetSquare(7, 5);
            Assert.AreEqual(checkedBlackKingSquareFromBoardDirectly, checkedBlackKingSquareFromBoardCache);
            Assert.AreEqual(checkedBlackKingSquareFromBoardDirectly.Piece, checkedBlackKingSquareFromBoardCache.Piece);
            Assert.True((checkedBlackKingSquareFromBoardCache.Piece as King).InCheckState);
        }

        [Test]
        public void DeepCopyIsUsableAfterCloningOccurs()
        {
            string path = GetPositionFilePath(GeneralTestsFolder, FullGamePlayingTheEngineFile);

            IBoard board = NewBoard();
            IBoard clonedBoardFromScratch = board.DeepCopyByExpressionTree();

            // this time load the position into the cloned board, and assert the same things as before
            PositionLoaderService.LoadPositionIntoBoard(clonedBoardFromScratch, path);

            // board in checkmate
            Assert.True(clonedBoardFromScratch.InCheck);
            Assert.True(clonedBoardFromScratch.CheckMate);

            // get black king out of board cache and verify that is in check, and the same as the one on the board
            ISquare checkedBlackKingSquareFromBoardCache = clonedBoardFromScratch.MovingTeamKingSquare;
            ISquare checkedBlackKingSquareFromBoardDirectly = clonedBoardFromScratch.GetSquare(7, 5);
            Assert.AreEqual(checkedBlackKingSquareFromBoardDirectly, checkedBlackKingSquareFromBoardCache);
            Assert.AreEqual(checkedBlackKingSquareFromBoardDirectly.Piece, checkedBlackKingSquareFromBoardCache.Piece);
            Assert.True((checkedBlackKingSquareFromBoardCache.Piece as King).InCheckState);
        }
    }
}
