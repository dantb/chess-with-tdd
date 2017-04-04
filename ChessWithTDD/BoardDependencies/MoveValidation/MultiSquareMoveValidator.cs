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
                for (int i = fromSquare.Col + 1; i < toSquare.Col; i++)
                {
                    if (theBoard.GetSquare(toSquare.Row, i).ContainsPiece)
                    {
                        return true;
                    }
                }
            }
            else if (toSquare.IsMultipleSquaresWestWestOf(fromSquare))
            {
                //moving west
                for (int i = fromSquare.Col - 1; i > toSquare.Col; i--)
                {
                    if (theBoard.GetSquare(toSquare.Row, i).ContainsPiece)
                    {
                        return true;
                    }
                }
            }
            else if (toSquare.IsMultipleSquaresNorthNorthOf(fromSquare))
            {
                //moving up
                for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                {
                    if (theBoard.GetSquare(i, toSquare.Col).ContainsPiece)
                    {
                        return true;
                    }
                }
            }
            else if (toSquare.IsMultipleSquaresSouthSouthOf(fromSquare))
            {
                //moving down
                for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                {
                    if (theBoard.GetSquare(i, toSquare.Col).ContainsPiece)
                    {
                        return true;
                    }
                }
            }
            else if (toSquare.IsMultipleSquaresNorthWestOf(fromSquare))
            {
                //north west
                int initialCol = fromSquare.Col - 1;
                for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                {
                    if (theBoard.GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol--;
                }
            }
            else if (toSquare.IsMultipleSquaresNorthEastOf(fromSquare))
            {
                //north east
                int initialCol = fromSquare.Col + 1;
                for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                {
                    if (theBoard.GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol++;
                }
            }
            else if (toSquare.IsMultipleSquaresSouthWestOf(fromSquare))
            {
                //south west
                int initialCol = fromSquare.Col - 1;
                for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                {
                    if (theBoard.GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol--;
                }
            }
            else if (toSquare.IsMultipleSquaresSouthEastOf(fromSquare))
            {
                //south east
                int initialCol = fromSquare.Col + 1;
                for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                {
                    if (theBoard.GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol++;
                }
            }
            return false;
        }
    }
}
