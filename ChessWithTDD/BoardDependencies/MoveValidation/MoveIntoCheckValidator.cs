using System;

namespace ChessWithTDD
{
    public class MoveIntoCheckValidator : IMoveIntoCheckValidator
    {
        public bool MoveIsIntoCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IKing)
            {
                foreach (ISquare square in theBoard.OtherTeamPieceSquares)
                {
                    if (theBoard.MoveIsValid(square, toSquare))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                //if (fromSquare.Piece.Colour == Colour.White)
                //{
                //    bool intoCheck = false;
                //    //remember contents of to square
                //    IPiece toSquarePiece = toSquare.Piece;
                //    bool toSquareContainsPiece = toSquare.ContainsPiece;
                //    //fake apply the move
                //    FakeApply(theBoard, fromSquare, toSquare);
                //    //check whether there's a black piece that can take the king now
                //    foreach (ISquare square in theBoard.BlackPieceSquares)
                //    {
                //        if (theBoard.MoveIsValid(square, theBoard.WhiteKingSquare))
                //        {
                //            intoCheck = true;
                //        }
                //    }
                //    //undo the move
                //    FakeApply(theBoard, toSquare, fromSquare);
                //    //reset the to square
                //    toSquare.Piece = toSquarePiece;
                //    toSquare.ContainsPiece = toSquareContainsPiece;
                //    return intoCheck;
                //}
            }
            return false;
            throw new NotImplementedException();
        }

        private void FakeApply(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            theBoard.GetSquare(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            theBoard.GetSquare(toSquare.Row, toSquare.Col).ContainsPiece = true;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).Piece = null;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).ContainsPiece = false;
        }
    }
}
