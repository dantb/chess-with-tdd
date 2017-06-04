using System;

namespace ChessWithTDD
{
    public class MoveIntoCheckValidator : IMoveIntoCheckValidator
    {
        public bool MoveIsIntoCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IKing)
            {
                if (fromSquare.Piece.Colour == Colour.White)
                {
                    foreach (ISquare square in theBoard.BlackPieceSquares)
                    {
                        if (theBoard.MoveIsValid(square, toSquare))
                        {
                            return true;
                        }
                    }
                    return false;
                }
                else if (fromSquare.Piece.Colour == Colour.Black)
                {
                    foreach (ISquare square in theBoard.WhitePieceSquares)
                    {
                        if (theBoard.MoveIsValid(square, toSquare))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            throw new NotImplementedException();
        }
    }
}
