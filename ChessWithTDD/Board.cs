using System.Collections.Generic;
using System.Linq;

namespace ChessWithTDD
{
    public class Board : IBoard
    {
        private const int BOARD_DIMENSION = 8;
        private const int WHITE_BACK_ROW = 0;
        private const int BLACK_BACK_ROW = 7;
        private const int LEFT_ROOK_COL = 0;
        private const int RIGHT_ROOK_COL = 7;
        private const int LEFT_KNIGHT_COL = 1;
        private const int RIGHT_KNIGHT_COL = 6;
        private const int LEFT_BISHOP_COL = 2;
        private const int RIGHT_BISHOP_COL = 5;
        private const int QUEEN_COLUMN = 3;
        private const int KING_COLUMN = 4;
        private const int WHITE_PAWN_INITAL_ROW = 1;
        private const int BLACK_PAWN_INITAL_ROW = 6;
        private List<List<ISquare>> squares;

        public Board()
        {
            squares = new List<List<ISquare>>();
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                List<ISquare> rowOfBoard = new List<ISquare>();
                for (int j = 0; j < BOARD_DIMENSION; j++)
                {
                    rowOfBoard.Add(new Square(i, j));
                }
                squares.Add(rowOfBoard);
            }
            InitialiseBoard();
        }

        public int ColCount
        {
            get
            {
                return squares.Count;
            }
        }

        public int RowCount
        {
            get
            {
                return squares.FirstOrDefault().Count;
            }
        }

        public ISquare GetSquare(int row, int col)
        {
            return squares[row][col];
        }

        public bool IsValidMove(IMove move)
        {
            if (move.FromSquare.Row >= RowCount || move.FromSquare.Col >= ColCount
                || move.ToSquare.Row >= RowCount || move.ToSquare.Col >= ColCount)
            {
                return false;
            }
            else if (!move.FromSquare.ContainsPiece)
            {
                return false;
            }
            else if (move.ToSquare.Equals(move.FromSquare))
            {
                return false;
            }
            else if (move.FromSquare.Piece.Colour == Colour.Invalid)
            {
                return false;
            }
            return true;
        }

        public void SetSquare(ISquare square)
        {
            squares[square.Row][square.Col] = square;
        }

        private void InitialiseBoard()
        {
            InitialiseWhitePawnRow();
            InitialiseBlackPawnRow();
            InitialiseRooks();
            InitialiseKnights();
            InitialiseBishops();
            InitialiseQueens();
            InitialiseKings();
        }

        private void InitialiseWhitePawnRow()
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                WhitePawn whitePawn = new WhitePawn();
                Square square = new Square(WHITE_PAWN_INITAL_ROW, i);
                square.AddPiece(whitePawn);
                SetSquare(square);
            }
        }

        private void InitialiseBlackPawnRow()
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                BlackPawn blackPawn = new BlackPawn();
                Square square = new Square(BLACK_PAWN_INITAL_ROW, i);
                square.AddPiece(blackPawn);
                SetSquare(square);
            }
        }

        private void InitialiseRooks()
        {
            Rook whiteRookLeft = new Rook(Colour.White);
            Square whiteLeftRookSquare = new Square(WHITE_BACK_ROW, LEFT_ROOK_COL);
            whiteLeftRookSquare.AddPiece(whiteRookLeft);

            Rook whiteRookRight = new Rook(Colour.White);
            Square whiteRightRookSquare = new Square(WHITE_BACK_ROW, RIGHT_ROOK_COL);
            whiteRightRookSquare.AddPiece(whiteRookRight);

            Rook blackRookLeft = new Rook(Colour.Black);
            Square blackLeftRookSquare = new Square(BLACK_BACK_ROW, LEFT_ROOK_COL);
            blackLeftRookSquare.AddPiece(blackRookLeft);

            Rook blackRookRight = new Rook(Colour.Black);
            Square blackRightRookSquare = new Square(BLACK_BACK_ROW, RIGHT_ROOK_COL);
            blackRightRookSquare.AddPiece(blackRookRight);

            SetSquaresOnBoard(whiteLeftRookSquare, whiteRightRookSquare, blackLeftRookSquare, blackRightRookSquare);
        }

        private void InitialiseKnights()
        {
            Knight whiteKnightLeft = new Knight(Colour.White);
            Square whiteLeftKnightSquare = new Square(WHITE_BACK_ROW, LEFT_KNIGHT_COL);
            whiteLeftKnightSquare.AddPiece(whiteKnightLeft);

            Knight whiteKnightRight = new Knight(Colour.White);
            Square whiteKnightRightSquare = new Square(WHITE_BACK_ROW, RIGHT_KNIGHT_COL);
            whiteKnightRightSquare.AddPiece(whiteKnightRight);

            Knight blackKnightLeft = new Knight(Colour.Black);
            Square blackKnightLeftSquare = new Square(BLACK_BACK_ROW, LEFT_KNIGHT_COL);
            blackKnightLeftSquare.AddPiece(blackKnightLeft);

            Knight blackKnightRight = new Knight(Colour.Black);
            Square blackKnightRightSquare = new Square(BLACK_BACK_ROW, RIGHT_KNIGHT_COL);
            blackKnightRightSquare.AddPiece(blackKnightRight);

            SetSquaresOnBoard(whiteLeftKnightSquare, whiteKnightRightSquare, blackKnightLeftSquare, blackKnightRightSquare);
        }

        private void InitialiseBishops()
        {
            Bishop whiteBishopLeft = new Bishop(Colour.White);
            Square whiteBishopLeftSquare = new Square(WHITE_BACK_ROW, LEFT_BISHOP_COL);
            whiteBishopLeftSquare.AddPiece(whiteBishopLeft);

            Bishop whiteBishopRight = new Bishop(Colour.White);
            Square whiteBishopRightSquare = new Square(WHITE_BACK_ROW, RIGHT_BISHOP_COL);
            whiteBishopRightSquare.AddPiece(whiteBishopRight);

            Bishop blackBishopLeft = new Bishop(Colour.Black);
            Square blackBishopLeftSquare = new Square(BLACK_BACK_ROW, LEFT_BISHOP_COL);
            blackBishopLeftSquare.AddPiece(blackBishopLeft);

            Bishop blackBishopRight = new Bishop(Colour.Black);
            Square blackBishopRightSquare = new Square(BLACK_BACK_ROW, RIGHT_BISHOP_COL);
            blackBishopRightSquare.AddPiece(blackBishopRight);

            SetSquaresOnBoard(whiteBishopLeftSquare, whiteBishopRightSquare, blackBishopLeftSquare, blackBishopRightSquare);
        }

        private void InitialiseQueens()
        {
            Queen whiteQueen = new Queen(Colour.White);
            Square whiteQueenSquare = new Square(WHITE_BACK_ROW, QUEEN_COLUMN);
            whiteQueenSquare.AddPiece(whiteQueen);

            Queen blackQueen = new Queen(Colour.Black);
            Square blackQueenSquare = new Square(BLACK_BACK_ROW, QUEEN_COLUMN);
            blackQueenSquare.AddPiece(blackQueen);

            SetSquaresOnBoard(whiteQueenSquare, blackQueenSquare);
        }

        private void InitialiseKings()
        {
            King whiteKing = new King(Colour.White);
            Square whiteKingSquare = new Square(WHITE_BACK_ROW, KING_COLUMN);
            whiteKingSquare.AddPiece(whiteKing);

            King blackKing = new King(Colour.Black);
            Square blackKingSquare = new Square(BLACK_BACK_ROW, KING_COLUMN);
            blackKingSquare.AddPiece(blackKing);

            SetSquaresOnBoard(whiteKingSquare, blackKingSquare);
        }

        private void SetSquaresOnBoard(params ISquare[] squares)
        {
            foreach (var square in squares)
            {
                SetSquare(square);
            }
        }
    }
}
