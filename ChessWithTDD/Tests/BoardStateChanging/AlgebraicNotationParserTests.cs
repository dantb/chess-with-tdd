using ChessWithTDD.Tests.TestHelpers;
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

        [TestCase("a2-a4+")]
        [TestCase("d7-d5+")]
        [TestCase("c2-c3+")]
        [TestCase("f2xg3+")]
        [Test]
        public void PawnMoveCheckTrueMateFalse(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(true, data.Check);
            Assert.AreEqual(false, data.CheckMate);
        }

        [TestCase("a2-a4")]
        [TestCase("d7-d5")]
        [TestCase("c2-c3")]
        [TestCase("f2xg3")]
        [Test]
        public void PawnMoveCheckAndMateFalse(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(false, data.Check);
            Assert.AreEqual(false, data.CheckMate);
        }

        [TestCase("a2-a4#")]
        [TestCase("d7-d5#")]
        [TestCase("c2-c3#")]
        [TestCase("f2xg3#")]
        [Test]
        public void PawnMoveCheckAndMateTrue(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(true, data.Check);
            Assert.AreEqual(true, data.CheckMate);
        }

        [TestCase("Ka2-a4+")]
        [TestCase("Bd7-d5+")]
        [TestCase("Rc2-c3+")]
        [TestCase("Qf2xg3+")]
        [Test]
        public void NonPawnMoveCheckTrueMateFalse(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(true, data.Check);
            Assert.AreEqual(false, data.CheckMate);
        }

        [TestCase("Ka2-a4")]
        [TestCase("Bd7-d5")]
        [TestCase("Rc2-c3")]
        [TestCase("Qf2xg3")]
        [Test]
        public void NonPawnMoveCheckAndMateFalse(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(false, data.Check);
            Assert.AreEqual(false, data.CheckMate);
        }

        [TestCase("Ka2-a4#")]
        [TestCase("Bd7-d5#")]
        [TestCase("Rc2-c3#")]
        [TestCase("Qf2xg3#")]
        [Test]
        public void NonPawnMoveCheckAndMateTrue(string input)
        {
            AlgebraicNotationParser parser = new AlgebraicNotationParser();

            MoveConversionData data = parser.Parse(input);

            Assert.AreEqual(true, data.Check);
            Assert.AreEqual(true, data.CheckMate);
        }
    }
}
