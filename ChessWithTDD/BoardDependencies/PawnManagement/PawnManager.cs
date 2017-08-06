using static ChessWithTDD.BoardConstants;

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

            ConvertPawnToQueenIfPromotionRow(fromSquare, toSquare, theBoard);
        }

        private static void ConvertPawnToQueenIfPromotionRow(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            bool whitePromotion = toSquare.Row == BLACK_BACK_ROW;
            bool blackPromotion = toSquare.Row == WHITE_BACK_ROW;
            if (whitePromotion || blackPromotion)
            {
                // promote the pawn
                Queen queen = new Queen(whitePromotion ? Colour.White : Colour.Black);

                // set piece to the queen before it's moved
                theBoard.GetSquare(fromSquare.Row, fromSquare.Col).Piece = queen;
            }
        }

        public void UnmarkEnPassantSquares(int turnCounter)
        {
            _enPassantManager.UnmarkEnPassantSquares(turnCounter);
        }
    }    
}
