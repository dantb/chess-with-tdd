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
            board.Stub(b => b.MoveIsValid(blackPieceSquare, toSquare)).Return(true);
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, whiteKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(blackPieceSquare, toSquare));
            Assert.True(intoCheck);
        }

        [Test]
        public void MovingWhiteKingNotIntoCheckReturnsFalse()
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
            board.Stub(b => b.MoveIsValid(blackPieceSquare, toSquare)).Return(false);
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, whiteKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(blackPieceSquare, toSquare));
            Assert.False(intoCheck);
        }

        [Test]
        public void MovingBlackKingIntoCheckReturnsTrue()
        {
            IBoard board = MockBoard();
            //set up black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            //set up enemy white piece
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare whitePieceSquare = MockSquareWithPiece(whitePiece);
            board.Stub(b => b.WhitePieceSquares).Return(new HashSet<ISquare>() { whitePieceSquare });
            //set up to square so black piece can move to it
            ISquare toSquare = MockSquare();
            board.Stub(b => b.MoveIsValid(whitePieceSquare, toSquare)).Return(true);
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, blackKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(whitePieceSquare, toSquare));
            Assert.True(intoCheck);
        }

        [Test]
        public void MovingBlackKingNotIntoCheckReturnsFalse()
        {
            IBoard board = MockBoard();
            //set up black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);
            board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            //set up enemy white piece
            IPiece whitePiece = MockPieceWithColour(Colour.White);
            ISquare whitePieceSquare = MockSquareWithPiece(whitePiece);
            board.Stub(b => b.WhitePieceSquares).Return(new HashSet<ISquare>() { whitePieceSquare });
            //set up to square so black piece can move to it
            ISquare toSquare = MockSquare();
            board.Stub(b => b.MoveIsValid(whitePieceSquare, toSquare)).Return(false);
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, blackKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(whitePieceSquare, toSquare));
            Assert.False(intoCheck);
        }
    }
}
