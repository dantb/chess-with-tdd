using System.Collections.Generic;

namespace ChessWithTDD
{
    public class CheckMateManager : ICheckMateManager
    {
        public bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache, ISquare threateningSquare)
        {
            if (theBoard.InCheck)
            {
                if ((boardCache.WhiteKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = boardCache.WhiteKingSquare;
                    IKing king = boardCache.WhiteKingSquare.Piece as IKing;
                    if (KingCanEscape(theBoard, kingSquare))
                    {
                        return false;
                    }

                    if (ThreateningPieceCanBeCaptured(boardCache.WhitePieceSquares, theBoard, threateningSquare))
                    {
                        return false;
                    }

                    if (ThreateningPieceIsUnblockable(threateningSquare.Piece) ||
                        King.MoveIsToAdjacentSquare(threateningSquare, kingSquare))
                    {
                        return true;
                    }
                }
                else if ((boardCache.BlackKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = boardCache.BlackKingSquare;
                    IKing king = boardCache.BlackKingSquare.Piece as IKing;
                    if (KingCanEscape(theBoard, kingSquare))
                    {
                        return false;
                    }

                    if (ThreateningPieceCanBeCaptured(boardCache.BlackPieceSquares, theBoard, threateningSquare))
                    {
                        return false;
                    }

                    if (ThreateningPieceIsUnblockable(threateningSquare.Piece) ||
                        King.MoveIsToAdjacentSquare(threateningSquare, kingSquare))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ThreateningPieceIsUnblockable(IPiece thePiece)
        {
            if (thePiece is IKnight ||
                thePiece is IPawn ||
                thePiece is IKing)
            {
                return true;
            }
            return false;
        }

        private bool ThreateningPieceCanBeCaptured(HashSet<ISquare> friendlySquares, IBoard theBoard, ISquare threateningSquare)
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

        private bool KingCanEscape(IBoard theBoard, ISquare kingSquare)
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
    }
}
