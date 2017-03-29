using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    internal static class BoardInitialiser
    {
        internal static void InitialiseBoardPieces(Board theBoard)
        {
            InitialiseWhitePawnRow(theBoard);
            InitialiseBlackPawnRow(theBoard);
            InitialiseRooks(theBoard);
            InitialiseKnights(theBoard);
            InitialiseBishops(theBoard);
            InitialiseQueens(theBoard);
            InitialiseKings(theBoard);
        }

        private static void InitialiseWhitePawnRow(Board theBoard)
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                WhitePawn whitePawn = new WhitePawn();
                Square square = new Square(WHITE_PAWN_INITAL_ROW, i);
                square.AddPiece(whitePawn);
                theBoard.SetSquare(square);
            }
        }

        private static void InitialiseBlackPawnRow(Board theBoard)
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                BlackPawn blackPawn = new BlackPawn();
                Square square = new Square(BLACK_PAWN_INITAL_ROW, i);
                square.AddPiece(blackPawn);
                theBoard.SetSquare(square);
            }
        }

        private static void InitialiseRooks(Board theBoard)
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

            theBoard.SetSquaresOnBoard(whiteLeftRookSquare, whiteRightRookSquare, blackLeftRookSquare, blackRightRookSquare);
        }

        private static void InitialiseKnights(Board theBoard)
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

            theBoard.SetSquaresOnBoard(whiteLeftKnightSquare, whiteKnightRightSquare, blackKnightLeftSquare, blackKnightRightSquare);
        }

        private static void InitialiseBishops(Board theBoard)
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

            theBoard.SetSquaresOnBoard(whiteBishopLeftSquare, whiteBishopRightSquare, blackBishopLeftSquare, blackBishopRightSquare);
        }

        private static void InitialiseQueens(Board theBoard)
        {
            Queen whiteQueen = new Queen(Colour.White);
            Square whiteQueenSquare = new Square(WHITE_BACK_ROW, QUEEN_COLUMN);
            whiteQueenSquare.AddPiece(whiteQueen);

            Queen blackQueen = new Queen(Colour.Black);
            Square blackQueenSquare = new Square(BLACK_BACK_ROW, QUEEN_COLUMN);
            blackQueenSquare.AddPiece(blackQueen);

            theBoard.SetSquaresOnBoard(whiteQueenSquare, blackQueenSquare);
        }

        private static void InitialiseKings(Board theBoard)
        {
            King whiteKing = new King(Colour.White);
            Square whiteKingSquare = new Square(WHITE_BACK_ROW, KING_COLUMN);
            whiteKingSquare.AddPiece(whiteKing);

            King blackKing = new King(Colour.Black);
            Square blackKingSquare = new Square(BLACK_BACK_ROW, KING_COLUMN);
            blackKingSquare.AddPiece(blackKing);

            theBoard.SetSquaresOnBoard(whiteKingSquare, blackKingSquare);
        }
    }

    internal static class BoardConstants
    {
        internal const int BOARD_LOWER_DIMENSION = 0;
        internal const int BOARD_DIMENSION = 8;
        internal const int WHITE_BACK_ROW = 0;
        internal const int BLACK_BACK_ROW = 7;
        internal const int LEFT_ROOK_COL = 0;
        internal const int RIGHT_ROOK_COL = 7;
        internal const int LEFT_KNIGHT_COL = 1;
        internal const int RIGHT_KNIGHT_COL = 6;
        internal const int LEFT_BISHOP_COL = 2;
        internal const int RIGHT_BISHOP_COL = 5;
        internal const int QUEEN_COLUMN = 3;
        internal const int KING_COLUMN = 4;
        internal const int WHITE_PAWN_INITAL_ROW = 1;
        internal const int BLACK_PAWN_INITAL_ROW = 6;
    }
}
