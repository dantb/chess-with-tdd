using System.Collections.Generic;


namespace ChessWithTDD
{
    public class CheckMateManager : ICheckMateManager
    {
        ICheckMateEscapeManager _checkMateEscapeManager;

        public CheckMateManager(ICheckMateEscapeManager checkMateEscapeManager)
        {
            _checkMateEscapeManager = checkMateEscapeManager;
        }

        public bool BoardIsInCheckMate(IBoard theBoard, IBoardCache boardCache, ISquare threateningSquare)
        {
            if (theBoard.InCheck)
            {
                if ((boardCache.WhiteKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = boardCache.WhiteKingSquare;
                    return !CheckMateCanBePrevented(theBoard, boardCache, threateningSquare, kingSquare, boardCache.WhitePieceSquares);
                }
                else if ((boardCache.BlackKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = boardCache.BlackKingSquare;
                    return !CheckMateCanBePrevented(theBoard, boardCache, threateningSquare, kingSquare, boardCache.BlackPieceSquares);
                }
            }
            return false;
        }

        private bool CheckMateCanBePrevented(IBoard theBoard, IBoardCache boardCache, ISquare threateningSquare, ISquare kingSquare, HashSet<ISquare> friendlySquares)
        {
            IKing king = kingSquare.Piece as IKing;
            if (_checkMateEscapeManager.KingCanEscape(theBoard, kingSquare))
            {
                return true;
            }

            if (_checkMateEscapeManager.ThreateningPieceCanBeCaptured(friendlySquares, theBoard, threateningSquare))
            {
                return true;
            }

            if (_checkMateEscapeManager.ThreateningPieceIsUnblockable(threateningSquare, kingSquare))
            {
                return false;
            }

            return false;
        }
    }
}
