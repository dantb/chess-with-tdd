namespace ChessWithTDD
{
    /// <summary>
    /// Contains the data required to convert a move to a notation string. This class should be immutable.
    /// </summary>
    public class MoveConversionData : IMoveConversionData
    {
        public IMove Move { get; }
        public IPiece Piece { get; }
        public bool Check { get; }
        public bool CheckMate { get; }

        /// <summary>
        /// Extracts the necessary information from the squares, piece and state of the board to ascertain
        /// the data required by the string move generator. The check and checkmate state must be taken from
        /// the board.
        /// </summary>
        public MoveConversionData(ISquare fromSquare, ISquare toSquare, IPiece piece, IBoard board)
        {

        }
    }
}
