namespace ChessWithTDD
{
    public class MoveIntoCheckValidator : IMoveIntoCheckValidator
    {
        public bool MoveIsIntoCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IKing)
            {
                foreach (ISquare square in theBoard.OtherTeamPieceSquares)
                {
                    if (theBoard.MoveIsValid(square, toSquare))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                //TODO
                //other piece that previously blocked the way is trying to unblock the way
            }
            return false;
        }

        private void FakeApply(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            theBoard.GetSquare(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            theBoard.GetSquare(toSquare.Row, toSquare.Col).ContainsPiece = true;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).Piece = null;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).ContainsPiece = false;
        }
    }
}
