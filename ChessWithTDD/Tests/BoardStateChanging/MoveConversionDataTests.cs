using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveConversionDataTests
    {
        /// <summary>
        /// This is a DTO so we're only testing the constructor. Tests the non trivial constructor that has some logic in it.
        /// </summary>
        [TestCase(1, 2, 3, 4, false, false)]
        [TestCase(5, 6, 7, 8, false, true)]
        [TestCase(2, 3, 4, 5, true, false)]
        [TestCase(0, 0, 0, 0, true, true)]
        [Test]
        public void NonTrivialConstructorTest(int rowFrom, int colFrom, int rowTo, int colTo, bool check, bool checkMate)
        {
            ISquare fromSquare = MockSquare(rowFrom, colFrom);
            ISquare toSquare = MockSquare(rowTo, colTo);
            IBoard board = MockBoardWithCheckAndMateStates(check, checkMate);

            MoveConversionData data = new MoveConversionData(fromSquare, toSquare, board);

            Assert.That(data.Move.FromRow == rowFrom && data.Move.FromCol == colFrom);
            Assert.That(data.Move.ToRow == rowTo && data.Move.ToCol == colTo);
            Assert.AreEqual(data.Check, check);
            Assert.AreEqual(data.CheckMate, checkMate);
        }

        /// <summary>
        /// This is a DTO so we're only testing the constructor. Trivial constructor setting directly from arguments.
        /// </summary>
        [TestCase(1, 2, 3, 4, false, false)]
        [TestCase(5, 6, 7, 8, false, true)]
        [TestCase(2, 3, 4, 5, true, false)]
        [TestCase(0, 0, 0, 0, true, true)]
        [Test]
        public void SimpleConstructorTest(int rowFrom, int colFrom, int rowTo, int colTo, bool check, bool checkMate)
        {
            Move move = new Move(rowFrom, colFrom, rowTo, colTo);

            MoveConversionData data = new MoveConversionData(move, check, checkMate);

            Assert.That(data.Move.FromRow == rowFrom && data.Move.FromCol == colFrom);
            Assert.That(data.Move.ToRow == rowTo && data.Move.ToCol == colTo);
            Assert.AreEqual(data.Check, check);
            Assert.AreEqual(data.CheckMate, checkMate);
        }
    }
}
