namespace ChessWithTDD
{
    public interface IPiece
    {
        Colour Colour { get; }

        /// <summary>
        /// Indicates whether this piece can execute a given move. This is independent of the board and only blocks moves 
        /// on the basis of them having already passed board validation. For that reason, this should never be called directly
        /// for anything other than testing. The board's validation is all that's required.
        /// </summary>
        /// <param name="theMove"></param>
        /// <returns></returns>
        bool CanMove(ISquare fromSquare, ISquare toSquare);
    }

    public enum Colour
    {
        Black,
        White,
        Invalid
    }
}
