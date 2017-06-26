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
            new object[] { "f2-f4", new Move(1, 5, 3, 5) }
        };
    }
}
