using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;
using static Rhino.Mocks.MockRepository;
using Rhino.Mocks;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CheckManagerTests
    {
        [Test]
        public void IfWhitePieceMovedToCheckTheBlackKingThenBoardAndBlackKingPutInCheckState()
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, blackKingSquare)).Return(true);
            board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = true);
            blackKing.AssertWasCalled(b => b.InCheckState = true);
            checkMateManager.AssertWasCalled(cmm => cmm.BoardIsInCheckMate(board, toSquare));
        }

        [TestCase(true)]
        [TestCase(false)]
        [Test]
        public void IfWhitePieceMovedToCheckTheBlackKingThenCheckMateManagerCalledAndBoardCheckMateStateSetToValue(bool checkMate)
        {
            //Give board cache mocked black king
            IKing blackKing = MockKingWithColour(Colour.Black);
            ISquare blackKingSquare = MockSquareWithPiece(blackKing);

            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.White);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, blackKingSquare)).Return(true);
            board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            checkMateManager.Stub(cmm => cmm.BoardIsInCheckMate(board, toSquare)).Return(checkMate);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

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

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, whiteKingSquare)).Return(true);
            board.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

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

            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Black);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            //Move from to square to king square must be valid
            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(toSquare, whiteKingSquare)).Return(true);
            board.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            checkMateManager.Stub(cmm => cmm.BoardIsInCheckMate(board, toSquare)).Return(checkMate);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

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
            //Give black king square a piece although we don't care about it
            IKing king = MockKing();
            ISquare square = MockSquareWithPiece(king);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            //Don't care about square, stop add check states from causing problems
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Invalid);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.WhiteKingSquare).Return(whiteKingSquare);
            board.Stub(b => b.BlackKingSquare).Return(square);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

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
            //Give white king square a piece although we don't care about it
            IKing king = MockKing();
            ISquare square = MockSquareWithPiece(king);

            ICheckMateManager checkMateManager = GenerateMock<ICheckMateManager>();
            //Don't care about square, stop add check states from causing problems
            IPiece pieceThatJustMoved = MockPieceWithColour(Colour.Invalid);
            ISquare toSquare = MockSquareWithPiece(pieceThatJustMoved);

            IBoard board = MockBoard();
            board.Stub(b => b.InCheck).Return(true);
            board.Stub(b => b.BlackKingSquare).Return(blackKingSquare);
            board.Stub(b => b.WhiteKingSquare).Return(square);

            CheckManager checkManager = new CheckManager(checkMateManager);
            checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

            board.AssertWasCalled(b => b.InCheck = false);
            blackKing.AssertWasCalled(b => b.InCheckState = false);
        }     
    }
}
