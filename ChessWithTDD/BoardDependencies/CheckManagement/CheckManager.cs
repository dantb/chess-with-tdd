namespace ChessWithTDD
{
    public class CheckManager : ICheckManager
    {
        private ICheckMateManager _checkMateManager;

        public CheckManager(ICheckMateManager checkMateManager)
        {
            _checkMateManager = checkMateManager;
        }

        public void UpdateCheckAndCheckMateStates(IBoard theBoard, ISquare toSquare)
        {
            RemoveCheckStates(theBoard);
            AddCheckAndCheckMateStates(theBoard, toSquare);
        }

        private void AddCheckAndCheckMateStates(IBoard theBoard, ISquare threateningSquare)
        {
            ISquare kingUnderThreatSquare = theBoard.OtherTeamKingSquare;
            if (theBoard.MoveIsValid(threateningSquare, kingUnderThreatSquare))
            {
                theBoard.InCheck = true;
                (kingUnderThreatSquare.Piece as IKing).InCheckState = true;
                theBoard.CheckMate = _checkMateManager.BoardIsInCheckMate(theBoard, threateningSquare);
            }
            else
            {
                // not under threat right now, but the board could still be in a state of stalemate
                theBoard.StaleMate = BoardIsInStaleMate(theBoard);
            }
        }

        private bool BoardIsInStaleMate(IBoard theBoard)
        {
            foreach (ISquare movingTeamSquare in theBoard.OtherTeamPieceSquares)
            {
                foreach (var row in theBoard.Squares)
                {
                    foreach (ISquare square in row)
                    {
                        if (theBoard.MoveIsValid(movingTeamSquare, square))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void RemoveCheckStates(IBoard theBoard)
        {
            if (theBoard.InCheck)
            {
                //If we get here then we know for sure the previous move removed check from the moving team's king
                (theBoard.MovingTeamKingSquare.Piece as IKing).InCheckState = false;
                theBoard.InCheck = false;
            }
        }
    }   
}
