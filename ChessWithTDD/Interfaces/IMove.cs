namespace ChessWithTDD
{
    public interface IMove
    {
        int FromRow { get; }
        int FromCol { get; }
        int ToRow { get; }
        int ToCol { get; }
    }
}