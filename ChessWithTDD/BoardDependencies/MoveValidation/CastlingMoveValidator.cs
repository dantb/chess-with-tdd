using System;

namespace ChessWithTDD
{
    public class CastlingMoveValidator : ICastlingMoveValidator
    {
        private IMoveIntoCheckValidator _moveIntoCheckValidator;

        public CastlingMoveValidator(IMoveIntoCheckValidator moveIntoCheckValidator)
        {
            _moveIntoCheckValidator = moveIntoCheckValidator;
        }

        public bool IsValidCastlingMove(IKing king, IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            return false;

            throw new NotImplementedException();
        }
    }
}
