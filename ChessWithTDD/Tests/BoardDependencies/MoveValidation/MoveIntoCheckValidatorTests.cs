using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;


namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveIntoCheckValidatorTests
    {
        [Test]
        public void MovingWhiteKingIntoCheckReturnsTrue()
        {
            IBoard board = MockBoard();
            //set up white king
            IKing whiteKing = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            board.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            //set up enemy black piece
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare blackPieceSquare = MockSquareWithPiece(blackPiece);
            board.Stub(b => b.BlackPieceSquares).Return(new HashSet<ISquare>() { blackPieceSquare });
            //set up to square so black piece can move to it
            ISquare toSquare = MockSquare();
            board.Stub(b => b.MoveIsValid(blackPieceSquare, toSquare));
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, whiteKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(blackPieceSquare, toSquare));
            Assert.True(intoCheck);
        }

    }
}
