namespace ChessWithTDD
{
    public interface IPositionStateManager
    {
        void SaveMove(ISquare fromSquare, ISquare toSquare, IBoard board);

        IBoard UndoMoveBoard();

        IBoard RedoMoveBoard();
    }
}