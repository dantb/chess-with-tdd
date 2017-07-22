using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;


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
            board.Stub(b => b.MovingTeamKingSquare).Return(whiteKingSquare);
            //set up enemy black piece
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare blackPieceSquare = MockSquareWithPiece(blackPiece);
            board.Stub(b => b.OtherTeamPieceSquares).Return(new HashSet<ISquare>() { blackPieceSquare });
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
            board.Stub(b => b.MovingTeamKingSquare).Return(whiteKingSquare);
            //set up enemy black piece
            IPiece blackPiece = MockPieceWithColour(Colour.Black);
            ISquare blackPieceSquare = MockSquareWithPiece(blackPiece);
            board.Stub(b => b.OtherTeamPieceSquares).Return(new HashSet<ISquare>() { blackPieceSquare });
            //set up to square so black piece can move to it
            ISquare toSquare = MockSquare();
            board.Stub(b => b.MoveIsValid(blackPieceSquare, toSquare)).Return(false);
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

            bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, whiteKingSquare, toSquare);

            board.AssertWasCalled(b => b.MoveIsValid(blackPieceSquare, toSquare));
            Assert.False(intoCheck);
        }

        //[Test]
        //public void MovingBlackKingIntoCheckReturnsTrue()
        //{
        //    IBoard board = MockBoard();
        //    //set up black king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    //set up enemy white piece
        //    IPiece whitePiece = MockPieceWithColour(Colour.White);
        //    ISquare whitePieceSquare = MockSquareWithPiece(whitePiece);
        //    board.Stub(b => b.WhitePieceSquares).Return(new HashSet<ISquare>() { whitePieceSquare });
        //    //set up to square so white piece can move to it
        //    ISquare toSquare = MockSquare();
        //    board.Stub(b => b.MoveIsValid(whitePieceSquare, toSquare)).Return(true);
        //    MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

        //    bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, blackKingSquare, toSquare);

        //    board.AssertWasCalled(b => b.MoveIsValid(whitePieceSquare, toSquare));
        //    Assert.True(intoCheck);
        //}

        //[Test]
        //public void MovingBlackKingNotIntoCheckReturnsFalse()
        //{
        //    IBoard board = MockBoard();
        //    //set up black king
        //    IKing blackKing = MockKingWithColour(Colour.Black);
        //    ISquare blackKingSquare = MockSquareWithPiece(blackKing);
        //    board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
        //    //set up enemy white piece
        //    IPiece whitePiece = MockPieceWithColour(Colour.White);
        //    ISquare whitePieceSquare = MockSquareWithPiece(whitePiece);
        //    board.Stub(b => b.WhitePieceSquares).Return(new HashSet<ISquare>() { whitePieceSquare });
        //    //set up to square so white piece can move to it
        //    ISquare toSquare = MockSquare();
        //    board.Stub(b => b.MoveIsValid(whitePieceSquare, toSquare)).Return(false);
        //    MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

        //    bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, blackKingSquare, toSquare);

        //    board.AssertWasCalled(b => b.MoveIsValid(whitePieceSquare, toSquare));
        //    Assert.False(intoCheck);
        //}

        //[TestCase(1, 1, 2, 2)]
        //[Test]
        //public void MovingWhitePieceSoThatWhiteKingIsInCheckReturnsTrue(int rowFrom, int colFrom, int rowTo, int colTo)
        //{
        //    IBoard board = MockBoard();
        //    //set up white king
        //    IKing whiteKing = MockKingWithColour(Colour.White);
        //    ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
        //    board.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
        //    //set up moving white piece
        //    IPiece whitePiece = MockPieceWithColour(Colour.White);
        //    ISquare whitePieceSquare = MockSquareWithPiece(rowFrom, colFrom, whitePiece);
        //    whitePieceSquare.Stub(w => w.Row).Return(rowFrom);
        //    whitePieceSquare.Stub(w => w.Col).Return(colFrom);
        //    board.Stub(b => b.GetSquare(rowFrom, colFrom)).Return(whitePieceSquare);
        //    //set up enemy black piece
        //    IPiece blackPiece = MockPieceWithColour(Colour.Black);
        //    ISquare blackPieceSquare = MockSquareWithPiece(blackPiece);
        //    board.Stub(b => b.BlackPieceSquares).Return(new HashSet<ISquare>() { blackPieceSquare });
        //    board.Stub(b => b.MoveIsValid(blackPieceSquare, whiteKingSquare)).Return(true);
        //    //square white piece is moving to
        //    IPiece pieceInToSquare = MockPiece();
        //    ISquare toSquare = MockSquareWithPiece(pieceInToSquare);
        //    toSquare.Stub(t => t.Row).Return(rowTo);
        //    toSquare.Stub(t => t.Col).Return(colTo);
        //    board.Stub(b => b.GetSquare(rowTo, colTo)).Return(toSquare);

        //    MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();

        //    //need move of black piece to be valid to white king, but only after white piece is moved
        //    bool intoCheck = moveIntoCheckValidator.MoveIsIntoCheck(board, whitePieceSquare, toSquare);

        //    //assert that piece was temporarily moved to new position
        //    toSquare.AssertWasCalled(t => t.Piece = whitePiece);
        //    toSquare.AssertWasCalled(t => t.ContainsPiece = true);
        //    whitePieceSquare.AssertWasCalled(t => t.ContainsPiece = false);
        //    whitePieceSquare.AssertWasCalled(t => t.Piece = null);
        //    //and back again
        //    toSquare.AssertWasCalled(t => t.Piece = pieceInToSquare);
        //    toSquare.AssertWasCalled(t => t.ContainsPiece = true);
        //    whitePieceSquare.AssertWasCalled(t => t.ContainsPiece = true);
        //    whitePieceSquare.AssertWasCalled(t => t.Piece = whitePiece);
        //    board.AssertWasCalled(b => b.MoveIsValid(blackPieceSquare, whiteKingSquare));
        //    Assert.True(intoCheck);
        //}
    }
}
