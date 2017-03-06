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

        public int FromRow { get; private set; }
        public int FromCol { get; private set; }
        public int ToRow { get; private set; }
        public int ToCol { get; private set; }
    }
}
