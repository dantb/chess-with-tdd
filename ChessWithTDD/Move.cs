namespace ChessWithTDD
{
    public class Move : IMove
    {
        public Move(ISquare fromSquare, ISquare toSquare)
        {
            FromSquare = fromSquare;
            ToSquare = toSquare;
        }

        public ISquare FromSquare { get; set; }
        public ISquare ToSquare { get; set; }

        public void ApplyToBoard(IBoard board)
        {
            board.GetSquare(FromSquare.Row, FromSquare.Col).ContainsPiece = false;
            board.GetSquare(ToSquare.Row, ToSquare.Col).Piece = board.GetSquare(FromSquare.Row, FromSquare.Col).Piece;
            board.GetSquare(FromSquare.Row, FromSquare.Col).Piece = null;
            board.GetSquare(ToSquare.Row, ToSquare.Col).ContainsPiece = true;
        }
    }
}
