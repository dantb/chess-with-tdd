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
            if (threateningSquare.Piece.Colour == Colour.White)
            {
                SetBoardAndKingCheckAndCheckMateStatesIfThreatened(theBoard, threateningSquare, theBoard.BlackKingSquare);
            }
            else if (threateningSquare.Piece.Colour == Colour.Black)
            {
                SetBoardAndKingCheckAndCheckMateStatesIfThreatened(theBoard, threateningSquare, theBoard.WhiteKingSquare);
            }
        }

        private void SetBoardAndKingCheckAndCheckMateStatesIfThreatened(IBoard theBoard, ISquare threateningSquare, ISquare kingSquare)
        {
            if (theBoard.MoveIsValid(threateningSquare, kingSquare))
            {
                theBoard.InCheck = true;
                (kingSquare.Piece as IKing).InCheckState = true;
                theBoard.CheckMate = _checkMateManager.BoardIsInCheckMate(theBoard, threateningSquare);
            }
        }

        private void RemoveCheckStates(IBoard theBoard)
        {
            if (theBoard.InCheck)
            {
                //If we get here then we know for sure the previous move removed the king's check state
                if ((theBoard.WhiteKingSquare.Piece as IKing).InCheckState)
                {
                    (theBoard.WhiteKingSquare.Piece as IKing).InCheckState = false;
                }
                else if ((theBoard.BlackKingSquare.Piece as IKing).InCheckState)
                {
                    (theBoard.BlackKingSquare.Piece as IKing).InCheckState = false;
                }
                theBoard.InCheck = false;
            }
        }
    }   
}
