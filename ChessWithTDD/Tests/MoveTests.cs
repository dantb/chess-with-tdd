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

        [TestCase(1, 2, 3, 4)]
        [TestCase(5, 5, -5, 5)]
        [Test]
        public void MoveObjectEqualsOverrideReturnsTrue(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Move first = new Move(rowFrom, colFrom, rowTo, colTo);
            Move second = new Move(rowFrom, colFrom, rowTo, colTo);

            bool areEqual = first.Equals(second);

            Assert.True(areEqual);
        }

        [TestCase(1, 2, 3, 5)]
        [TestCase(1, 2, 4, 4)]
        [TestCase(1, 3, 3, 4)]
        [TestCase(2, 2, 3, 4)]
        [Test]
        public void MoveObjectEqualsOverrideReturnsFalse(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Move first = new Move(1, 2, 3, 4);
            Move second = new Move(rowFrom, colFrom, rowTo, colTo);

            bool areEqual = first.Equals(second);

            Assert.False(areEqual);
        }

        [Test]
        public void MoveObjectEqualsOverrideReturnsFalseForOtherObject()
        {
            Move first = new Move(1, 2, 3, 4);
            object obj = new object();

            bool areEqual = first.Equals(obj);

            Assert.False(areEqual);
        }

        #region GetHashCode

        //the GetHashCode tests should reflect the results of Equals override tests. If two objects are equal using Equals,
        //they must have the same GetHashCode()

        [TestCase(1, 2, 3, 4)]
        [TestCase(5, 5, -5, 5)]
        [Test]
        public void MoveObjectGetHashCodeOverrideReturnsTrue(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Move first = new Move(rowFrom, colFrom, rowTo, colTo);
            Move second = new Move(rowFrom, colFrom, rowTo, colTo);

            int hash1 = first.GetHashCode();
            int hash2 = second.GetHashCode();

            Assert.AreEqual(hash1, hash2);
        }

        [TestCase(1, 2, 3, 5)]
        [TestCase(1, 2, 4, 4)]
        [TestCase(1, 3, 3, 4)]
        [TestCase(2, 2, 3, 4)]
        [Test]
        public void MoveObjectGetHashCodeOverrideReturnsFalse(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Move first = new Move(1, 2, 3, 4);
            Move second = new Move(rowFrom, colFrom, rowTo, colTo);

            int hash1 = first.GetHashCode();
            int hash2 = second.GetHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }

        [Test]
        public void MoveObjectGetHashCodeOverrideReturnsFalseForOtherObject()
        {
            Move first = new Move(1, 2, 3, 4);
            object obj = new object();

            int hash1 = first.GetHashCode();
            int hash2 = obj.GetHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }

        #endregion
    }
}
