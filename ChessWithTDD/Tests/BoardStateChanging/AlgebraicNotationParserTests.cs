using NUnit.Framework;

namespace ChessWithTDD.Tests
{
    /// <summary>
    /// Tests for algebraic notation parser. Each type of move should be tested for invalid moves by ensuring
    /// the return value is null
    /// </summary>
    [TestFixture]
    public class AlgebraicNotationParserTests
    {
        [Test, TestCaseSource("PawnMoveParseTestCases")]
        public void PawnMoveParse(string input, IMove expectedMove)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            IMove move = parser.Parse(input);

            Assert.AreEqual(expectedMove, move);
        }

        static object[] PawnMoveParseTestCases =
        {
            //double move up
            new object[] { "a2-a4", new Move(1, 0, 3, 0) },
            new object[] { "b2-b4", new Move(1, 1, 3, 1) },
            new object[] { "c2-c4", new Move(1, 2, 3, 2) },
            new object[] { "d2-d4", new Move(1, 3, 3, 3) },
            new object[] { "e2-e4", new Move(1, 4, 3, 4) },
            new object[] { "f2-f4", new Move(1, 5, 3, 5) },
            new object[] { "g2-g4", new Move(1, 6, 3, 6) },
            new object[] { "h2-h4", new Move(1, 7, 3, 7) },

            //double move down
            new object[] { "a7-a5", new Move(6, 0, 4, 0) },
            new object[] { "b7-b5", new Move(6, 1, 4, 1) },
            new object[] { "c7-c5", new Move(6, 2, 4, 2) },
            new object[] { "d7-d5", new Move(6, 3, 4, 3) },
            new object[] { "e7-e5", new Move(6, 4, 4, 4) },
            new object[] { "f7-f5", new Move(6, 5, 4, 5) },
            new object[] { "g7-g5", new Move(6, 6, 4, 6) },
            new object[] { "h7-h5", new Move(6, 7, 4, 7) },

            //single move up
            new object[] { "a2-a3", new Move(1, 0, 2, 0) },
            new object[] { "b2-b3", new Move(1, 1, 2, 1) },
            new object[] { "c2-c3", new Move(1, 2, 2, 2) },
            new object[] { "d2-d3", new Move(1, 3, 2, 3) },
            new object[] { "e2-e3", new Move(1, 4, 2, 4) },
            new object[] { "f2-f3", new Move(1, 5, 2, 5) },
            new object[] { "g2-g3", new Move(1, 6, 2, 6) },
            new object[] { "h2-h3", new Move(1, 7, 2, 7) },

            //single move down
            new object[] { "a7-a6", new Move(6, 0, 5, 0) },
            new object[] { "b7-b6", new Move(6, 1, 5, 1) },
            new object[] { "c7-c6", new Move(6, 2, 5, 2) },
            new object[] { "d7-d6", new Move(6, 3, 5, 3) },
            new object[] { "e7-e6", new Move(6, 4, 5, 4) },
            new object[] { "f7-f6", new Move(6, 5, 5, 5) },
            new object[] { "g7-g6", new Move(6, 6, 5, 6) },
            new object[] { "h7-h6", new Move(6, 7, 5, 7) },
        };
    }
}
