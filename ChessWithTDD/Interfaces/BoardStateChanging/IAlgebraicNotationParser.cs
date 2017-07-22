namespace ChessWithTDD
{
    public interface IAlgebraicNotationParser
    {
        MoveConversionData Parse(string oneMoveInNotation);
    }
}