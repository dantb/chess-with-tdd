using System;
using static ChessWithTDD.BoardConstants;

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
            if (IsCastlingCandidate(king, fromSquare, toSquare))
            {
                bool queenside = fromSquare.Col - toSquare.Col == 2;

                ISquare rookSquare = queenside
                    ? board.GetSquare(fromSquare.Row, LEFT_ROOK_COL)   //queenside castle
                    : board.GetSquare(fromSquare.Row, RIGHT_ROOK_COL); //kingside castle

                if (RookSquareIsValid(rookSquare))
                {
                    if (!PieceIsBetweenKingAndRook(board, fromSquare, queenside, rookSquare))
                    {
                        if (!KingHasToMoveThroughCheck(board, fromSquare, queenside) &&
                            !KingHasToMoveIntoCheck(board, fromSquare, queenside))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Peforms some basic validation on the king and squares to determine whether the move is a candidate for castling
        /// </summary>
        private bool IsCastlingCandidate(IKing king, ISquare fromSquare, ISquare toSquare)
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
        }

        private bool RookSquareIsValid(ISquare rookSquare)
        {
            return rookSquare.ContainsPiece && 
                   rookSquare.Piece is IRook && 
                   !(rookSquare.Piece as IRook).HasMoved;
        }

        private bool KingHasToMoveThroughCheck(IBoard board, ISquare fromSquare, bool queenside)
        {
            return queenside
                ? MoveIsIntoCheck(board, fromSquare, fromSquare.Col - 1)
                : MoveIsIntoCheck(board, fromSquare, fromSquare.Col + 1);
        }

        private bool KingHasToMoveIntoCheck(IBoard board, ISquare fromSquare, bool queenside)
        {
            return queenside
                ? MoveIsIntoCheck(board, fromSquare, fromSquare.Col - 2)
                : MoveIsIntoCheck(board, fromSquare, fromSquare.Col + 2);
        }

        private bool MoveIsIntoCheck(IBoard board, ISquare fromSquare, int toCol)
        {
            return _moveIntoCheckValidator
                .MoveCausesMovingTeamCheck(board, fromSquare, board.GetSquare(fromSquare.Row, toCol));
        }

        private bool PieceIsBetweenKingAndRook(IBoard board, ISquare fromSquare, bool queenside, ISquare rookSquare)
        {
            if (queenside)
            {
                for (int col = fromSquare.Col - 1; col > rookSquare.Col; col--)
                {
                    if (board.GetSquare(fromSquare.Row, col).ContainsPiece)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int col = fromSquare.Col + 1; col < rookSquare.Col; col++)
                {
                    if (board.GetSquare(fromSquare.Row, col).ContainsPiece)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
