using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class BoardInitialiser : IBoardInitialiser
    {
        public void InitialiseBoardPieces(IBoard theBoard)
        {
            InitialiseWhitePawnRow(theBoard);
            InitialiseBlackPawnRow(theBoard);
            InitialiseRooks(theBoard);
            InitialiseKnights(theBoard);
            InitialiseBishops(theBoard);
            InitialiseQueens(theBoard);
            InitialiseKings(theBoard);
        }

        private void InitialiseWhitePawnRow(IBoard theBoard)
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                WhitePawn whitePawn = new WhitePawn();
                Square square = new Square(WHITE_PAWN_INITAL_ROW, i);
                square.AddPiece(whitePawn);
                theBoard.SetSquare(square);
            }
        }

        private void InitialiseBlackPawnRow(IBoard theBoard)
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                BlackPawn blackPawn = new BlackPawn();
                Square square = new Square(BLACK_PAWN_INITAL_ROW, i);
                square.AddPiece(blackPawn);
                theBoard.SetSquare(square);
            }
        }

        private void InitialiseRooks(IBoard theBoard)
        {
            InitialiseRook(Colour.White, WHITE_BACK_ROW, LEFT_ROOK_COL, theBoard);

            InitialiseRook(Colour.White, WHITE_BACK_ROW, RIGHT_ROOK_COL, theBoard);

            InitialiseRook(Colour.Black, BLACK_BACK_ROW, LEFT_ROOK_COL, theBoard);

            InitialiseRook(Colour.Black, BLACK_BACK_ROW, RIGHT_ROOK_COL, theBoard);
        }

        private void InitialiseRook(Colour theColour, int row, int col, IBoard theBoard)
        {
            Rook rook = new Rook(theColour);
            Square square = new Square(row, col);
            square.AddPiece(rook);
            theBoard.SetSquare(square);
        }

        private void InitialiseKnights(IBoard theBoard)
        {
            InitialiseKnight(Colour.White, WHITE_BACK_ROW, LEFT_KNIGHT_COL, theBoard);

            InitialiseKnight(Colour.White, WHITE_BACK_ROW, RIGHT_KNIGHT_COL, theBoard);

            InitialiseKnight(Colour.Black, BLACK_BACK_ROW, LEFT_KNIGHT_COL, theBoard);

            InitialiseKnight(Colour.Black, BLACK_BACK_ROW, RIGHT_KNIGHT_COL, theBoard);
        }

        private void InitialiseKnight(Colour theColour, int row, int col, IBoard theBoard)
        {
            Knight knight = new Knight(theColour);
            Square square = new Square(row, col);
            square.AddPiece(knight);
            theBoard.SetSquare(square);
        }

        private void InitialiseBishops(IBoard theBoard)
        {
            InitialiseBishop(Colour.White, WHITE_BACK_ROW, LEFT_BISHOP_COL, theBoard);

            InitialiseBishop(Colour.White, WHITE_BACK_ROW, RIGHT_BISHOP_COL, theBoard);

            InitialiseBishop(Colour.Black, BLACK_BACK_ROW, LEFT_BISHOP_COL, theBoard);

            InitialiseBishop(Colour.Black, BLACK_BACK_ROW, RIGHT_BISHOP_COL, theBoard);
        }

        private void InitialiseBishop(Colour theColour, int row, int col, IBoard theBoard)
        {
            Bishop bishop = new Bishop(theColour);
            Square square = new Square(row, col);
            square.AddPiece(bishop);
            theBoard.SetSquare(square);
        }

        private void InitialiseQueens(IBoard theBoard)
        {
            InitialiseQueen(Colour.White, WHITE_BACK_ROW, QUEEN_COLUMN, theBoard);

            InitialiseQueen(Colour.Black, BLACK_BACK_ROW, QUEEN_COLUMN, theBoard);
        }

        private void InitialiseQueen(Colour theColour, int row, int col, IBoard theBoard)
        {
            Queen queen = new Queen(theColour);
            Square square = new Square(row, col);
            square.AddPiece(queen);
            theBoard.SetSquare(square);
        }

        private void InitialiseKings(IBoard theBoard)
        {
            InitialiseKing(Colour.White, WHITE_BACK_ROW, KING_COLUMN, theBoard);

            InitialiseKing(Colour.Black, BLACK_BACK_ROW, KING_COLUMN, theBoard);
        }

        private void InitialiseKing(Colour theColour, int row, int col, IBoard theBoard)
        {
            King king = new King(theColour);
            Square square = new Square(row, col);
            square.AddPiece(king);
            theBoard.SetSquare(square);
        }
    }
}
