namespace ChessWithTDD
{
    public interface IGenericMoveValidator
    {
        bool GenericSquareMoveValidationPasses(ISquare fromSquare, ISquare toSquare);
    }
}
