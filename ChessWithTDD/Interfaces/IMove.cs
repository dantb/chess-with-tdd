namespace ChessWithTDD
{
    public interface IMove
    {
        ISquare FromSquare { get; set; }
        ISquare ToSquare { get; set; }
        bool Equals(object obj);
    }
}