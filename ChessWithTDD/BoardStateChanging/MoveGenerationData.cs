namespace ChessWithTDD
{
    /// <summary>
    /// Contains the data required to convert a move to a notation string. This class should be immutable.
    /// </summary>
    public class MoveGenerationData : MoveConversionData
    {
        public IPiece Piece { get; }

        /// <summary>
        /// Creates an instance directly and additionally sets the Piece property as required.
        /// </summary>
        public MoveGenerationData(Move move, bool check, bool checkMate, IPiece piece)
            : base(move, check, checkMate)
        {
            Piece = piece;
        }

        /// <summary>
        /// Creates an instance from the base constructor but additionally sets the Piece property as required.
        /// the board.
        /// </summary>
        public MoveGenerationData(ISquare fromSquare, ISquare toSquare, IBoard board, IPiece piece)
            : base(fromSquare, toSquare, board)
        {
            Piece = piece;
        }
    }
}
