using System;

namespace ChessWithTDD
{
    public class MultiSquareMoveValidator : IMultiSquareMoveValidator
    {
        public bool MultiSquareMoveIsBlockedByAnObstacle(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (toSquare.IsMultipleSquaresEastEastOf(fromSquare))
            {
                //moving east
                return EastMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresWestWestOf(fromSquare))
            {
                //moving west
                return WestMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresNorthNorthOf(fromSquare))
            {
                //moving up
                return NorthMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresSouthSouthOf(fromSquare))
            {
                //moving down
                return SouthMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresNorthWestOf(fromSquare))
            {
                //north west
                return NorthWestMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresNorthEastOf(fromSquare))
            {
                //north east
                return NorthEastMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresSouthWestOf(fromSquare))
            {
                //south west
                return SouthWestMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            else if (toSquare.IsMultipleSquaresSouthEastOf(fromSquare))
            {
                //south east
                return SouthEastMoveContainsPiece(fromSquare, toSquare, theBoard);
            }
            return false;
        }

        private bool SouthEastMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i > toSquare.Row;
            return DiagonalMoveContainsPiece(
                theBoard, fromSquare.Row - 1, fromSquare.Col + 1, condition, Decrement(), Increment());
        }

        private bool SouthWestMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i > toSquare.Row;
            return DiagonalMoveContainsPiece(
                theBoard, fromSquare.Row - 1, fromSquare.Col - 1, condition, Decrement(), Decrement());
        }

        private bool NorthEastMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i < toSquare.Row;
            return DiagonalMoveContainsPiece(
                theBoard, fromSquare.Row + 1, fromSquare.Col + 1, condition, Increment(), Increment());
        }

        private bool NorthWestMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i < toSquare.Row;
            return DiagonalMoveContainsPiece(
                theBoard, fromSquare.Row + 1, fromSquare.Col - 1, condition, Increment(), Decrement());
        }

        private bool SouthMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i > toSquare.Row;
            return VerticalMoveContainsPiece(
                theBoard, toSquare.Col, fromSquare.Row - 1, condition, Decrement());
        }

        private bool NorthMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i < toSquare.Row;
            return VerticalMoveContainsPiece(
                theBoard, toSquare.Col, fromSquare.Row + 1, condition, Increment());
        }

        private bool WestMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i > toSquare.Col;
            return HorizontalMoveContainsPiece(
                theBoard, toSquare.Row, fromSquare.Col - 1, condition, Decrement());
        }

        private bool EastMoveContainsPiece(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            Func<int, bool> condition = (i) => i < toSquare.Col;
            return HorizontalMoveContainsPiece(
                theBoard, toSquare.Row, fromSquare.Col + 1, condition, Increment());
        }

        private delegate void RefAction<T>(ref T param);

        private static RefAction<int> Decrement()
        {
            return delegate (ref int i) { i--; };
        }

        private static RefAction<int> Increment()
        {
            return delegate (ref int i) { i++; };
        }

        private bool DiagonalMoveContainsPiece(IBoard theBoard, int startingRow, int startingCol,
            Func<int, bool> condition, RefAction<int> changeRow, RefAction<int> changeCol)
        {
            for (int i = startingRow; condition(i); changeRow(ref i))
            {
                if (theBoard.GetSquare(i, startingCol).ContainsPiece)
                {
                    return true;
                }
                changeCol(ref startingCol);
            }
            return false;
        }

        private bool HorizontalMoveContainsPiece(IBoard theBoard, int fixedRow, int startingCol,
            Func<int, bool> condition, RefAction<int> changeCol)
        {
            for (int i = startingCol; condition(i); changeCol(ref i))
            {
                if (theBoard.GetSquare(fixedRow, i).ContainsPiece)
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerticalMoveContainsPiece(IBoard theBoard, int fixedCol, int startingRow,
            Func<int, bool> condition, RefAction<int> changeRow)
        {
            for (int i = startingRow; condition(i); changeRow(ref i))
            {
                if (theBoard.GetSquare(i, fixedCol).ContainsPiece)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
