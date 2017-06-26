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
            new object[] { "f2-f4", new Move(1, 5, 3, 5) },
            new object[] { "e2-e4", new Move(1, 4, 3, 4) },
            new object[] { "a5-a6", new Move(4, 0, 5, 0) }
        };
    }
}
