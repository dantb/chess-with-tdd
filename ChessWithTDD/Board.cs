using System;
using System.Collections.Generic;
using System.Linq;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    [Serializable]
    public class Board : IBoard
    {
        private List<List<ISquare>> _squares;
        private Dictionary<int, ISquare> _squaresMarkedWithEnPassantKeyedByTurn = new Dictionary<int, ISquare>();

        public Board()
        {
            InitialiseBoardDimensions();
            BoardInitialiser.InitialiseBoardPieces(this);
        }

        public int TurnCounter { get; set; } = 0;

        public int ColCount
        {
            get
            {
                return _squares.Count;
            }
        }

        public int RowCount
        {
            get
            {
                return _squares.FirstOrDefault().Count;
            }
        }

        public ISquare GetSquare(int row, int col)
        {
            return _squares[row][col];
        }

        public bool IsValidMove(ISquare fromSquare, ISquare toSquare)
        {
            if (!GenericBoardMoveValidationPasses(fromSquare, toSquare))
            {
                return false;
            }

            if (MultiSquareMoveIsBlockedByAnObstacle(fromSquare, toSquare))
            {
                return false;
            }

            return fromSquare.Piece.CanMove(fromSquare, toSquare);
        }

        private bool GenericBoardMoveValidationPasses(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Row >= BOARD_DIMENSION || fromSquare.Col >= BOARD_DIMENSION
                || toSquare.Row >= BOARD_DIMENSION || toSquare.Col >= BOARD_DIMENSION)
            {
                return false;
            }
            else if (fromSquare.Row < BOARD_LOWER_DIMENSION || fromSquare.Col < BOARD_LOWER_DIMENSION
                || toSquare.Row < BOARD_LOWER_DIMENSION || toSquare.Col < BOARD_LOWER_DIMENSION)
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
            else if (fromSquare.Piece.Colour == Colour.Invalid)
            {
                return false;
            }
            else if (toSquare.ContainsPiece && toSquare.Piece.Colour == fromSquare.Piece.Colour)
            {
                return false;
            }
            return true;
        }

        private bool MultiSquareMoveIsBlockedByAnObstacle(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.Row == fromSquare.Row && Math.Abs(toSquare.Col - fromSquare.Col) >= 2)
            {
                //moving multiple horizontally
                if (toSquare.Col > fromSquare.Col)
                {
                    //moving east
                    for (int i = fromSquare.Col + 1; i < toSquare.Col; i++)
                    {
                        if (GetSquare(toSquare.Row, i).ContainsPiece)
                        {
                            return true;
                        }
                    }
                }
                else if (toSquare.Col < fromSquare.Col)
                {
                    //moving west
                    for (int i = fromSquare.Col - 1; i > toSquare.Col; i--)
                    {
                        if (GetSquare(toSquare.Row, i).ContainsPiece)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (toSquare.Col == fromSquare.Col && Math.Abs(toSquare.Row - fromSquare.Row) >= 2)
            {
                //moving multiple vertically
                if (toSquare.Row > fromSquare.Row)
                {
                    //moving up
                    for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                    {
                        if (GetSquare(i, toSquare.Col).ContainsPiece)
                        {
                            return true;
                        }
                    }
                }
                else if (toSquare.Row < fromSquare.Row)
                {
                    //moving down
                    for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                    {
                        if (GetSquare(i, toSquare.Col).ContainsPiece)
                        {
                            return true;
                        }
                    }
                }
            }
            else if (toSquare.Row - fromSquare.Row >= 2 && fromSquare.Col - toSquare.Col >= 2)
            {
                //north west
                int initialCol = fromSquare.Col - 1;
                for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                {
                    if (GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol--;
                }
            }
            else if (toSquare.Row - fromSquare.Row >= 2 && toSquare.Col - fromSquare.Col >= 2)
            {
                //north east
                int initialCol = fromSquare.Col + 1;
                for (int i = fromSquare.Row + 1; i < toSquare.Row; i++)
                {
                    if (GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol++;
                }
            }
            else if (fromSquare.Row - toSquare.Row >= 2 && fromSquare.Col - toSquare.Col >= 2)
            {
                //south west
                int initialCol = fromSquare.Col - 1;
                for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                {
                    if (GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol--;
                }
            }
            else if (fromSquare.Row - toSquare.Row >= 2 && toSquare.Col - fromSquare.Col >= 2)
            {
                //south east
                int initialCol = fromSquare.Col + 1;
                for (int i = fromSquare.Row - 1; i > toSquare.Row; i--)
                {
                    if (GetSquare(i, initialCol).ContainsPiece)
                    {
                        return true;
                    }
                    initialCol++;
                }
            }

            return false;
        }

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IPawn)
            {
                MakePawnSpecificAmendments(fromSquare, toSquare);
            }

            if (_squaresMarkedWithEnPassantKeyedByTurn.ContainsKey(TurnCounter - 2))
            {
                //Unmark the square and remove from dictionary
                _squaresMarkedWithEnPassantKeyedByTurn[TurnCounter - 2].HasEnPassantMark = false;
                _squaresMarkedWithEnPassantKeyedByTurn.Remove(TurnCounter - 2);
            }

            GetSquare(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            GetSquare(toSquare.Row, toSquare.Col).ContainsPiece = true;
            GetSquare(fromSquare.Row, fromSquare.Col).Piece = null;
            GetSquare(fromSquare.Row, fromSquare.Col).ContainsPiece = false;

            TurnCounter++;
        }

        private void MakePawnSpecificAmendments(ISquare fromSquare, ISquare toSquare)
        {
            MarkSquareWithEnPassantIfApplicable(fromSquare, toSquare);
            IPawn pawn = fromSquare.Piece as IPawn;
            if (!pawn.HasMoved)
            {
                pawn.HasMoved = true;
            }
            CapturePieceThroughEnPassantIfApplicable(fromSquare, toSquare);
        }

        private void CapturePieceThroughEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.HasEnPassantMark && BlackPawn.MoveIsDiagonallyDownwards(fromSquare, toSquare))
            {
                CapturePieceThroughEnPassantAndUnmarkSquare(toSquare.Row + 1, toSquare.Col, toSquare.Row);
            }
            else if (toSquare.HasEnPassantMark && WhitePawn.MoveIsDiagonallyUpwards(fromSquare, toSquare))
            {
                CapturePieceThroughEnPassantAndUnmarkSquare(toSquare.Row - 1, toSquare.Col, toSquare.Row);
            }
        }

        private void MarkSquareWithEnPassantIfApplicable(ISquare fromSquare, ISquare toSquare)
        {
            if (toSquare.Row == fromSquare.Row + 2)
            {
                MarkSquareWithEnPassantAndAddToDictionary(fromSquare.Row + 1, fromSquare.Col);
            }
            else if (toSquare.Row == fromSquare.Row - 2)
            {
                MarkSquareWithEnPassantAndAddToDictionary(fromSquare.Row - 1, fromSquare.Col);
            }
        }

        private void MarkSquareWithEnPassantAndAddToDictionary(int rowToMark, int coltoMark)
        {
            ISquare squareToMark = GetSquare(rowToMark, coltoMark);
            squareToMark.HasEnPassantMark = true;
            _squaresMarkedWithEnPassantKeyedByTurn.Add(TurnCounter, squareToMark);
        }

        private void CapturePieceThroughEnPassantAndUnmarkSquare(int rowOfPiece, int colOfPiece, int rowOfMarkedSquare)
        {
            ISquare squareOfPieceThatPassed = GetSquare(rowOfPiece, colOfPiece);
            squareOfPieceThatPassed.Piece = null;
            squareOfPieceThatPassed.ContainsPiece = false;
            //unmark square to on this board
            GetSquare(rowOfMarkedSquare, colOfPiece).HasEnPassantMark = false;
        }

        internal void SetSquare(ISquare square)
        {
            _squares[square.Row][square.Col] = square;
        }

        internal void SetSquaresOnBoard(params ISquare[] squares)
        {
            foreach (var square in squares)
            {
                SetSquare(square);
            }
        }

        private void InitialiseBoardDimensions()
        {
            _squares = new List<List<ISquare>>();
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                List<ISquare> rowOfBoard = new List<ISquare>();
                for (int j = 0; j < BOARD_DIMENSION; j++)
                {
                    rowOfBoard.Add(new Square(i, j));
                }
                _squares.Add(rowOfBoard);
            }
        }
    }
}
