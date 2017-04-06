using System.Collections.Generic;

namespace ChessWithTDD
{
    public class CheckMateEscapeManager : ICheckMateEscapeManager
    {
        public bool KingCanEscape(IBoard theBoard, ISquare kingSquare)
        {
            if (theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row, kingSquare.Col - 1)) ||
                theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row, kingSquare.Col + 1)))
            {
                //escape horizontally
                return true;
            }
            else if (theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row - 1, kingSquare.Col)) ||
                     theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row + 1, kingSquare.Col)))
            {
                //escape vertically
                return true;
            }
            else if (theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row - 1, kingSquare.Col - 1)) ||
                     theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row + 1, kingSquare.Col - 1)) ||
                     theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row - 1, kingSquare.Col + 1)) ||
                     theBoard.MoveIsValid(kingSquare, theBoard.GetSquare(kingSquare.Row + 1, kingSquare.Col + 1)))
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
            return false;
        }
    }
}
