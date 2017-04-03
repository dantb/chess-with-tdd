namespace ChessWithTDD
{
    public class MoveValidator : IMoveValidator
    {
        private IGenericMoveValidator _genericMoveValidator;
        private IMultiSquareMoveValidator _multiMoveValidator;

        public MoveValidator(IGenericMoveValidator genericMoveValidator, IMultiSquareMoveValidator multiMoveValidator)
        {
            _genericMoveValidator = genericMoveValidator;
            _multiMoveValidator = multiMoveValidator;
        }

        public bool MoveIsValid(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (!_genericMoveValidator.GenericSquareMoveValidationPasses(fromSquare, toSquare))
            {
                return false;
            }
            else if (_multiMoveValidator.MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare, theBoard))
            {
                return false;
            }
            return true;
        }
    } 
}
