using NUnit.Framework;
using System.Collections.Generic;
using static ChessWithTDD.CommonTestMethods;

namespace ChessWithTDD
{
    [TestFixture]
    class BoardTests
    {
        private const int WhiteBackRow = 0;
        private const int BlackBackRow = 7;
        private const int LeftRookColumn = 0;
        private const int RightRookColumn = 7;
        private const int LeftKnightColumn = 1;
        private const int RightKnightColumn = 6;
        private const int LeftBishopColumn = 2;
        private const int RightBishopColumn = 5;
        private const int QueenColumn = 3;
        private const int KingColumn = 4;
        private const int WhitePawnInitialRow = 1;
        private const int BlackPawnInitialRow = 6;

        [Test]
        public void BoardIsInitialisedWithCorrectDimensions()
        {
            Board board = new Board();

            Assert.True(board.RowCount == 8 && board.ColCount == 8);
        }

        [Test]
        public void BoardWhitePawnRowSetupCorrectly()
        {
            Board board = new Board();

            HashSet<IPiece> setOfPieces = new HashSet<IPiece>();

            for (int i = 0; i < board.ColCount; i++)
            {
                ISquare pawnSquare = board.GetSquare(WhitePawnInitialRow, i);
                Assert.That(pawnSquare.ContainsPiece 
                    && pawnSquare.Piece is WhitePawn
                    && pawnSquare.Row == WhitePawnInitialRow
                    && pawnSquare.Col == i);

                setOfPieces.Add(pawnSquare.Piece);
            }

            //Ensure each pawn is a different instance
            Assert.AreEqual(setOfPieces.Count, board.ColCount);
        }

        [Test]
        public void BoardBlackPawnRowSetupCorrectly()
        {
            Board board = new Board();

            HashSet<IPiece> setOfPieces = new HashSet<IPiece>();

            for (int i = 0; i < board.ColCount; i++)
            {
                ISquare pawnSquare = board.GetSquare(BlackPawnInitialRow, i);
                Assert.That(pawnSquare.ContainsPiece
                    && pawnSquare.Piece is BlackPawn
                    && pawnSquare.Row == BlackPawnInitialRow
                    && pawnSquare.Col == i);

                setOfPieces.Add(pawnSquare.Piece);
            }

            //Ensure each pawn is a different instance
            Assert.AreEqual(setOfPieces.Count, board.ColCount);
        }

        [Test]
        public void BoardWhiteRooksSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftRookSquare = board.GetSquare(WhiteBackRow, LeftRookColumn);
            ISquare rightRookSquare = board.GetSquare(WhiteBackRow, RightRookColumn);

            Assert.That(leftRookSquare.ContainsPiece 
                && leftRookSquare.Piece is Rook
                && leftRookSquare.Piece.Colour == Colour.White
                && leftRookSquare.Row == WhiteBackRow
                && leftRookSquare.Col == LeftRookColumn);

            Assert.That(rightRookSquare.ContainsPiece
                && rightRookSquare.Piece is Rook
                && rightRookSquare.Piece.Colour == Colour.White
                && rightRookSquare.Row == WhiteBackRow
                && rightRookSquare.Col == RightRookColumn);

            Assert.AreNotEqual(leftRookSquare.Piece, rightRookSquare.Piece);
        }

        [Test]
        public void BoardBlackRooksSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftRookSquare = board.GetSquare(BlackBackRow, LeftRookColumn);
            ISquare rightRookSquare = board.GetSquare(BlackBackRow, RightRookColumn);

            Assert.That(leftRookSquare.ContainsPiece
                && leftRookSquare.Piece is Rook
                && leftRookSquare.Piece.Colour == Colour.Black
                && leftRookSquare.Row == BlackBackRow
                && leftRookSquare.Col == LeftRookColumn);

            Assert.That(rightRookSquare.ContainsPiece
                && rightRookSquare.Piece is Rook
                && rightRookSquare.Piece.Colour == Colour.Black
                && rightRookSquare.Row == BlackBackRow
                && rightRookSquare.Col == RightRookColumn);

            Assert.AreNotEqual(leftRookSquare.Piece, rightRookSquare.Piece);
        }

        [Test]
        public void BoardWhiteKnightsSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftKnightSquare = board.GetSquare(WhiteBackRow, LeftKnightColumn);
            ISquare rightKnightSquare = board.GetSquare(WhiteBackRow, RightKnightColumn);

            Assert.That(leftKnightSquare.ContainsPiece
                && leftKnightSquare.Piece is Knight
                && leftKnightSquare.Piece.Colour == Colour.White
                && leftKnightSquare.Row == WhiteBackRow
                && leftKnightSquare.Col == LeftKnightColumn);

            Assert.That(rightKnightSquare.ContainsPiece
                && rightKnightSquare.Piece is Knight
                && rightKnightSquare.Piece.Colour == Colour.White
                && rightKnightSquare.Row == WhiteBackRow
                && rightKnightSquare.Col == RightKnightColumn);

            Assert.AreNotEqual(leftKnightSquare.Piece, rightKnightSquare.Piece);
        }

        [Test]
        public void BoardBlackKnightsSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftKnightSquare = board.GetSquare(BlackBackRow, LeftKnightColumn);
            ISquare rightKnightSquare = board.GetSquare(BlackBackRow, RightKnightColumn);

            Assert.That(leftKnightSquare.ContainsPiece
                && leftKnightSquare.Piece is Knight
                && leftKnightSquare.Piece.Colour == Colour.Black
                && leftKnightSquare.Row == BlackBackRow
                && leftKnightSquare.Col == LeftKnightColumn);

            Assert.That(rightKnightSquare.ContainsPiece
                && rightKnightSquare.Piece is Knight
                && rightKnightSquare.Piece.Colour == Colour.Black
                && rightKnightSquare.Row == BlackBackRow
                && rightKnightSquare.Col == RightKnightColumn);

            Assert.AreNotEqual(leftKnightSquare.Piece, rightKnightSquare.Piece);
        }

        [Test]
        public void BoardWhiteBishopsSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftBishopSquare = board.GetSquare(WhiteBackRow, LeftBishopColumn);
            ISquare rightBishopSquare = board.GetSquare(WhiteBackRow, RightBishopColumn);

            Assert.That(leftBishopSquare.ContainsPiece
                && leftBishopSquare.Piece is Bishop
                && leftBishopSquare.Piece.Colour == Colour.White
                && leftBishopSquare.Row == WhiteBackRow
                && leftBishopSquare.Col == LeftBishopColumn);

            Assert.That(rightBishopSquare.ContainsPiece
                && rightBishopSquare.Piece is Bishop
                && rightBishopSquare.Piece.Colour == Colour.White
                && rightBishopSquare.Row == WhiteBackRow
                && rightBishopSquare.Col == RightBishopColumn);

            Assert.AreNotEqual(leftBishopSquare.Piece, rightBishopSquare.Piece);
        }

        [Test]
        public void BoardBlackBishopsSetupCorrectly()
        {
            Board board = new Board();

            ISquare leftBishopSquare = board.GetSquare(BlackBackRow, LeftBishopColumn);
            ISquare rightBishopSquare = board.GetSquare(BlackBackRow, RightBishopColumn);

            Assert.That(leftBishopSquare.ContainsPiece
                && leftBishopSquare.Piece is Bishop
                && leftBishopSquare.Piece.Colour == Colour.Black
                && leftBishopSquare.Row == BlackBackRow
                && leftBishopSquare.Col == LeftBishopColumn);

            Assert.That(rightBishopSquare.ContainsPiece
                && rightBishopSquare.Piece is Bishop
                && rightBishopSquare.Piece.Colour == Colour.Black
                && rightBishopSquare.Row == BlackBackRow
                && rightBishopSquare.Col == RightBishopColumn);

            Assert.AreNotEqual(leftBishopSquare.Piece, rightBishopSquare.Piece);
        }

        [Test]
        public void BoardQueensSetupCorrectly()
        {
            Board board = new Board();

            ISquare whiteQueenSquare = board.GetSquare(WhiteBackRow, QueenColumn);
            ISquare blackQueenSquare = board.GetSquare(BlackBackRow, QueenColumn);

            Assert.That(whiteQueenSquare.ContainsPiece
                && whiteQueenSquare.Piece is Queen
                && whiteQueenSquare.Piece.Colour == Colour.White
                && whiteQueenSquare.Row == WhiteBackRow
                && whiteQueenSquare.Col == QueenColumn);

            Assert.That(blackQueenSquare.ContainsPiece
                && blackQueenSquare.Piece is Queen
                && blackQueenSquare.Piece.Colour == Colour.Black
                && blackQueenSquare.Row == BlackBackRow
                && blackQueenSquare.Col == QueenColumn);

            Assert.AreNotEqual(whiteQueenSquare.Piece, blackQueenSquare.Piece);
        }

        [Test]
        public void BoardKingsSetupCorrectly()
        {
            Board board = new Board();

            ISquare whiteKingSquare = board.GetSquare(WhiteBackRow, KingColumn);
            ISquare blackKingSquare = board.GetSquare(BlackBackRow, KingColumn);

            Assert.That(whiteKingSquare.ContainsPiece
                && whiteKingSquare.Piece is King
                && whiteKingSquare.Piece.Colour == Colour.White
                && whiteKingSquare.Row == WhiteBackRow
                && whiteKingSquare.Col == KingColumn);

            Assert.That(blackKingSquare.ContainsPiece
                && blackKingSquare.Piece is King
                && blackKingSquare.Piece.Colour == Colour.Black
                && blackKingSquare.Row == BlackBackRow
                && blackKingSquare.Col == KingColumn);

            Assert.AreNotEqual(whiteKingSquare.Piece, blackKingSquare.Piece);
        }
     
        [Test]
        public void SquareAtPositionFiveSixOnBoardHasRowFiveAndColSix()
        {
            Board board = new Board();

            Assert.True(board.GetSquare(5, 6).Row == 5 && board.GetSquare(5, 6).Col == 6);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquarePieceDoesNotHaveAValidColourIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            IPiece thePiece = MockPieceWithColour(Colour.Invalid);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 9, 5)]
        [TestCase(5, 3, 6, 8)]
        [TestCase(7, 8, 2, 2)]
        [TestCase(9, 1, 2, 2)]
        [Test]
        public void MoveWhereFromSquareOrToSquareIsOffTheBoardIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquareDoesNotContainPieceIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            ISquare fromSquare = MockSquareWithoutPiece(rowFrom, colFrom);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(5, 3, 5, 3)]
        [Test]
        public void MoveWhereFromSquareIsSameAsToSquareIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            ISquare square = MockSquareWithPiece(rowFrom, colFrom);

            bool isValidMove = board.IsValidMove(square, square);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWherePieceInFromSquareCanMoveIsValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            piece = StubPieceCanMoveForSpecificSquares(piece, true, fromSquare, toSquare);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.True(isValidMove);
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(5, 3, 5, 3)]
        [Test]
        public void MoveWherePieceInFromSquareCannotMoveIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IBoard board = new Board();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            piece = StubPieceCanMoveForSpecificSquares(piece, false, fromSquare, toSquare);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveToBoardChangesBoardStateCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, thePiece);
            IBoard board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.That(!board.GetSquare(rowFrom, colFrom).ContainsPiece && board.GetSquare(rowFrom, colFrom).Piece == null);
            Assert.That(board.GetSquare(rowTo, colTo).ContainsPiece && board.GetSquare(rowTo, colTo).Piece == thePiece);
            Assert.IsNotNull(board.GetSquare(rowTo, colTo).Piece);
        }
    }
}
