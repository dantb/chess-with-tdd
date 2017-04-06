using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CheckMateEscapeManagerTests
    {
        [TestCase(3, 3, 3, 4)]
        [TestCase(3, 3, 3, 2)]
        [TestCase(3, 3, 4, 3)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(3, 3, 4, 4)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(3, 3, 4, 2)]
        [TestCase(3, 3, 2, 4)]
        [Test]
        public void IfThereIsAValidMoveForKingThenReturnTrue(int kingRow, int kingCol, int adjacentRow, int adjacentCol)
        {
            IKing whiteKing = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(kingRow, kingCol, whiteKing);

            ISquare adjacentSquare = MockSquareWithoutPiece(adjacentRow, adjacentCol);
            IBoard board = MockBoard();
            board.Stub(b => b.GetSquare(adjacentSquare.Row, adjacentSquare.Col)).Return(adjacentSquare);
            board.Stub(b => b.MoveIsValid(whiteKingSquare, adjacentSquare)).Return(true);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool kingCanEscape = checkMateManager.KingCanEscape(board, whiteKingSquare);

            Assert.True(kingCanEscape);
        }

        [Test]
        public void IfNoMoveIsValidForKingThenReturnFalse()
        {
            IKing whiteKing = MockKingWithColour(Colour.White);
            ISquare whiteKingSquare = MockSquareWithPiece(whiteKing);
            IBoard board = MockBoard();

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool kingCanEscape = checkMateManager.KingCanEscape(board, whiteKingSquare);

            Assert.False(kingCanEscape);
        }

        [Test]
        public void IfAFriendlySquareCanTakeTheThreateningPieceReturnTrue()
        {
            IPiece friendlyPiece = MockPiece();
            ISquare friendlyPieceSquare = MockSquareWithPiece(friendlyPiece);
            HashSet<ISquare> friendlySquares = new HashSet<ISquare>() { friendlyPieceSquare };
            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(friendlyPieceSquare, threateningSquare)).Return(true);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool canTakePiece = checkMateManager.ThreateningPieceCanBeCaptured(friendlySquares, board, threateningSquare);

            Assert.True(canTakePiece);
        }

        [Test]
        public void IfNoFriendlySquareCanTakeTheThreateningPieceReturnFalse()
        {
            IPiece friendlyPiece = MockPiece();
            ISquare friendlyPieceSquare = MockSquareWithPiece(friendlyPiece);
            HashSet<ISquare> friendlySquares = new HashSet<ISquare>() { friendlyPieceSquare };
            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningSquare = MockSquareWithPiece(threateningPiece);

            IBoard board = MockBoard();
            board.Stub(b => b.MoveIsValid(friendlyPieceSquare, threateningSquare)).Return(false);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool canTakePiece = checkMateManager.ThreateningPieceCanBeCaptured(friendlySquares, board, threateningSquare);

            Assert.False(canTakePiece);
        }

        [TestCase(3, 3, 5, 5)]
        [TestCase(4, 4, 2, 3)]
        [Test]
        public void IfTheThreateningPieceIsAKnightButNotAdjacentItIsUnblockable(int kingRow, int kingCol, int threatRow, int threatCol)
        {
            IKing king = MockKing();
            ISquare kingSquare = MockSquareWithPiece(kingRow, kingCol, king);
            //square with threatening piece in
            IKnight threateningKnight = MockKnight();
            ISquare threateningKnightSquare = MockSquareWithPiece(threatRow, threatCol, threateningKnight);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool isUnblockable = checkMateManager.ThreateningPieceIsUnblockable(threateningKnightSquare, kingSquare);

            Assert.True(isUnblockable);
        }

        [TestCase(3, 3, 3, 4)]
        [TestCase(3, 3, 4, 3)]
        [TestCase(3, 3, 3, 2)]
        [TestCase(3, 3, 2, 3)]
        [TestCase(3, 3, 4, 4)]
        [TestCase(3, 3, 2, 2)]
        [TestCase(3, 3, 4, 2)]
        [TestCase(3, 3, 2, 4)]
        [Test]
        public void IfTheThreateningPieceNotAKnightButIsAdjacentItIsUnblockable(int kingRow, int kingCol, int threatRow, int threatCol)
        {
            IKing king = MockKing();
            ISquare kingSquare = MockSquareWithPiece(kingRow, kingCol, king);
            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningPieceSquare = MockSquareWithPiece(threatRow, threatCol, threateningPiece);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool isUnblockable = checkMateManager.ThreateningPieceIsUnblockable(threateningPieceSquare, kingSquare);

            Assert.True(isUnblockable);
        }

        [TestCase(3, 3, 5, 5)]
        [TestCase(4, 4, 2, 3)]
        [Test]
        public void IfTheThreateningPieceNotAKnightAndNotAdjacentItIsNotUnblockable(int kingRow, int kingCol, int threatRow, int threatCol)
        {
            IKing king = MockKing();
            ISquare kingSquare = MockSquareWithPiece(kingRow, kingCol, king);
            //square with threatening piece in
            IPiece threateningPiece = MockPiece();
            ISquare threateningPieceSquare = MockSquareWithPiece(threatRow, threatCol, threateningPiece);

            CheckMateEscapeManager checkMateManager = new CheckMateEscapeManager();
            bool isUnblockable = checkMateManager.ThreateningPieceIsUnblockable(threateningPieceSquare, kingSquare);

            Assert.False(isUnblockable);
        }
    }
}
