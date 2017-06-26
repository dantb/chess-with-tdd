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

        public override bool Equals(object obj)
        {
            if (obj is IMove)
            {
                IMove move = obj as IMove;
                return move.FromCol.Equals(FromCol) 
                    && move.FromRow.Equals(FromRow) 
                    && move.ToCol.Equals(ToCol) 
                    && move.ToRow.Equals(ToRow);
            }
            return base.Equals(obj);
        }

        public int FromRow { get; }
        public int FromCol { get; }
        public int ToRow { get; }
        public int ToCol { get; }
    }
}
