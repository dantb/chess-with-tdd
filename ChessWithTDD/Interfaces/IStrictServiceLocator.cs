namespace ChessWithTDD
{
    /// <summary>
    /// A strict service locator does not use generics and must explicitly provide required services.
    /// It is therefore guaranteed at runtime that the locator can locate any services it's asked to.
    /// </summary>
    public interface IStrictServiceLocator
    {
        IBoardCache GetServiceBoardCache();

        IBoardInitialiser GetServiceBoardInitialiser();

        ICheckManager GetServiceCheckManager();

        IMoveValidator GetServiceMoveValidator();

        IPawnManager GetServicePawnManager();

        IMoveExecutor GetServiceMoveExecutor();

        IMoveIntoCheckValidator GetServiceMoveIntoCheckValidator();
    }
}
