using System;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class MoveValidator : IMoveValidator
    {
        private IGenericMoveValidator _genericMoveValidator;
        private IMultiSquareMoveValidator _multiMoveValidator;

        public MoveValidator(IGenericMoveValidator genericMoveValidator, IMultiSquareMoveValidator multiMoveValidator)
        {
            _genericMoveValidator = genericMoveValidator;
            _multiMoveValidator = multiMoveValidator;
        }

        public bool MoveIsValid(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (!_genericMoveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare))
            {
                return false;
            }
            else if (_multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, theBoard))
            {
                return false;
            }
            return true;
        }
    }

    public interface IGenericMoveValidator
    {
        bool GenericSquareMoveValidationPasses(ISquare fromSquare, ISquare toSquare);
    }

    public class GenericMoveValidator : IGenericMoveValidator
    {
        public bool GenericSquareMoveValidationPasses(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Row >= BOARD_DIMENSION || fromSquare.Col >= BOARD_DIMENSION ||
                toSquare.Row >= BOARD_DIMENSION || toSquare.Col >= BOARD_DIMENSION)
            {
                return false;
            }
            else if (fromSquare.Row < BOARD_LOWER_DIMENSION || fromSquare.Col < BOARD_LOWER_DIMENSION ||
                     toSquare.Row < BOARD_LOWER_DIMENSION || toSquare.Col < BOARD_LOWER_DIMENSION)
            {
                return false;
            }
            else if (!fromSquare.ContainsPiece)
            {
                return false;
            }
            else if (toSquare.Row == fromSquare.Row && toSquare.Col == fromSquare.Col)
            {
                return false;
            }
            else if (fromSquare.Piece.Colour != Colour.Black && fromSquare.Piece.Colour != Colour.White)
            {
                return false;
            }
            else if (toSquare.ContainsPiece && toSquare.Piece.Colour == fromSquare.Piece.Colour)
            {
                return false;
            }
            return true;
        }
    }

    public interface IMultiSquareMoveValidator
    {
        bool MultiSquareMoveIsBlockedByAnObstacle(ISquare fromSquare, ISquare toSquare, IBoard theBoard);
    }

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
