using System;

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
        bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache);
    }

    public class CheckMateManager : ICheckMateManager
    {
        public bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache)
        {
            throw new NotImplementedException();
        }
    }
}
