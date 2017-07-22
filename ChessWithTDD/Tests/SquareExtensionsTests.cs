using NUnit.Framework;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class SquareExtensionsTests
    {
        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthNorthOfIsTrue")]
        public void IsMultipleSquaresNorthNorthOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthNorthOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthNorthOfIsFalse")]
        public void IsMultipleSquaresNorthNorthOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthNorthOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthWestOfIsTrue")]
        public void IsMultipleSquaresNorthWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthWestOfIsFalse")]
        public void IsMultipleSquaresNorthWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthEastOfIsTrue")]
        public void IsMultipleSquaresNorthEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresNorthEastOfIsFalse")]
        public void IsMultipleSquaresNorthEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresNorthEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresWestWestOfIsTrue")]
        public void IsMultipleSquaresWestWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresWestWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresWestWestOfIsFalse")]
        public void IsMultipleSquaresWestWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresWestWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresEastEastOfIsTrue")]
        public void IsMultipleSquaresEastEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresEastEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresEastEastOfIsFalse")]
        public void IsMultipleSquaresEastEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresEastEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthSouthOfIsTrue")]
        public void IsMultipleSquaresSouthSouthOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthSouthOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthSouthOfIsFalse")]
        public void IsMultipleSquaresSouthSouthOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthSouthOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthWestOfIsTrue")]
        public void IsMultipleSquaresSouthWestOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthWestOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthWestOfIsFalse")]
        public void IsMultipleSquaresSouthWestOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthWestOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthEastOfIsTrue")]
        public void IsMultipleSquaresSouthEastOf_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthEastOf(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichMultipleSquaresSouthEastOfIsFalse")]
        public void IsMultipleSquaresSouthEastOf_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsMultipleSquaresSouthEastOf(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichOneSquareDiagonallyAboveIsTrue")]
        public void IsOneSquareDiagonallyAbove_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyAbove(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichOneSquareDiagonallyAboveIsFalse")]
        public void IsOneSquareDiagonallyAbove_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyAbove(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichOneSquareDiagonallyBelowIsTrue")]
        public void IsOneSquareDiagonallyBelow_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyBelow(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichOneSquareDiagonallyBelowIsFalse")]
        public void IsOneSquareDiagonallyBelow_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsOneSquareDiagonallyBelow(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichAdjacentToIsTrue")]
        public void IsAdjacentTo_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAdjacentTo(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichAdjacentToIsFalse")]
        public void IsAdjacentTo_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAdjacentTo(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichDiagonalToIsTrue")]
        public void IsDiagonalTo_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsDiagonalTo(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichDiagonalToIsFalse")]
        public void IsDiagonalTo_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsDiagonalTo(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichIsInSameRowAsIsTrue")]
        public void IsInSameRowAs_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameRowAs(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichIsInSameRowAsIsFalse")]
        public void IsInSameRowAs_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameRowAs(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichIsInSameColumnAsIsTrue")]
        public void IsInSameColumnAs_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameColumnAs(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichIsInSameColumnAsIsFalse")]
        public void IsInSameColumnAs_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsInSameColumnAs(compareSquare);

            Assert.False(result);
        }

        [Test, TestCaseSource("CasesForWhichIsAnLShapeAwayFromIsTrue")]
        public void IsAnLShapeAwayFrom_ReturnsTrue(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAnLShapeAwayFrom(compareSquare);

            Assert.True(result);
        }

        [Test, TestCaseSource("CasesForWhichIsAnLShapeAwayFromIsFalse")]
        public void IsAnLShapeAwayFrom_ReturnsFalse(int thisRow, int thisCol, int compareRow, int compareCol)
        {
            ISquare thisSquare = MockSquare(thisRow, thisCol);
            ISquare compareSquare = MockSquare(compareRow, compareCol);

            bool result = thisSquare.IsAnLShapeAwayFrom(compareSquare);

            Assert.False(result);
        }

        static object[] CasesForWhichIsAnLShapeAwayFromIsTrue =
        {
            new int[] { 3, 3, 5, 4 },
            new int[] { 3, 3, 4, 5 },
            new int[] { 4, 5, 3, 3 },
            new int[] { 5, 4, 3, 3 }
        };

        static object[] CasesForWhichIsAnLShapeAwayFromIsFalse =
        {
            new int[] { 3, 3, 4, 4 },
            new int[] { 3, 3, 4, 3 },
            new int[] { 3, 3, 3, 4 },
            new int[] { 3, 3, 0, 0 },
            new int[] { 4, 1, 1, 4 },
            new int[] { 1, 4, 5, 6 },
        };

        static object[] CasesForWhichDiagonalToIsTrue =
        {
            //diagonal one square
            new int[] { 3, 3, 2, 2 },
            new int[] { 3, 1, 2, 2 },
            new int[] { 1, 3, 2, 2 },
            new int[] { 1, 1, 2, 2 },
            //diagonal more squares
            new int[] { 6, 6, 2, 2 },
            new int[] { 4, 0, 2, 2 },
            new int[] { 0, 4, 2, 2 },
            new int[] { 1, 1, 7, 7 },
        };

        static object[] CasesForWhichDiagonalToIsFalse =
        {
            new int[] { 3, 3, 3, 2 },
            new int[] { 3, 2, 2, 2 },
            new int[] { 1, 3, 3, 2 },
            new int[] { 1, 1, 2, 3 },
            new int[] { 6, 2, 2, 2 },
            new int[] { 4, 0, 4, 2 },
            new int[] { 1, 4, 2, 2 },
            new int[] { 1, 1, 5, 7 },
        };

        static object[] CasesForWhichAdjacentToIsTrue =
        {
            new int[] { 3, 3, 2, 3 },
            new int[] { 3, 3, 2, 2 },
            new int[] { 3, 1, 2, 2 },
            new int[] { 3, 3, 3, 2 },
            new int[] { 3, 3, 3, 4 },
            new int[] { 1, 3, 2, 2 },
            new int[] { 1, 1, 2, 2 },
            new int[] { 1, 2, 2, 2 },
        };

        static object[] CasesForWhichAdjacentToIsFalse =
        {
            new int[] { 4, 3, 2, 3 },
            new int[] { 4, 4, 2, 2 },
            new int[] { 4, 0, 2, 2 },
            new int[] { 3, 4, 3, 2 },
            new int[] { 3, 2, 3, 4 },
            new int[] { 0, 4, 2, 2 },
            new int[] { 0, 0, 2, 2 },
            new int[] { 0, 2, 2, 2 },
        };

        static object[] CasesForWhichOneSquareDiagonallyBelowIsTrue =
        {
            new int[] { 1, 1, 2, 2 },
            new int[] { 1, 3, 2, 2 },
            new int[] { 2, 5, 3, 4 }
        };

        static object[] CasesForWhichOneSquareDiagonallyBelowIsFalse =
        {
            new int[] { 0, 0, 2, 2 },
            new int[] { 1, 3, 2, 3 },
            new int[] { 2, 5, 2, 4 }
        };

        static object[] CasesForWhichOneSquareDiagonallyAboveIsTrue =
        {
            new int[] { 3, 3, 2, 2 },
            new int[] { 3, 1, 2, 2 },
            new int[] { 4, 5, 3, 4 }
        };

        static object[] CasesForWhichOneSquareDiagonallyAboveIsFalse =
        {
            new int[] { 4, 4, 2, 2 },
            new int[] { 3, 2, 2, 2 },
            new int[] { 4, 5, 4, 6 }
        };

        static object[] CasesForWhichMultipleSquaresNorthNorthOfIsTrue =
        {
            new int[] { 5, 2, 2, 2 },
            new int[] { 7, 3, 5, 3 }
        };

        static object[] CasesForWhichMultipleSquaresNorthNorthOfIsFalse =
        {
            new int[] { 3, 2, 2, 2 },
            new int[] { 7, 3, 5, 4 }
        };

        static object[] CasesForWhichMultipleSquaresNorthWestOfIsTrue =
        {
            new int[] { 4, 0, 2, 2 },
            new int[] { 7, 2, 4, 5 }
        };

        static object[] CasesForWhichMultipleSquaresNorthWestOfIsFalse =
        {
            new int[] { 3, 1, 2, 2 },
            new int[] { 7, 3, 4, 5 }
        };

        static object[] CasesForWhichMultipleSquaresNorthEastOfIsTrue =
        {
            new int[] { 4, 4, 2, 2 },
            new int[] { 6, 7, 2, 3 }
        };

        static object[] CasesForWhichMultipleSquaresNorthEastOfIsFalse =
        {
            new int[] { 3, 3, 2, 2 },
            new int[] { 5, 7, 2, 3 }
        };

        static object[] CasesForWhichMultipleSquaresWestWestOfIsTrue =
        {
            new int[] { 4, 2, 4, 5 },
            new int[] { 6, 0, 6, 6 }
        };

        static object[] CasesForWhichMultipleSquaresWestWestOfIsFalse =
        {
            new int[] { 4, 4, 4, 5 },
            new int[] { 6, 0, 7, 6 }
        };

        static object[] CasesForWhichMultipleSquaresEastEastOfIsTrue =
        {
            new int[] { 4, 6, 4, 3 },
            new int[] { 6, 5, 6, 1 }
        };

        static object[] CasesForWhichMultipleSquaresEastEastOfIsFalse =
        {
            new int[] { 4, 4, 4, 3 },
            new int[] { 6, 5, 7, 1 }
        };


        static object[] CasesForWhichMultipleSquaresSouthSouthOfIsTrue =
        {
            new int[] { 4, 6, 6, 6 },
            new int[] { 0, 1, 5, 1 }
        };

        static object[] CasesForWhichMultipleSquaresSouthSouthOfIsFalse =
        {
            new int[] { 4, 6, 5, 6 },
            new int[] { 0, 0, 5, 1 }
        };

        static object[] CasesForWhichMultipleSquaresSouthWestOfIsTrue =
        {
            new int[] { 4, 4, 6, 6 },
            new int[] { 2, 0, 5, 3 }
        };

        static object[] CasesForWhichMultipleSquaresSouthWestOfIsFalse =
        {
            new int[] { 5, 5, 6, 6 },
            new int[] { 2, 0, 5, 2 }
        };

        static object[] CasesForWhichMultipleSquaresSouthEastOfIsTrue =
        {
            new int[] { 3, 7, 5, 5 },
            new int[] { 0, 6, 3, 3 }
        };

        static object[] CasesForWhichMultipleSquaresSouthEastOfIsFalse =
        {
            new int[] { 4, 6, 5, 5 },
            new int[] { 1, 6, 3, 3 }
        };
    }
}
