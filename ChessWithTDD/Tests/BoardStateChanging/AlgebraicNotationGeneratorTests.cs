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
        public void PawnMoveParseCheckAndMateFalse(string expectedString, Move move)
        {
            AlgebraicNotationGenerator parser = new AlgebraicNotationGenerator();
            Pawn pawn = new BlackPawn();
            bool check = false;
            bool checkMate = false;
            MoveGenerationData data = new MoveGenerationData(move, check, checkMate, pawn);

            string output = parser.Convert(data);

            Assert.AreEqual(expectedString, output);
        }
    }
}
