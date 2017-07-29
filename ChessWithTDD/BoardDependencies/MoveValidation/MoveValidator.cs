namespace ChessWithTDD
{
    public class MoveValidator : IMoveValidator
    {
        private IGenericMoveValidator _genericMoveValidator;
        private IMultiSquareMoveValidator _multiMoveValidator;
        private IMoveIntoCheckValidator _moveIntoCheckValidator;

        public MoveValidator(IGenericMoveValidator genericMoveValidator,
                             IMultiSquareMoveValidator multiMoveValidator,
                             IMoveIntoCheckValidator moveIntoCheckValidator)
        {
            _genericMoveValidator = genericMoveValidator;
            _multiMoveValidator = multiMoveValidator;
            _moveIntoCheckValidator = moveIntoCheckValidator;
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
            //else if (_moveIntoCheckValidator.MoveCausesMovingTeamCheck(theBoard, fromSquare, toSquare))
            //{
            //    return false;
            //}
            return true;
        }
    } 
}
