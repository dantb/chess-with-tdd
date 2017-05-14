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

        public void UpdateCheckAndCheckMateStates(IBoard theBoard, ISquare toSquare)
        {
            RemoveCheckStates(theBoard);
            AddCheckAndCheckMateStates(theBoard, toSquare);
        }

        private void AddCheckAndCheckMateStates(IBoard theBoard, ISquare threateningSquare)
        {
            if (threateningSquare.Piece.Colour == Colour.White)
            {
                SetBoardAndKingCheckAndCheckMateStatesIfThreatened(theBoard, threateningSquare, _boardCache.BlackKingSquare);
            }
            else if (threateningSquare.Piece.Colour == Colour.Black)
            {
                SetBoardAndKingCheckAndCheckMateStatesIfThreatened(theBoard, threateningSquare, _boardCache.WhiteKingSquare);
            }
        }

        private void SetBoardAndKingCheckAndCheckMateStatesIfThreatened(IBoard theBoard, ISquare threateningSquare, ISquare kingSquare)
        {
            if (theBoard.MoveIsValid(threateningSquare, kingSquare))
            {
                theBoard.InCheck = true;
                (kingSquare.Piece as IKing).InCheckState = true;
                theBoard.CheckMate = _checkMateManager.BoardIsInCheckMate(theBoard, _boardCache, threateningSquare);
            }
        }

        private void RemoveCheckStates(IBoard theBoard)
        {
            if (theBoard.InCheck)
            {
                //If we get here then we know for sure the previous move removed the king's check state
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
}
