namespace ChessWithTDD
{
    public class MoveConversionData : IMoveConversionData
    {
        public IMove Move { get; }
        public IPiece Piece { get; }
        public bool Check { get; }
        public bool CheckMate { get; }

        public MoveConversionData(ISquare fromSquare, ISquare toSquare, IPiece piece, IBoard board)
        {
            //extract the information we want in the constructor
        }
    }
}
