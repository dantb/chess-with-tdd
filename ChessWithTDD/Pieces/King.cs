namespace ChessWithTDD
{
    public class King : IKing
    {
        private Colour _colour;
        private ICastlingMoveValidator _castlingMoveValidator;
        private IBoard _board;

        public King(Colour colour, ICastlingMoveValidator castlingMoveValidator, IBoard board)
        {
            _colour = colour;
            _castlingMoveValidator = castlingMoveValidator;
            _board = board;
        }

        public Colour Colour { get { return _colour; } }

        public bool InCheckState { get; set; } = false;
        public bool HasMoved { get; set; } = false;

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.IsAdjacentTo(fromSquare))
            {
                return true;
            }
            else if (_castlingMoveValidator.IsValidCastlingMove(this, _board, fromSquare, toSquare))
            {
                return true;
            }
            return false;
        }
    }
}