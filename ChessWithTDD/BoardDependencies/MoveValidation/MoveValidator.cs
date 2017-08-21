namespace ChessWithTDD
{
    public class MoveValidator : IMoveValidator
    {
        private IGenericMoveValidator _genericMoveValidator;
        private IMultiSquareMoveValidator _multiMoveValidator;
        private IEnPassantManager _enPassantManager;

        public MoveValidator(IGenericMoveValidator genericMoveValidator,
                             IMultiSquareMoveValidator multiMoveValidator,
                             IEnPassantManager enPassantManager)
        {
            _genericMoveValidator = genericMoveValidator;
            _multiMoveValidator = multiMoveValidator;
            _enPassantManager = enPassantManager;
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
            else if (_enPassantManager.MoveIsInvalidEnPassantCapture(fromSquare, toSquare, theBoard))
            {
                return false;
            }

            return true;
        }
    } 
}
