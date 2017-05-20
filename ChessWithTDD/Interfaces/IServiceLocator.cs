namespace ChessWithTDD
{
    interface IServiceLocator
    {
        T GetService<T>();
    }
}
