namespace ChessWithTDD
{
    public class Move
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
            if (obj is Move)
            {
                Move move = obj as Move;
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
