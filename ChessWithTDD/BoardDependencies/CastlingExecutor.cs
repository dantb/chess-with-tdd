using System;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    /// <summary>
    /// The responsibility of this class is to execute the rook's movement part of the castling move, as well as making sure
    /// the rook and king have there HasMoved set.
    /// </summary>
    public class CastlingExecutor : ICastlingExecutor
    {
        /// <summary>
        /// Executes special requirements necessary for a castling move. These are:
        /// 
        /// 1) The rook must move to the other side of the king.
        /// 2) The rook HasMoved is set to true.
        /// 3) The king HasMoved is set to true.
        /// 
        /// This method assumes there is a king in the fromSquare about to move
        /// </summary>
        public void ExecuteCastlingMove(ISquare fromSquare, ISquare toSquare, IBoard board)
        {
            bool sameRowMove = fromSquare.Row - toSquare.Row == 0;
            bool twoColsMove = Math.Abs(fromSquare.Col - toSquare.Col) == 2;
            if (sameRowMove && twoColsMove)
            {
                bool queenside = fromSquare.Col - toSquare.Col == 2;

                ISquare rookSquare = queenside
                   ? board.GetSquare(fromSquare.Row, LEFT_ROOK_COL)   //queenside castle
                   : board.GetSquare(fromSquare.Row, RIGHT_ROOK_COL); //kingside castle

                ISquare rookToSquare = queenside
                   ? board.GetSquare(fromSquare.Row, LEFT_ROOK_COL + 3)
                   : board.GetSquare(fromSquare.Row, RIGHT_ROOK_COL - 2);

                (rookSquare.Piece as IRook).HasMoved = true;

                rookToSquare.ContainsPiece = true;
                rookToSquare.Piece = rookSquare.Piece;
                rookSquare.ContainsPiece = false;
                rookSquare.Piece = null;
                board.PendingUpdates.Add(rookToSquare);
                board.PendingUpdates.Add(rookSquare);
            }

            // this should be set regardless of whether this is a castling move or not
            (fromSquare.Piece as IKing).HasMoved = true;
        }
    }
}
