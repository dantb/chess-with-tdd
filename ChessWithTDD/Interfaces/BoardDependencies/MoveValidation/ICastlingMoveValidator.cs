namespace ChessWithTDD
{
    public interface ICastlingMoveValidator
    {
        bool IsValidCastlingMove(IKing king, IBoard board, ISquare fromSquare, ISquare toSquare);
    }
}
