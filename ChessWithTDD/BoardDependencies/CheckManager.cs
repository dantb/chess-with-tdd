using System;
using System.Collections.Generic;

namespace ChessWithTDD
{
    public class CheckManager : ICheckManager
    {
        private ICheckMateManager _checkMateManager;
        private IBoardCache _boardCache;

        public CheckManager(ICheckMateManager checkMateManager, IBoardCache boardCache)
        {
            _checkMateManager = checkMateManager;
            _boardCache = boardCache;
        }

        public bool BoardIsInCheckMate(IBoard theBoard)
        {
            throw new NotImplementedException();
        }

        public void UpdateCheckStates(IBoard theBoard, ISquare toSquare)
        {
            RemoveCheckStates(theBoard);
            AddCheckStates(theBoard, toSquare);
        }

        private void AddCheckStates(IBoard theBoard, ISquare toSquare)
        {
            if (toSquare.Piece.Colour == Colour.White)
            {
                ISquare blackKingSquare = _boardCache.BlackKingSquare;
                //see if black king is in check
                if (theBoard.MoveIsValid(toSquare, blackKingSquare))
                {
                    theBoard.InCheck = true;
                    (blackKingSquare.Piece as IKing).InCheckState = true;
                    theBoard.CheckMate = _checkMateManager.BoardIsInCheckMate(theBoard, _boardCache, toSquare);
                }
            }
            else if (toSquare.Piece.Colour == Colour.Black)
            {
                ISquare whtieKingSquare = _boardCache.WhiteKingSquare;
                //see if white king is in check
                if (theBoard.MoveIsValid(toSquare, whtieKingSquare))
                {
                    theBoard.InCheck = true;
                    (whtieKingSquare.Piece as IKing).InCheckState = true;
                    theBoard.CheckMate = _checkMateManager.BoardIsInCheckMate(theBoard, _boardCache, toSquare);
                }
            }
        }

        private void RemoveCheckStates(IBoard theBoard)
        {
            if (theBoard.InCheck)
            {
                //If we get here then we know for sure that a piece of the same colour as the king in check
                //has just moved to result in the removal of check state (could be the king itself that moved).
                if ((_boardCache.WhiteKingSquare.Piece as IKing).InCheckState)
                {
                    (_boardCache.WhiteKingSquare.Piece as IKing).InCheckState = false;
                }
                else if ((_boardCache.BlackKingSquare.Piece as IKing).InCheckState)
                {
                    (_boardCache.BlackKingSquare.Piece as IKing).InCheckState = false;
                }
                theBoard.InCheck = false;
            }
        }
    }

    public interface ICheckMateManager
    {
        bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache, ISquare threateningSquare);
    }

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

                    if (ThreateningPieceIsUnblockable(threateningSquare.Piece))
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

                    if (ThreateningPieceIsUnblockable(threateningSquare.Piece))
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
