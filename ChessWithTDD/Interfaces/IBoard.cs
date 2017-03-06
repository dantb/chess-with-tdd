namespace ChessWithTDD
{
    public interface IBoard
    {
        int RowCount { get; }
        int ColCount { get; }
        ISquare GetSquare(int row, int col);
        void SetSquare(ISquare square);
        bool IsValidMove(ISquare fromSquare, ISquare toSquare);
        void Apply(ISquare fromSquare, ISquare toSquare);
    }
}
