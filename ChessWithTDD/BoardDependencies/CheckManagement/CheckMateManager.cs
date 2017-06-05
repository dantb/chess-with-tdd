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
                ISquare kingSquare = theBoard.OtherTeamKingSquare;
                if ((kingSquare.Piece as IKing).InCheckState)
                {
                    return !CheckMateCanBePrevented(theBoard, threateningSquare, kingSquare, theBoard.OtherTeamPieceSquares);
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
