using System.Collections.Generic;

namespace ChessWithTDD
{
    public class EnPassantManager : IEnPassantManager
    {
        private Dictionary<int, ISquare> _squaresMarkedWithEnPassantKeyedByTurn = new Dictionary<int, ISquare>();

        public void CapturePieceThroughEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (toSquare.HasEnPassantMark)
            {
                if (WhitePawn.MoveIsDiagonallyUpwards(fromSquare, toSquare))
                {
                    CapturePieceThroughEnPassantAndUnmarkSquare(toSquare.Row - 1, toSquare.Col, toSquare.Row, theBoard);

                }
                else if (BlackPawn.MoveIsDiagonallyDownwards(fromSquare, toSquare))
                {
                    CapturePieceThroughEnPassantAndUnmarkSquare(toSquare.Row + 1, toSquare.Col, toSquare.Row, theBoard);
                }
            }
        }

        public void MarkSquareWithEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (toSquare.Row == fromSquare.Row + 2)
            {
                MarkSquareWithEnPassantAndAddToDictionary(fromSquare.Row + 1, fromSquare.Col, theBoard);
            }
            else if (toSquare.Row == fromSquare.Row - 2)
            {
                MarkSquareWithEnPassantAndAddToDictionary(fromSquare.Row - 1, fromSquare.Col, theBoard);
            }
        }

        public void UnmarkEnPassantSquares(int turnCounter)
        {
            if (_squaresMarkedWithEnPassantKeyedByTurn.ContainsKey(turnCounter - 2))
            {
                //Unmark the square and remove from dictionary
                _squaresMarkedWithEnPassantKeyedByTurn[turnCounter - 2].HasEnPassantMark = false;
                _squaresMarkedWithEnPassantKeyedByTurn.Remove(turnCounter - 2);
            }
        }

        private void CapturePieceThroughEnPassantAndUnmarkSquare(int rowOfPiece, int colOfPiece, int rowOfMarkedSquare, IBoard theBoard)
        {
            ISquare squareOfPieceThatPassed = theBoard.GetSquare(rowOfPiece, colOfPiece);
            squareOfPieceThatPassed.Piece = null;
            squareOfPieceThatPassed.ContainsPiece = false;
            //unmark square to on this board
            theBoard.GetSquare(rowOfMarkedSquare, colOfPiece).HasEnPassantMark = false;
            //add the square which had the taken pawn to pending updates - it's not the to or from square but needs to be updated
            theBoard.PendingUpdates.Add(squareOfPieceThatPassed);
        }

        private void MarkSquareWithEnPassantAndAddToDictionary(int rowToMark, int coltoMark, IBoard theBoard)
        {
            ISquare squareToMark = theBoard.GetSquare(rowToMark, coltoMark);
            squareToMark.HasEnPassantMark = true;
            _squaresMarkedWithEnPassantKeyedByTurn.Add(theBoard.TurnCounter, squareToMark);
        }
    }
}
