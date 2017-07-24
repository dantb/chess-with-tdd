using NUnit.Framework;
using ChessWithTDD.Tests.TestHelpers;

namespace ChessWithTDD.Tests
{
    /// <summary>
    /// Tests for algebraic notation generator. Every piece type should be tested, plus the case when an
    /// invalid move is provided - an empty string should be returned.
    /// </summary>
    [TestFixture]
    public class AlgebraicNotationGeneratorTests
    {
        [Test, TestCaseSource(typeof(AlgebraicNotationParserTestParameters), "PawnMoveParseTestCases")]
        public void PawnMoveParse(string expectedString, Move move)
        {
            AlgebraicNotationGenerator parser = new AlgebraicNotationGenerator();
            Pawn pawn = new BlackPawn();
            MoveGenerationData data = new MoveGenerationData(move, false, false, pawn);

            string output = parser.Convert(data);

            Assert.AreEqual(expectedString, output);
        }
    }
}
