namespace ChessWithTDD
{
    public interface IAlgebraicNotationParser
    {
        IMove Parse(string oneMoveInNotation);
    }
}