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
        [Test, TestCaseSource(typeof(AlgebraicNotationGeneratorTestParameters), "PawnMoveAndCaptureGenerationTestCases")]
        public void PawnMoveTestCaptureAndSquaresForConstantCheckAndMateAsFalse(string expectedString, Move move, bool capture)
        {
            AlgebraicNotationGenerator generator = new AlgebraicNotationGenerator();
            Pawn pawn = new BlackPawn();
            bool check = false;
            bool checkMate = false;
            MoveGenerationData data = new MoveGenerationData(move, check, checkMate, pawn, capture);

            string output = generator.Convert(data);

            Assert.AreEqual(expectedString, output);
        }

        [Test, TestCaseSource(typeof(AlgebraicNotationGeneratorTestParameters), "PawnGenerationCheckAndMateTestCases")]
        public void PawnMoveTestCheckAndMateForConstantCaptureAsFalse(string expectedString, Move move, bool check, bool checkMate)
        {
            AlgebraicNotationGenerator generator = new AlgebraicNotationGenerator();
            Pawn pawn = new WhitePawn();
            bool capture = false;
            MoveGenerationData data = new MoveGenerationData(move, check, checkMate, pawn, capture);

            string output = generator.Convert(data);

            Assert.AreEqual(expectedString, output);
        }
    }
}
