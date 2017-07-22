using NUnit.Framework;
using ChessWithTDD.Tests.TestHelpers;

namespace ChessWithTDD.Tests
{
    /// <summary>
    /// Tests for algebraic notation parser. Each type of move should be tested for invalid moves by ensuring
    /// the return value is null
    /// </summary>
    [TestFixture]
    public class AlgebraicNotationParserTests
    {
        [Test, TestCaseSource(typeof(AlgebraicNotationParserTestParameters), "PawnMoveParseTestCases")]
        public void PawnMoveParse(string input, Move expectedMove)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(expectedMove, data.Move);
        }

        [Test, TestCaseSource(typeof(AlgebraicNotationParserTestParameters), "PawnInvalidMoveParseTestCases")]
        public void PawnMoveParseFails(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(null, data.Move);
        }

        [Test, TestCaseSource(typeof(AlgebraicNotationParserTestParameters), "NonPawnMoveParseTestCases")]
        public void NonPawnMoveParse(string input, Move expectedMove)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(expectedMove, data.Move);
        }

        [Test, TestCaseSource(typeof(AlgebraicNotationParserTestParameters), "NonPawnInvalidMoveParseTestCases")]
        public void NonPawnMoveParseFails(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(null, data.Move);
        }
    }
}
