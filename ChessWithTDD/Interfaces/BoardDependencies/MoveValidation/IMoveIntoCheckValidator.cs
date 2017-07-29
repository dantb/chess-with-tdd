namespace ChessWithTDD
{
    /// <summary>
    /// This class should be used to evaluate whether a move will result in the moving team's king being in check.
    /// It should be used prior to all other validation since it requires simulation of moves to be able analyse the resulting
    /// board.
    /// </summary>
    public interface IMoveIntoCheckValidator
    {
        /// <summary>
        /// A dependency of this method is that the move in question must have a already passed all other validation
        /// since we have to simulate that the move was applied. In the case that the move wasn't actually valid, this will
        /// just screw up the simulated board and result in an unreliable return value
        /// </summary>
        bool MoveCausesMovingTeamCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare);
    }
}
