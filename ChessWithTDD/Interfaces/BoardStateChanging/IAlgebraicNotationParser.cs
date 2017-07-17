namespace ChessWithTDD
{
    public interface IAlgebraicNotationParser
    {
        Move Parse(string oneMoveInNotation);
    }
}