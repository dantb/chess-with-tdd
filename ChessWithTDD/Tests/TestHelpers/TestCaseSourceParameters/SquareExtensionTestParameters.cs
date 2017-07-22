namespace ChessWithTDD.Tests.TestHelpers
{
    internal class SquareExtensionTestParameters
    {
        internal static object[] CasesForWhichIsAnLShapeAwayFromIsTrue =
{
            new int[] { 3, 3, 5, 4 },
            new int[] { 3, 3, 4, 5 },
            new int[] { 4, 5, 3, 3 },
            new int[] { 5, 4, 3, 3 }
        };

        internal static object[] CasesForWhichIsAnLShapeAwayFromIsFalse =
        {
            new int[] { 3, 3, 4, 4 },
            new int[] { 3, 3, 4, 3 },
            new int[] { 3, 3, 3, 4 },
            new int[] { 3, 3, 0, 0 },
            new int[] { 4, 1, 1, 4 },
            new int[] { 1, 4, 5, 6 },
        };

        internal static object[] CasesForWhichDiagonalToIsTrue =
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

        internal static object[] CasesForWhichDiagonalToIsFalse =
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

        internal static object[] CasesForWhichAdjacentToIsTrue =
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

        internal static object[] CasesForWhichAdjacentToIsFalse =
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

        internal static object[] CasesForWhichOneSquareDiagonallyBelowIsTrue =
        {
            new int[] { 1, 1, 2, 2 },
            new int[] { 1, 3, 2, 2 },
            new int[] { 2, 5, 3, 4 }
        };

        internal static object[] CasesForWhichOneSquareDiagonallyBelowIsFalse =
        {
            new int[] { 0, 0, 2, 2 },
            new int[] { 1, 3, 2, 3 },
            new int[] { 2, 5, 2, 4 }
        };

        internal static object[] CasesForWhichOneSquareDiagonallyAboveIsTrue =
        {
            new int[] { 3, 3, 2, 2 },
            new int[] { 3, 1, 2, 2 },
            new int[] { 4, 5, 3, 4 }
        };

        internal static object[] CasesForWhichOneSquareDiagonallyAboveIsFalse =
        {
            new int[] { 4, 4, 2, 2 },
            new int[] { 3, 2, 2, 2 },
            new int[] { 4, 5, 4, 6 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthNorthOfIsTrue =
        {
            new int[] { 5, 2, 2, 2 },
            new int[] { 7, 3, 5, 3 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthNorthOfIsFalse =
        {
            new int[] { 3, 2, 2, 2 },
            new int[] { 7, 3, 5, 4 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthWestOfIsTrue =
        {
            new int[] { 4, 0, 2, 2 },
            new int[] { 7, 2, 4, 5 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthWestOfIsFalse =
        {
            new int[] { 3, 1, 2, 2 },
            new int[] { 7, 3, 4, 5 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthEastOfIsTrue =
        {
            new int[] { 4, 4, 2, 2 },
            new int[] { 6, 7, 2, 3 }
        };

        internal static object[] CasesForWhichMultipleSquaresNorthEastOfIsFalse =
        {
            new int[] { 3, 3, 2, 2 },
            new int[] { 5, 7, 2, 3 }
        };

        internal static object[] CasesForWhichMultipleSquaresWestWestOfIsTrue =
        {
            new int[] { 4, 2, 4, 5 },
            new int[] { 6, 0, 6, 6 }
        };

        internal static object[] CasesForWhichMultipleSquaresWestWestOfIsFalse =
        {
            new int[] { 4, 4, 4, 5 },
            new int[] { 6, 0, 7, 6 }
        };

        internal static object[] CasesForWhichMultipleSquaresEastEastOfIsTrue =
        {
            new int[] { 4, 6, 4, 3 },
            new int[] { 6, 5, 6, 1 }
        };

        internal static object[] CasesForWhichMultipleSquaresEastEastOfIsFalse =
        {
            new int[] { 4, 4, 4, 3 },
            new int[] { 6, 5, 7, 1 }
        };


        internal static object[] CasesForWhichMultipleSquaresSouthSouthOfIsTrue =
        {
            new int[] { 4, 6, 6, 6 },
            new int[] { 0, 1, 5, 1 }
        };

        internal static object[] CasesForWhichMultipleSquaresSouthSouthOfIsFalse =
        {
            new int[] { 4, 6, 5, 6 },
            new int[] { 0, 0, 5, 1 }
        };

        internal static object[] CasesForWhichMultipleSquaresSouthWestOfIsTrue =
        {
            new int[] { 4, 4, 6, 6 },
            new int[] { 2, 0, 5, 3 }
        };

        internal static object[] CasesForWhichMultipleSquaresSouthWestOfIsFalse =
        {
            new int[] { 5, 5, 6, 6 },
            new int[] { 2, 0, 5, 2 }
        };

        internal static object[] CasesForWhichMultipleSquaresSouthEastOfIsTrue =
        {
            new int[] { 3, 7, 5, 5 },
            new int[] { 0, 6, 3, 3 }
        };

        internal static object[] CasesForWhichMultipleSquaresSouthEastOfIsFalse =
        {
            new int[] { 4, 6, 5, 5 },
            new int[] { 1, 6, 3, 3 }
        };
    }
}
