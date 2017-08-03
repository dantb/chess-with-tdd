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
            if (fromSquare.Piece == king)
            {
                if (toSquare.Row == fromSquare.Row && Math.Abs(fromSquare.Col - toSquare.Col) == 2)
                {
                    if (!king.HasMoved && !king.InCheckState)
                    {
                        return true;

                    }
                }

            }
            return false;

            throw new NotImplementedException();
        }
    }
}
