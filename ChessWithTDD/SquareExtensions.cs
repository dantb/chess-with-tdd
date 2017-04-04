using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWithTDD
{
    internal static class SquareExtensions
    {
        internal static bool IsMultipleSquaresNorthNorthOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Col == squareToCompare.Col &&
                squareInstance.Row >= squareToCompare.Row + 2)
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresNorthWestOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row >= squareToCompare.Row + 2 &&
                squareInstance.Col + 2 <= squareToCompare.Col &&
                squareInstance.IsDiagonalTo(squareToCompare))
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresNorthEastOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row >= squareToCompare.Row + 2 &&
                squareInstance.Col >= squareToCompare.Col + 2 &&
                squareInstance.IsDiagonalTo(squareToCompare))
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresWestWestOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row == squareToCompare.Row &&
                squareInstance.Col + 2 <= squareToCompare.Col)
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresEastEastOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row == squareToCompare.Row &&
                squareInstance.Col >= squareToCompare.Col + 2)
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresSouthSouthOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Col == squareToCompare.Col &&
                squareInstance.Row + 2 <= squareToCompare.Row)
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresSouthWestOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row + 2 <= squareToCompare.Row &&
                squareInstance.Col + 2 <= squareToCompare.Col &&
                squareInstance.IsDiagonalTo(squareToCompare))
            {
                return true;
            }
            return false;
        }

        internal static bool IsMultipleSquaresSouthEastOf(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row + 2 <= squareToCompare.Row &&
                squareInstance.Col >= squareToCompare.Col + 2 &&
                squareInstance.IsDiagonalTo(squareToCompare))
            {
                return true;
            }
            return false;
        }

        internal static bool IsOneSquareDiagonallyAbove(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row == squareToCompare.Row + 1 &&
                ((squareInstance.Col == squareToCompare.Col - 1) 
                || (squareInstance.Col == squareToCompare.Col + 1)))
            {
                return true;
            }      
            return false;
        }

        internal static bool IsOneSquareDiagonallyBelow(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row == squareToCompare.Row - 1 &&
                ((squareInstance.Col == squareToCompare.Col - 1)
                || (squareInstance.Col == squareToCompare.Col + 1)))
            {
                return true;
            }
            return false;
        }

        internal static bool IsAdjacentTo(this ISquare squareInstance, ISquare squareToCompare)
        {
            int rowDifference = Math.Abs(squareInstance.Row - squareToCompare.Row);
            int colDifference = Math.Abs(squareInstance.Col - squareToCompare.Col);
            if (rowDifference <= 1 && colDifference <= 1)
            {
                return true;
            }
            return false;
        }

        internal static bool IsDiagonalTo(this ISquare squareInstance, ISquare squareToCompare)
        {
            int rowDifference = Math.Abs(squareInstance.Row - squareToCompare.Row);
            int colDifference = Math.Abs(squareInstance.Col - squareToCompare.Col);
            if (rowDifference == colDifference)
            {
                return true;
            }
            return false;
        }

        internal static bool IsInSameRowAs(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Row == squareToCompare.Row)
            {
                return true;
            }
            return false;
        }

        internal static bool IsInSameColumnAs(this ISquare squareInstance, ISquare squareToCompare)
        {
            if (squareInstance.Col == squareToCompare.Col)
            {
                return true;
            }
            return false;
        }

        internal static bool IsAnLShapeAwayFrom(this ISquare squareInstance, ISquare squareToCompare)
        {
            if ((Math.Abs(squareInstance.Row - squareToCompare.Row) == 2 &&
                 Math.Abs(squareInstance.Col - squareToCompare.Col) == 1) ||
                (Math.Abs(squareInstance.Row - squareToCompare.Row) == 1 &&
                 Math.Abs(squareInstance.Col - squareToCompare.Col) == 2))
            {
                return true;
            }
            return false;
        }
    }
}
