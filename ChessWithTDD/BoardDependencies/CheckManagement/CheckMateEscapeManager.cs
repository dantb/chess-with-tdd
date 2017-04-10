using System.Collections.Generic;

namespace ChessWithTDD
{
    public class CheckMateEscapeManager : ICheckMateEscapeManager
    {
        public bool KingCanEscape(IBoard theBoard, ISquare kingSquare)
        {
            if (SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row, kingSquare.Col - 1) ||
                SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row, kingSquare.Col + 1))
            {
                //escape horizontally
                return true;
            }
            else if (SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row - 1, kingSquare.Col) ||
                     SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row + 1, kingSquare.Col))
            {
                //escape vertically
                return true;
            }
            else if (SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row - 1, kingSquare.Col - 1) ||
                     SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row + 1, kingSquare.Col - 1) ||
                     SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row - 1, kingSquare.Col + 1) ||
                     SquareOnBoardAndKingCanEscape(theBoard, kingSquare, kingSquare.Row + 1, kingSquare.Col + 1))
            {
                return true;
            }

            return false;
        }

        public bool ThreateningPieceCanBeCaptured(HashSet<ISquare> friendlySquares, IBoard theBoard, ISquare threateningSquare)
        {
            foreach (var square in friendlySquares)
            {
                if (theBoard.MoveIsValid(square, threateningSquare))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ThreateningPieceIsUnblockable(ISquare threateningSquare, ISquare kingSquare)
        {
            if (threateningSquare.Piece is IKnight)
            {
                return true;
            }
            else if (threateningSquare.IsAdjacentTo(kingSquare))
            {
                return true;
            }
            return false;
        }

        public bool LineOfSightToKingCanBeBlockedByFriendlyPiece(IBoard theBoard, ISquare threateningSquare, ISquare kingSquare, HashSet<ISquare> friendlySquares)
        {
            if (kingSquare.IsMultipleSquaresEastEastOf(threateningSquare))
            {
                //moving east
                for (int i = threateningSquare.Col + 1; i < kingSquare.Col; i++)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(kingSquare.Row, i)))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (kingSquare.IsMultipleSquaresWestWestOf(threateningSquare))
            {
                //moving west
                for (int i = threateningSquare.Col - 1; i > kingSquare.Col; i--)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(kingSquare.Row, i)))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (kingSquare.IsMultipleSquaresNorthNorthOf(threateningSquare))
            {
                //moving up
                for (int i = threateningSquare.Row + 1; i < kingSquare.Row; i++)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, kingSquare.Col)))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (kingSquare.IsMultipleSquaresSouthSouthOf(threateningSquare))
            {
                //moving down
                for (int i = threateningSquare.Row - 1; i > kingSquare.Row; i--)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, kingSquare.Col)))
                        {
                            return true;
                        }
                    }
                }
            }
            else if (kingSquare.IsMultipleSquaresNorthWestOf(threateningSquare))
            {
                //north west
                int initialCol = threateningSquare.Col - 1;
                for (int i = threateningSquare.Row + 1; i < kingSquare.Row; i++)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, initialCol)))
                        {
                            return true;
                        }
                    }
                    initialCol--;
                }
            }
            else if (kingSquare.IsMultipleSquaresNorthEastOf(threateningSquare))
            {
                //north east
                int initialCol = threateningSquare.Col + 1;
                for (int i = threateningSquare.Row + 1; i < kingSquare.Row; i++)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, initialCol)))
                        {
                            return true;
                        }
                    }
                    initialCol++;
                }
            }
            else if (kingSquare.IsMultipleSquaresSouthWestOf(threateningSquare))
            {
                //south west
                int initialCol = threateningSquare.Col - 1;
                for (int i = threateningSquare.Row - 1; i > kingSquare.Row; i--)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, initialCol)))
                        {
                            return true;
                        }
                    }
                    initialCol--;
                }
            }
            else if (kingSquare.IsMultipleSquaresSouthEastOf(threateningSquare))
            {
                //south east
                int initialCol = threateningSquare.Col + 1;
                for (int i = threateningSquare.Row - 1; i > kingSquare.Row; i--)
                {
                    foreach (var friendly in friendlySquares)
                    {
                        if (theBoard.MoveIsValid(friendly, theBoard.GetSquare(i, initialCol)))
                        {
                            return true;
                        }
                    }
                    initialCol++;
                }
            }
            return false;
        }

        private bool SquareOnBoardAndKingCanEscape(IBoard theBoard, ISquare kingSquare, int escapeRow, int escapeCol)
        {
            if (escapeRow < 0 || escapeRow > BoardConstants.BOARD_DIMENSION ||
                escapeCol < 0 || escapeCol > BoardConstants.BOARD_DIMENSION)
            {
                return false;
            }
            return theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(escapeRow, escapeCol));
        }

    }
}
