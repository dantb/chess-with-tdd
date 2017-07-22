namespace ChessWithTDD
{
    /// <summary>
    /// Contains the data required to convert a move to a notation string. This class should be immutable.
    /// </summary>
    public class MoveGenerationData : MoveConversionData
    {
        public IPiece Piece { get; }

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
