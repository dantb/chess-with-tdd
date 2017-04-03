namespace ChessWithTDD
{
    public class PawnManager : IPawnManager
    {
        private IEnPassantManager _enPassantManager;

        public PawnManager(IEnPassantManager enPassantManager)
        {
            _enPassantManager = enPassantManager;
        }
        public void MakePawnSpecificAmendments(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            IPawn pawn = fromSquare.Piece as IPawn;
            if (!pawn.HasMoved)
            {
                pawn.HasMoved = true;
            }
            _enPassantManager.MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare, theBoard);
            _enPassantManager.CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare, theBoard);
        }

        public void UnmarkEnPassantSquares(int turnCounter)
        {
            _enPassantManager.UnmarkEnPassantSquares(turnCounter);
        }
    }    
}
