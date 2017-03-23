using NUnit.Framework;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class MoveTests
    {
        [TestCase(1,2,3,4)]
        [Test]
        public void MoveIntialisesWithFromSquareAndToSquareCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Move move = new Move(rowFrom, colFrom, rowTo, colTo);

            Assert.That(move.FromRow.Equals(rowFrom) 
                && move.FromCol.Equals(colFrom)
                && move.ToRow.Equals(rowTo)
                && move.ToCol.Equals(colTo));
        }      
    }
}
