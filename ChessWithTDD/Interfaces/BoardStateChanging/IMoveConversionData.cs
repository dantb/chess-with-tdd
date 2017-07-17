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
        Move Move
        {
            get;
        }
    }
}