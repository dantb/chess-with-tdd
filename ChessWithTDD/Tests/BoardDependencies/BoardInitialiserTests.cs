using NUnit.Framework;
using Rhino.Mocks;
using static ChessWithTDD.BoardConstants;
using static ChessWithTDD.Tests.TestHelpers.CommonTestMethods;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class BoardInitialiserTests
    {
        [Test]
        public void BoardWhitePawnRowSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                mockBoard.AssertWasCalled(b =>
                    b.SetSquare(Arg<ISquare>.Matches(pawnSquare =>
                        pawnSquare.ContainsPiece &&
                        pawnSquare.Piece is WhitePawn &&
                        pawnSquare.Row == WHITE_PAWN_INITAL_ROW &&
                        pawnSquare.Col == i)));
            }
        }

        [Test]
        public void BoardBlackPawnRowSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                mockBoard.AssertWasCalled(b => 
                    b.SetSquare(Arg<ISquare>.Matches(pawnSquare =>
                        pawnSquare.ContainsPiece &&
                        pawnSquare.Piece is BlackPawn &&
                        pawnSquare.Row == BLACK_PAWN_INITAL_ROW &&
                        pawnSquare.Col == i)));
            }
        }

        [Test]
        public void BoardWhiteRooksSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftRookSquare =>
                    leftRookSquare.ContainsPiece &&
                    leftRookSquare.Piece is Rook &&
                    leftRookSquare.Piece.Colour == Colour.White &&
                    leftRookSquare.Row == WHITE_BACK_ROW &&
                    leftRookSquare.Col == LEFT_ROOK_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightRookSquare =>
                   rightRookSquare.ContainsPiece &&
                   rightRookSquare.Piece is Rook &&
                   rightRookSquare.Piece.Colour == Colour.White &&
                   rightRookSquare.Row == WHITE_BACK_ROW &&
                   rightRookSquare.Col == RIGHT_ROOK_COL)));
        }

        [Test]
        public void BoardBlackRooksSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftRookSquare =>
                    leftRookSquare.ContainsPiece &&
                    leftRookSquare.Piece is Rook &&
                    leftRookSquare.Piece.Colour == Colour.Black &&
                    leftRookSquare.Row == BLACK_BACK_ROW &&
                    leftRookSquare.Col == LEFT_ROOK_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightRookSquare =>
                   rightRookSquare.ContainsPiece &&
                   rightRookSquare.Piece is Rook &&
                   rightRookSquare.Piece.Colour == Colour.Black &&
                   rightRookSquare.Row == BLACK_BACK_ROW &&
                   rightRookSquare.Col == RIGHT_ROOK_COL)));
        }


        [Test]
        public void BoardWhiteKnightsSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftKnightSquare =>
                    leftKnightSquare.ContainsPiece &&
                    leftKnightSquare.Piece is Knight &&
                    leftKnightSquare.Piece.Colour == Colour.White &&
                    leftKnightSquare.Row == WHITE_BACK_ROW &&
                    leftKnightSquare.Col == LEFT_KNIGHT_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightKnightSquare =>
                    rightKnightSquare.ContainsPiece &&
                    rightKnightSquare.Piece is Knight &&
                    rightKnightSquare.Piece.Colour == Colour.White &&
                    rightKnightSquare.Row == WHITE_BACK_ROW &&
                    rightKnightSquare.Col == RIGHT_KNIGHT_COL)));
        }

        [Test]
        public void BoardBlackKnightsSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftKnightSquare =>
                    leftKnightSquare.ContainsPiece &&
                    leftKnightSquare.Piece is Knight &&
                    leftKnightSquare.Piece.Colour == Colour.Black &&
                    leftKnightSquare.Row == BLACK_BACK_ROW &&
                    leftKnightSquare.Col == LEFT_KNIGHT_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightKnightSquare =>
                    rightKnightSquare.ContainsPiece &&
                    rightKnightSquare.Piece is Knight &&
                    rightKnightSquare.Piece.Colour == Colour.Black &&
                    rightKnightSquare.Row == BLACK_BACK_ROW &&
                    rightKnightSquare.Col == RIGHT_KNIGHT_COL)));
        }

        [Test]
        public void BoardWhiteBishopsSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftBishopSquare =>
                    leftBishopSquare.ContainsPiece &&
                    leftBishopSquare.Piece is Bishop &&
                    leftBishopSquare.Piece.Colour == Colour.White &&
                    leftBishopSquare.Row == WHITE_BACK_ROW &&
                    leftBishopSquare.Col == LEFT_BISHOP_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightBishopSquare =>
                    rightBishopSquare.ContainsPiece &&
                    rightBishopSquare.Piece is Bishop &&
                    rightBishopSquare.Piece.Colour == Colour.White &&
                    rightBishopSquare.Row == WHITE_BACK_ROW &&
                    rightBishopSquare.Col == RIGHT_BISHOP_COL)));
        }

        [Test]
        public void BoardBlackBishopsSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
                b.SetSquare(Arg<ISquare>.Matches(leftBishopSquare =>
                    leftBishopSquare.ContainsPiece &&
                    leftBishopSquare.Piece is Bishop &&
                    leftBishopSquare.Piece.Colour == Colour.Black &&
                    leftBishopSquare.Row == BLACK_BACK_ROW &&
                    leftBishopSquare.Col == LEFT_BISHOP_COL)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(rightBishopSquare =>
                    rightBishopSquare.ContainsPiece &&
                    rightBishopSquare.Piece is Bishop &&
                    rightBishopSquare.Piece.Colour == Colour.Black &&
                    rightBishopSquare.Row == BLACK_BACK_ROW &&
                    rightBishopSquare.Col == RIGHT_BISHOP_COL)));
        }

        [Test]
        public void BoardQueensSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(whiteQueenSquare =>
                   whiteQueenSquare.ContainsPiece &&
                   whiteQueenSquare.Piece is Queen &&
                   whiteQueenSquare.Piece.Colour == Colour.White &&
                   whiteQueenSquare.Row == WHITE_BACK_ROW &&
                   whiteQueenSquare.Col == QUEEN_COLUMN)));            

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(whiteQueenSquare =>
                   whiteQueenSquare.ContainsPiece &&
                   whiteQueenSquare.Piece is Queen &&
                   whiteQueenSquare.Piece.Colour == Colour.Black &&
                   whiteQueenSquare.Row == BLACK_BACK_ROW &&
                   whiteQueenSquare.Col == QUEEN_COLUMN)));
        }

        [Test]
        public void BoardKingsSetupCorrectly()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(whiteKingSquare =>
                   whiteKingSquare.ContainsPiece &&
                   whiteKingSquare.Piece is King &&
                   whiteKingSquare.Piece.Colour == Colour.White &&
                   whiteKingSquare.Row == WHITE_BACK_ROW &&
                   whiteKingSquare.Col == KING_COLUMN)));

            mockBoard.AssertWasCalled(b =>
               b.SetSquare(Arg<ISquare>.Matches(blackKingSquare =>
                   blackKingSquare.ContainsPiece &&
                   blackKingSquare.Piece is King &&
                   blackKingSquare.Piece.Colour == Colour.Black &&
                   blackKingSquare.Row == BLACK_BACK_ROW &&
                   blackKingSquare.Col == KING_COLUMN)));
        }

        [Test]
        public void BoardSetSquareCalledCorrectNumberOfTimesDuringInitialisation()
        {
            //Arrange
            BoardInitialiser boardInitialiser = new BoardInitialiser(MockCastlingMoveValidator());
            IBoard mockBoard = GenerateMock<IBoard>();
            int expectedCalls = 32;
            int actualCalls = 0;
            mockBoard.Expect(b => b.SetSquare(Arg<ISquare>.Is.Anything)).WhenCalled(_ => actualCalls++);

            //Act
            boardInitialiser.InitialiseBoardPieces(mockBoard);

            //Assert
            Assert.AreEqual(actualCalls, expectedCalls);
        }
    }
}
