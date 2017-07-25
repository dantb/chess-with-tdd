using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveGenerationDataTests
    {
        /// <summary>
        /// This is a DTO so we're only testing the constructor. Tests the non trivial constructor that has some logic in it.
        /// </summary>
        [TestCase(1, 2, 3, 4, false, false, false)]
        [TestCase(5, 6, 7, 8, false, true, true)]
        [TestCase(2, 3, 4, 5, true, false, false)]
        [TestCase(0, 0, 0, 0, true, true, true)]
        [Test]
        public void NonTrivialConstructorTest(int rowFrom, int colFrom, int rowTo, int colTo, 
            bool check, bool checkMate, bool capture)
        {
            ISquare fromSquare = MockSquare(rowFrom, colFrom);
            ISquare toSquare = MockSquare(rowTo, colTo);
            toSquare.Stub(s => s.ContainsPiece).Return(capture);
            IBoard board = MockBoardWithCheckAndMateStates(check, checkMate);
            IPiece piece = MockPiece();

            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, board, piece);

            Assert.That(data.Move.FromRow == rowFrom && data.Move.FromCol == colFrom);
            Assert.That(data.Move.ToRow == rowTo && data.Move.ToCol == colTo);
            Assert.AreEqual(data.Check, check);
            Assert.AreEqual(data.CheckMate, checkMate);
            Assert.AreEqual(data.Piece, piece);
            Assert.AreEqual(data.Capture, capture);
        }

        /// <summary>
        /// This is a DTO so we're only testing the constructor. Trivial constructor setting directly from arguments.
        /// </summary>
        [TestCase(1, 2, 3, 4, false, false, false)]
        [TestCase(5, 6, 7, 8, false, true, true)]
        [TestCase(2, 3, 4, 5, true, false, false)]
        [TestCase(0, 0, 0, 0, true, true, true)]
        [Test]
        public void SimpleConstructorTest(int rowFrom, int colFrom, int rowTo, int colTo, 
            bool check, bool checkMate, bool capture)
        {
            Move move = new Move(rowFrom, colFrom, rowTo, colTo);
            IPiece piece = MockPiece();

            MoveGenerationData data = new MoveGenerationData(move, check, checkMate, piece, capture);

            Assert.That(data.Move.FromRow == rowFrom && data.Move.FromCol == colFrom);
            Assert.That(data.Move.ToRow == rowTo && data.Move.ToCol == colTo);
            Assert.AreEqual(data.Check, check);
            Assert.AreEqual(data.CheckMate, checkMate);
            Assert.AreEqual(data.Piece, piece);
            Assert.AreEqual(data.Capture, capture);
        }
    }
}

