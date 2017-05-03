namespace ChessWithTDD
{
    public class Move : IMove
    {
        public Move(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            FromRow = rowFrom;
            FromCol = colFrom;
            ToRow = rowTo;
            ToCol = colTo;
        }

        public int FromRow { get; }
        public int FromCol { get; }
        public int ToRow { get; }
        public int ToCol { get; }
    }
}
