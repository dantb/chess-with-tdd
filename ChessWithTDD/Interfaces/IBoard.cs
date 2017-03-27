using System.Collections.Generic;

namespace ChessWithTDD
{
    public interface IBoard
    {
        int RowCount { get; }
        int ColCount { get; }
        int TurnCounter { get; set; }
        bool InCheckState { get; set; }
        bool CheckMate { get; set; }

        /// <summary>
        /// Cache holds the squares corresponding to specific pieces. For example both kings should be easily
        /// accessible in order to check for "check" efficiently.
        /// </summary>
        Dictionary<BoardCacheEnum, ISquare> BoardCache { get; set; }

        /// <summary>
        /// Returns a clone of the square at position (row, col) on the board.
        /// To change the state of the board you should use Apply, after checking move validity with IsValidMove.
        /// </summary>
        ISquare GetSquare(int row, int col);

        /// <summary>
        /// Use to check the validity of a given move. Combines general board validation with specific piece validation.
        /// </summary>
        /// <param name="fromSquare">Square containing the piece you want to check.</param>
        /// <param name="toSquare">Square to check your piece against.</param>
        /// <returns></returns>
        bool IsValidMove(ISquare fromSquare, ISquare toSquare);

        /// <summary>
        /// This is the only way you can change the state of the board. The move is applied to the piece in the from square,
        /// capturing the piece in the to square if it exists.
        /// </summary>
        /// <param name="fromSquare">Square containing the piece to be moved.</param>
        /// <param name="toSquare">Square the piece will be moved to, capturing pieces as required.</param>
        void Apply(ISquare fromSquare, ISquare toSquare);
    }

    public enum BoardCacheEnum
    {
        BlackKing,
        WhiteKing
    }
}
