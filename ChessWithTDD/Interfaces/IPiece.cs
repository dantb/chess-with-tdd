namespace ChessWithTDD
{
    public interface IPiece
    {
        Colour Colour
        {
            get;
        }

        /// <summary>
        /// Indicates whether this piece can execute a given move. This is independent of the board and so does not 
        /// care, for example, if there is an obstruction to the move for a specific board.
        /// </summary>
        /// <param name="theMove"></param>
        /// <returns></returns>
        bool CanMove(IMove theMove);
    }

    public enum Colour
    {
        Black,
        White,
        Invalid
    }
}
