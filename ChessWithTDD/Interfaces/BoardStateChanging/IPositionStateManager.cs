namespace ChessWithTDD
{
    public interface IPositionStateManager
    {
        void SaveMove(MoveGenerationData data);

        /// <summary>
        /// Returns a board with the last move undone, or an initialised board if there hasn't been a move.
        /// </summary>
        IBoard UndoneMoveBoard();

        /// <summary>
        /// Returns a board with the last move redone, or the latest board state possible if there are no moves
        /// that can be redone (i.e. we're up to date)
        /// </summary>
        IBoard RedoneMoveBoard(IBoard oldBoard);
    }
}