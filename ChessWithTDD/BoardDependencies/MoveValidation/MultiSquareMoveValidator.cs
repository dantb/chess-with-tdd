using System;

namespace ChessWithTDD
{
    public class MultiSquareMoveValidator : IMultiSquareMoveValidator
    {
        public bool MultiSquareMoveIsBlockedByAnObstacle(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (toSquare.Row == fromSquare.Row && Math.Abs(toSquare.Col - fromSquare.Col) >= 2)
            {
                //moving multiple horizontally
                if (toSquare.Col > fromSquare.Col)
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
                else if (toSquare.Col < fromSquare.Col)
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
            }
            else if (toSquare.Col == fromSquare.Col && Math.Abs(toSquare.Row - fromSquare.Row) >= 2)
            {
                //moving multiple vertically
                if (toSquare.Row > fromSquare.Row)
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
                else if (toSquare.Row < fromSquare.Row)
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
            }
            else if (toSquare.Row - fromSquare.Row >= 2 && fromSquare.Col - toSquare.Col >= 2)
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
            else if (toSquare.Row - fromSquare.Row >= 2 && toSquare.Col - fromSquare.Col >= 2)
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
            else if (fromSquare.Row - toSquare.Row >= 2 && fromSquare.Col - toSquare.Col >= 2)
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
            else if (fromSquare.Row - toSquare.Row >= 2 && toSquare.Col - fromSquare.Col >= 2)
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
