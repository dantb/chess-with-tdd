namespace ChessWithTDD
{
    public class Rook : IRook
    {
        private Colour _colour;

        public Rook(Colour colour)
        {
            _colour = colour;
        }

        public Colour Colour { get { return _colour; } }

        public bool HasMoved { get; set; }

        public bool CanMove(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.IsInSameRowAs(fromSquare) ||
                toSquare.IsInSameColumnAs(fromSquare))
            {
                return true;
            }
            return false;
        }
    }
}