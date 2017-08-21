using System;
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
                if (toSquare.IsOneSquareDiagonallyAbove(fromSquare))
                {
                    CapturePieceThroughEnPassantAndUnmarkSquare(toSquare.Row - 1, toSquare.Col, toSquare.Row, theBoard);
                }
                else if (toSquare.IsOneSquareDiagonallyBelow(fromSquare))
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

        public bool MoveIsInvalidEnPassantCapture(ISquare fromSquare, ISquare toSquare, IBoard theBoard)
        {
            if (fromSquare.Piece is IPawn)
            {
                int rowDiff = Math.Abs(fromSquare.Row - toSquare.Row);
                int colDiff = Math.Abs(fromSquare.Col - toSquare.Col);

                if (rowDiff == colDiff)
                {
                    // diagonal move
                    if (!toSquare.ContainsPiece)
                    {
                        if (!toSquare.HasEnPassantMark)
                        {
                            // can't move diagonally if no piece or en passant mark
                            return true;
                        }
                        else
                        {
                            // does have en passant mark, now check the board
                            if (fromSquare.Piece.Colour == Colour.White)
                            {
                                ISquare blackPawnSquare = theBoard.GetSquare(toSquare.Row - 1, toSquare.Col);
                                if (!(blackPawnSquare.Piece is IPawn) || blackPawnSquare.Piece.Colour == Colour.White)
                                {
                                    return true;
                                }
                            }
                            else
                            {
                                ISquare whitePawnSquare = theBoard.GetSquare(toSquare.Row + 1, toSquare.Col);
                                if (!(whitePawnSquare.Piece is IPawn) || whitePawnSquare.Piece.Colour == Colour.Black)
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            return false;
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
