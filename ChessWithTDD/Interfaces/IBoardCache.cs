namespace ChessWithTDD
{
    public interface IBoardCache
    {
        void InitialiseBoardCache(IBoard theBoard);
        void UpdateBoardCache();
        ISquare BlackKingSquare
        {
            get;
        }
        ISquare WhiteKingSquare
        {
            get;
        }
        IBoard TheBoard
        {
            get;
        }
    }
}
