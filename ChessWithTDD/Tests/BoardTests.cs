﻿using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
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


        #region Board initialisation

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
                ISquare pawnSquare = board.GetSquareInternal(WhitePawnInitialRow, i);
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
                ISquare pawnSquare = board.GetSquareInternal(BlackPawnInitialRow, i);
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

            ISquare leftRookSquare = board.GetSquareInternal(WhiteBackRow, LeftRookColumn);
            ISquare rightRookSquare = board.GetSquareInternal(WhiteBackRow, RightRookColumn);

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

            ISquare leftRookSquare = board.GetSquareInternal(BlackBackRow, LeftRookColumn);
            ISquare rightRookSquare = board.GetSquareInternal(BlackBackRow, RightRookColumn);

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

            ISquare leftKnightSquare = board.GetSquareInternal(WhiteBackRow, LeftKnightColumn);
            ISquare rightKnightSquare = board.GetSquareInternal(WhiteBackRow, RightKnightColumn);

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

            ISquare leftKnightSquare = board.GetSquareInternal(BlackBackRow, LeftKnightColumn);
            ISquare rightKnightSquare = board.GetSquareInternal(BlackBackRow, RightKnightColumn);

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

            ISquare leftBishopSquare = board.GetSquareInternal(WhiteBackRow, LeftBishopColumn);
            ISquare rightBishopSquare = board.GetSquareInternal(WhiteBackRow, RightBishopColumn);

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

            ISquare leftBishopSquare = board.GetSquareInternal(BlackBackRow, LeftBishopColumn);
            ISquare rightBishopSquare = board.GetSquareInternal(BlackBackRow, RightBishopColumn);

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

            ISquare whiteQueenSquare = board.GetSquareInternal(WhiteBackRow, QueenColumn);
            ISquare blackQueenSquare = board.GetSquareInternal(BlackBackRow, QueenColumn);

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

            ISquare whiteKingSquare = board.GetSquareInternal(WhiteBackRow, KingColumn);
            ISquare blackKingSquare = board.GetSquareInternal(BlackBackRow, KingColumn);

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

            Assert.True(board.GetSquareInternal(5, 6).Row == 5 && board.GetSquareInternal(5, 6).Col == 6);
        }

        #endregion Board initialisation


        #region Move validation

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquarePieceDoesNotHaveAValidColourIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Board board = new Board();
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
        [TestCase(1, 1, -1, 5)]
        [TestCase(5, 3, 6, -1)]
        [TestCase(7, -1, 2, 2)]
        [TestCase(-1, 1, 2, 2)]
        [Test]
        public void MoveWhereFromSquareOrToSquareIsOffTheBoardIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Board board = new Board();
            IPiece pieceWithColour = MockPieceWithColour(Colour.White);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, pieceWithColour);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            pieceWithColour = StubPieceCanMoveForSpecificSquares(pieceWithColour, true, fromSquare, toSquare);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWhereFromSquareDoesNotContainPieceIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Board board = new Board();
            ISquare fromSquare = MockSquareWithoutPiece(rowFrom, colFrom);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 2, 1, 2)]
        [TestCase(5, 3, 5, 3)]
        [Test]
        public void MoveWhereFromSquareIsSameAsToSquareButWithDifferentPiecesIsNotValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Board board = new Board();
            IPiece piece1 = MockPieceWithColour(Colour.White);            
            ISquare square1 = MockSquareWithPiece(rowFrom, colFrom, piece1);
            IPiece piece2 = MockPieceWithColour(Colour.Black);
            ISquare square2 = MockSquareWithPiece(rowFrom, colFrom, piece2);
            //Make sure piece can move
            StubPieceCanMoveForSpecificSquares(piece1, true, square1, square2);


            bool isValidMove = board.IsValidMove(square1, square2);

            Assert.False(isValidMove);
        }

        [TestCase(1, 1, 2, 2)]
        [TestCase(5, 3, 7, 7)]
        [Test]
        public void MoveWherePieceInFromSquareCanMoveIsValid(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Board board = new Board();
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
            Board board = new Board();
            IPiece piece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            piece = StubPieceCanMoveForSpecificSquares(piece, false, fromSquare, toSquare);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        [TestCase(1, 2, 1, 2, Colour.White)]
        [TestCase(5, 3, 5, 3, Colour.Black)]
        [TestCase(5, 3, 5, 3, Colour.Invalid)]
        [Test]
        public void MoveWherePieceInToSquareIsOfSameColourAsMovingPieceIsInvalid(int rowFrom, int colFrom, int rowTo, int colTo, Colour theColour)
        {
            Board board = new Board();
            IPiece piece = MockPieceWithColour(theColour);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            IPiece toSquarePiece = MockPieceWithColour(theColour);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, toSquarePiece);
            //the piece can move if we ask it
            piece = StubPieceCanMoveForSpecificSquares(piece, true, fromSquare, toSquare);

            bool isValidMove = board.IsValidMove(fromSquare, toSquare);

            Assert.False(isValidMove);
        }

        #endregion Move validation


        #region Applying moves

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveToBoardChangesBoardStateCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece thePiece = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePiece);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, thePiece);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.That(!board.GetSquareInternal(rowFrom, colFrom).ContainsPiece && board.GetSquareInternal(rowFrom, colFrom).Piece == null);
            Assert.That(board.GetSquareInternal(rowTo, colTo).ContainsPiece && board.GetSquareInternal(rowTo, colTo).Piece == thePiece);
            Assert.IsNotNull(board.GetSquareInternal(rowTo, colTo).Piece);
        }

        [TestCase(2, 4, 4, 4)]
        [TestCase(3, 3, 5, 3)]
        [Test]
        public void ApplyMoveOnPawnWhereHasMovedIsFalseSetsHasMovedToTrue(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawnWithHasMoved(false);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            thePawn.AssertWasCalled(p => p.HasMoved = true);
        }

        [TestCase(2, 4, 4, 4)]
        [TestCase(3, 3, 5, 3)]
        [Test]
        public void ApplyMoveOnPawnWhereHasMovedIsTrueDoesNothing(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawnWithHasMoved(true);
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            thePawn.AssertWasNotCalled(p => p.HasMoved = true);
        }

        [TestCase(2, 4, 4, 4)]
        [TestCase(1, 3, 3, 3)]
        [Test]
        public void ApplyMoveOnPawnMovingTwoSquaresUpMarksPassedSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.True(board.GetSquareInternal(rowFrom + 1, colFrom).HasEnPassantMark);
        }

        [TestCase(6, 4, 4, 4)]
        [TestCase(5, 3, 3, 3)]
        [Test]
        public void ApplyMoveOnPawnMovingTwoSquaresDownMarksPassedSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.True(board.GetSquareInternal(rowFrom - 1, colFrom).HasEnPassantMark);
        }

        /// <summary>
        /// En Passant marking should only happen for IPawn pieces, not general pieces
        /// </summary>
        [TestCase(2, 4, 4, 4)]
        [TestCase(1, 3, 3, 3)]
        [Test]
        public void ApplyMoveOnGeneralPieceMovingTwoSquaresUpDoesNotMarkPassedSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPiece thePawn = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom + 1, colFrom).HasEnPassantMark);
        }

        /// <summary>
        /// En Passant marking should only happen for IPawn pieces, not general pieces
        /// </summary>
        [TestCase(6, 4, 4, 4)]
        [TestCase(5, 3, 3, 3)]
        [Test]
        public void ApplyMoveOnGeneralPieceMovingTwoSquaresDownDoesNotMarkPassedSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPiece thePawn = MockPiece();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom - 1, colFrom).HasEnPassantMark);
        }

        [TestCase(2, 4, 3, 4)]
        [TestCase(1, 3, 2, 3)]
        [Test]
        public void ApplyMoveOnPawnMovingOneSquareUpDoesNotMarkToSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom + 1, colFrom).HasEnPassantMark);
        }

        [TestCase(6, 4, 5, 4)]
        [TestCase(5, 3, 4, 3)]
        [Test]
        public void ApplyMoveOnPawnMovingOneSquareDownDoesNotMarkToSquareWithEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom - 1, colFrom).HasEnPassantMark);
        }

        /// <summary>
        /// Integration test to ensure that the en passant mark is removed after two more turns.
        /// Going up the board.
        /// </summary>
        [TestCase(2, 4, 4, 4)]
        [TestCase(1, 3, 3, 3)]
        [Test]
        public void AfterTheSecondApplySinceAnUpEnPassantMarkTheMarkIsRemovedForSpecificSquare(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();
            ISquare square1 = MockSquareWithoutPiece(0, 0);
            ISquare square2 = MockSquareWithoutPiece(1, 1);
            ISquare square3 = MockSquareWithoutPiece(0, 0);
            ISquare square4 = MockSquareWithoutPiece(1, 1);

            //mark
            board.Apply(fromSquare, toSquare);
            //random move
            board.Apply(square1, square2);
            //Unmark of our specific square should happen here
            board.Apply(square3, square4);

            Assert.False(board.GetSquareInternal(rowFrom + 1, colFrom).HasEnPassantMark);
        }

        /// <summary>
        /// Integration test to ensure that the en passant mark is removed after two more turns.
        /// Going down the board.
        /// </summary>
        [TestCase(6, 4, 4, 4)]
        [TestCase(5, 3, 3, 3)]
        [Test]
        public void AfterTheSecondApplySinceADownEnPassantMarkTheMarkIsRemovedForSpecificSquare(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();
            ISquare square1 = MockSquareWithoutPiece(0, 0);
            ISquare square2 = MockSquareWithoutPiece(1, 1);
            ISquare square3 = MockSquareWithoutPiece(0, 0);
            ISquare square4 = MockSquareWithoutPiece(1, 1);

            //mark
            board.Apply(fromSquare, toSquare);
            //random move
            board.Apply(square1, square2);
            //Unmark of our specific square should happen here
            board.Apply(square3, square4);

            Assert.False(board.GetSquareInternal(rowFrom - 1, colFrom).HasEnPassantMark);
        }

        [TestCase(2, 4, 3, 5)]
        [TestCase(1, 3, 2, 4)]
        [Test]
        public void ApplyMoveOnPawnMovingDiagonallyUpWhereToSquareContainsNoPieceRemovesEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom + 1, colFrom).HasEnPassantMark);
        }

        [TestCase(6, 4, 5, 3)]
        [TestCase(5, 3, 4, 2)]
        [Test]
        public void ApplyMoveOnPawnMovingDiagonallyDownWhereToSquareContainsNoPieceRemovesEnPassantMark(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            //In a game this only happens when moving two squares forward, but the board doesn't care about that
            IPawn thePawn = MockPawn();
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, thePawn);
            ISquare toSquare = MockSquareWithoutPiece(rowTo, colTo);
            Board board = new Board();

            board.Apply(fromSquare, toSquare);

            Assert.False(board.GetSquareInternal(rowFrom - 1, colFrom).HasEnPassantMark);
        }

        #endregion Applying moves


    }
}
