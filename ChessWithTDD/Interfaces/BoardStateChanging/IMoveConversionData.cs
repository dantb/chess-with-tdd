namespace ChessWithTDD
{
    public interface IMoveConversionData
    {
        bool Check
        {
            get;
        }
        bool CheckMate
        {
            get;
        }
        IMove Move
        {
            get;
        }
    }
}