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
