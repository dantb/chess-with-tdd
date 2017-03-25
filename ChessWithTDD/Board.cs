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
            return (ISquare) _squares[row][col];//.Clone();
        }

        internal ISquare GetSquareInternal(int row, int col)
        {
            return _squares[row][col];
        }

        public bool IsValidMove(ISquare fromSquare, ISquare toSquare)
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
            return fromSquare.Piece.CanMove(fromSquare, toSquare);
        }

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IPawn)
            {
                if (toSquare.Row == fromSquare.Row + 2)
                {
                    ISquare squareToMark = GetSquareInternal(fromSquare.Row + 1, fromSquare.Col);
                    squareToMark.HasEnPassantMark = true;
                    _squaresMarkedWithEnPassantKeyedByTurn.Add(TurnCounter, squareToMark);
                }
                else if (toSquare.Row == fromSquare.Row - 2)
                {
                    ISquare squareToMark = GetSquareInternal(fromSquare.Row - 1, fromSquare.Col);
                    squareToMark.HasEnPassantMark = true;
                    _squaresMarkedWithEnPassantKeyedByTurn.Add(TurnCounter, squareToMark);
                }
                IPawn pawn = fromSquare.Piece as IPawn;
                if (!pawn.HasMoved)
                {
                    pawn.HasMoved = true;
                }
            }

            if (_squaresMarkedWithEnPassantKeyedByTurn.ContainsKey(TurnCounter - 2))
            {
                //Unmark the square and remove from dictionary
                _squaresMarkedWithEnPassantKeyedByTurn[TurnCounter - 2].HasEnPassantMark = false;
                _squaresMarkedWithEnPassantKeyedByTurn.Remove(TurnCounter - 2);
            }

            GetSquareInternal(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            GetSquareInternal(toSquare.Row, toSquare.Col).ContainsPiece = true;
            GetSquareInternal(fromSquare.Row, fromSquare.Col).Piece = null;
            GetSquareInternal(fromSquare.Row, fromSquare.Col).ContainsPiece = false;

            TurnCounter++;
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
