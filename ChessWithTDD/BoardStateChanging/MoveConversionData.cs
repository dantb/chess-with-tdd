namespace ChessWithTDD
{
    /// <summary>
    /// Contains the data required to convert a notation string to a move. This class should be immutable.
    /// </summary>
    public class MoveConversionData
    {
        public Move Move { get; }
        public bool Check { get; }
        public bool CheckMate { get; }

        /// <summary>
        /// Extracts the necessary information from the squares and state of the board. 
        /// The check and checkmate state must be taken from the board so the move must have already been applied.
        /// </summary>
        public MoveConversionData(ISquare fromSquare, ISquare toSquare, IBoard board)
        {
            Move = new Move(fromSquare.Row, fromSquare.Col, toSquare.Row, toSquare.Col);
            Check = board.InCheck;
            CheckMate = board.CheckMate;
        }

        /// <summary>
        /// Creates an instance of <see cref="MoveConversionData"/> directly from the arguments provided.
        /// </summary>
        public MoveConversionData(Move move, bool check, bool checkMate)
        {
            Move = move;
            Check = check;
            CheckMate = checkMate;
        }
    }
}
