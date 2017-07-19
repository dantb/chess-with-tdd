namespace ChessWithTDD
{
    /// <summary>
    /// Contains the data required to convert a move to a notation string. This class should be immutable.
    /// </summary>
    public class MoveGenerationData
    {
        public IPiece Piece
        {
            get;
        }

        /// <summary>
        /// Extracts the necessary information from the squares, piece and state of the board to ascertain
        /// the data required by the string move generator. The check and checkmate state must be taken from
        /// the board.
        /// </summary>
        public MoveGenerationData(ISquare fromSquare, ISquare toSquare, IPiece piece, IBoard board)
        {
            Piece = piece;
        }
    }
}
