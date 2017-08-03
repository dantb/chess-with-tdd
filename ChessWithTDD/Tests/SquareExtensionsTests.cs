using ChessWithTDD.Tests.TestHelpers;
using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class SquareExtensionsTests
    {
        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthNorthOfIsTrue")]
        public void IsMultipleSquaresNorthNorthOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthNorthOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthNorthOfIsFalse")]
        public void IsMultipleSquaresNorthNorthOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthNorthOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthWestOfIsTrue")]
        public void IsMultipleSquaresNorthWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthWestOfIsFalse")]
        public void IsMultipleSquaresNorthWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthEastOfIsTrue")]
        public void IsMultipleSquaresNorthEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresNorthEastOfIsFalse")]
        public void IsMultipleSquaresNorthEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresWestWestOfIsTrue")]
        public void IsMultipleSquaresWestWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresWestWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresWestWestOfIsFalse")]
        public void IsMultipleSquaresWestWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresWestWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresEastEastOfIsTrue")]
        public void IsMultipleSquaresEastEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresEastEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresEastEastOfIsFalse")]
        public void IsMultipleSquaresEastEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresEastEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthSouthOfIsTrue")]
        public void IsMultipleSquaresSouthSouthOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthSouthOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthSouthOfIsFalse")]
        public void IsMultipleSquaresSouthSouthOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthSouthOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthWestOfIsTrue")]
        public void IsMultipleSquaresSouthWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthWestOfIsFalse")]
        public void IsMultipleSquaresSouthWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthEastOfIsTrue")]
        public void IsMultipleSquaresSouthEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichMultipleSquaresSouthEastOfIsFalse")]
        public void IsMultipleSquaresSouthEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichOneSquareDiagonallyAboveIsTrue")]
        public void IsOneSquareDiagonallyAbove_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyAbove(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichOneSquareDiagonallyAboveIsFalse")]
        public void IsOneSquareDiagonallyAbove_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyAbove(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichOneSquareDiagonallyBelowIsTrue")]
        public void IsOneSquareDiagonallyBelow_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyBelow(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichOneSquareDiagonallyBelowIsFalse")]
        public void IsOneSquareDiagonallyBelow_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyBelow(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichAdjacentToIsTrue")]
        public void IsAdjacentTo_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAdjacentTo(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichAdjacentToIsFalse")]
        public void IsAdjacentTo_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAdjacentTo(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichDiagonalToIsTrue")]
        public void IsDiagonalTo_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsDiagonalTo(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichDiagonalToIsFalse")]
        public void IsDiagonalTo_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsDiagonalTo(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsInSameRowAsIsTrue")]
        public void IsInSameRowAs_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameRowAs(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsInSameRowAsIsFalse")]
        public void IsInSameRowAs_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameRowAs(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsInSameColumnAsIsTrue")]
        public void IsInSameColumnAs_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameColumnAs(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsInSameColumnAsIsFalse")]
        public void IsInSameColumnAs_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameColumnAs(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsAnLShapeAwayFromIsTrue")]
        public void IsAnLShapeAwayFrom_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAnLShapeAwayFrom(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource(typeof(SquareExtensionTestParameters), "CasesForWhichIsAnLShapeAwayFromIsFalse")]
        public void IsAnLShapeAwayFrom_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAnLShapeAwayFrom(compareSquare);

            Assert.False(result);
        }
    }
}
