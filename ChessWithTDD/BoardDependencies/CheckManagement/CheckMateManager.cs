using System.Collections.Generic;

namespace ChessWithTDD
{
    public class CheckMateManager : ICheckMateManager
    {
        private ICheckMateEscapeManager _checkMateEscapeManager;

        public CheckMateManager(ICheckMateEscapeManager checkMateEscapeManager)
        {
            _checkMateEscapeManager = checkMateEscapeManager;
        }

        public bool BoardIsInCheckMate(IBoard theBoard, ISquare threateningSquare)
        {
            if (theBoard.InCheck)
            {
                if ((theBoard.WhiteKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = theBoard.WhiteKingSquare;
                    return !CheckMateCanBePrevented(theBoard, threateningSquare, kingSquare, theBoard.WhitePieceSquares);
                }
                else if ((theBoard.BlackKingSquare.Piece as IKing).InCheckState)
                {
                    ISquare kingSquare = theBoard.BlackKingSquare;
                    return !CheckMateCanBePrevented(theBoard, threateningSquare, kingSquare, theBoard.BlackPieceSquares);
                }
            }
            return false;
        }

        private bool CheckMateCanBePrevented(IBoard theBoard, ISquare threateningSquare, ISquare kingSquare, HashSet<ISquare> friendlySquares)
        {
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

            if (_checkMateEscapeManager.LineOfSightToKingCanBeBlockedByFriendlyPiece(theBoard, threateningSquare, kingSquare, friendlySquares))
            {
                return true;
            }

            return false;
        }
    }
}
