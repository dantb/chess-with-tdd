using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class GenericMoveValidator : IGenericMoveValidator
    {
        public bool GenericSquareMoveValidationPasses(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Row >= BOARD_DIMENSION || fromSquare.Col >= BOARD_DIMENSION ||
                toSquare.Row >= BOARD_DIMENSION || toSquare.Col >= BOARD_DIMENSION)
            {
                return false;
            }
            else if (fromSquare.Row < BOARD_LOWER_DIMENSION || fromSquare.Col < BOARD_LOWER_DIMENSION ||
                     toSquare.Row < BOARD_LOWER_DIMENSION || toSquare.Col < BOARD_LOWER_DIMENSION)
            {
                return false;
            }
            else if (!fromSquare.ContainsPiece)
            {
                return false;
            }
            else if (toSquare.Row == fromSquare.Row && toSquare.Col == fromSquare.Col)
            {
                return false;
            }
            else if (fromSquare.Piece.Colour != Colour.Black && fromSquare.Piece.Colour != Colour.White)
            {
                return false;
            }
            else if (toSquare.ContainsPiece && toSquare.Piece.Colour == fromSquare.Piece.Colour)
            {
                return false;
            }
            return true;
        }
    }
}
