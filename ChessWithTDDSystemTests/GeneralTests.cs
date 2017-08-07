using ChessWithTDD;
using NUnit.Framework;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class GeneralTests
    {
        private const string GeneralTestsFolder = "GeneralTests";
        private const string BlackKingBeforeMovingInFrontOfWhitePawnFile = "BlackKingBeforeMovingInFrontOfWhitePawn.txt";

        [Test]
        public void BlackKingBeforeMovingInFrontOfWhitePawn()
        {
            string path = GetPositionFilePath(GeneralTestsFolder, BlackKingBeforeMovingInFrontOfWhitePawnFile);
            IBoard board = NewBoard();

            PositionLoaderService.LoadPositionIntoBoard(board, path);

            ISquare blackKingSquare = board.GetSquare(6, 4);

            // check black king can move in front of pawn
            ISquare squareInFrontOfPawn = board.GetSquare(5, 4);
            Assert.True(board.MoveIsValid(blackKingSquare, squareInFrontOfPawn));

            // check black king cannot move to left diagonal of pawn
            ISquare leftDiagonalOfPawnSquare = board.GetSquare(5, 3);
            Assert.False(board.MoveIsValid(blackKingSquare, leftDiagonalOfPawnSquare));

            // check black king cannot move to right diagonal of pawn
            ISquare rightDiagonalOfPawnSquare = board.GetSquare(5, 5);
            Assert.False(board.MoveIsValid(blackKingSquare, rightDiagonalOfPawnSquare));
        }
    }
}
