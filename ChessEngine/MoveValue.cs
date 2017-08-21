namespace ChessEngine
{
    /// <summary>
    /// DTO containing a data for a move with its corresponding board value
    /// </summary>
    public class MoveValue
    {
        public MoveValue(MoveData moveData, double value)
        {
            MoveData = moveData;
            Value = value;
        }

        public MoveData MoveData { get; }
        public double Value { get; }
    }
}
