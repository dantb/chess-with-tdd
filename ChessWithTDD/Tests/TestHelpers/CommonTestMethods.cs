using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;
using static ChessWithTDD.BoardConstants;
using System;
using System.Collections.Generic;
using ChessWithTDD.Tests.TestHelpers;

namespace ChessWithTDD.Tests
{

    internal static class CommonTestMethods
    {
        internal static void StubSquareWithPiece(ISquare settingSquare, IPiece thePiece)
        {
            settingSquare.Stub(s => s.Piece).Return(thePiece).OverridePrevious();
        }

        /// <summary>
        /// Get a mock service locator with all services mocked to one level deep.
        /// If this is used remember to call OverridePrevious when stubbing the return from this.
        /// </summary>
        internal static IStrictServiceLocator MockServiceLocator()
        {
            IStrictServiceLocator serviceLocator = GenerateMock<IStrictServiceLocator>();
            serviceLocator.Stub(s => s.GetServiceBoardInitialiser()).Return(MockBoardInitialiser());
            serviceLocator.Stub(s => s.GetServiceBoardCache()).Return(MockBoardCache());
            serviceLocator.Stub(s => s.GetServiceCheckManager()).Return(MockCheckManager());
            serviceLocator.Stub(s => s.GetServicePawnManager()).Return(MockPawnManager());
            serviceLocator.Stub(s => s.GetServiceMoveValidator()).Return(MockMoveValidator());
            return serviceLocator;
        }

        internal static IMoveValidator MockMoveValidator()
        {
            return GenerateMock<IMoveValidator>();
        }

        internal static IMoveExecutor MockMoveExecutor()
        {
            return GenerateMock<IMoveExecutor>();
        }

        internal static IPawnManager MockPawnManager()
        {
            return GenerateMock<IPawnManager>();
        }

        internal static ICheckManager MockCheckManager()
        {
            return GenerateMock<ICheckManager>();
        }

        internal static IBoardInitialiser MockBoardInitialiser()
        {
            return GenerateMock<IBoardInitialiser>();
        }

        internal static IBoardCache MockBoardCache()
        {
            return GenerateMock<IBoardCache>();
        }

        internal static IBoard MockBoard()
        {
            return GenerateMock<IBoard>();
        }

        internal static IBoard MockBoardWithGetSquareAndPendingUpdates()
        {
            IBoard board = GenerateMock<IBoard>();
            board.Stub(b => b.GetSquare(Arg<int>.Is.Anything, Arg<int>.Is.Anything))
                .Return(MockSquare());
            board.Stub(b => b.PendingUpdates).Return(new List<ISquare>());
            return board;
        }

        internal static IBoard MockBoardWithGetSquaresMocked()
        {
            IBoard board = MockBoard();
            for (int row = 0; row < BOARD_DIMENSION; row++)
            {
                for (int col = 0; col < BOARD_DIMENSION; col++)
                {
                    board.Stub(b => b.GetSquare(row, col)).Return(MockSquare());
                }
            }
            return board;
        }

        internal static IBoard MockBoardWithPieceInSquare(int row, int col, IPiece thePiece)
        {
            IBoard board = MockBoardWithGetSquaresMocked();
            ISquare square = MockSquareWithPiece(row, col, thePiece);
            board.Stub(b => b.GetSquare(row, col)).Return(square).Repeat.Any();
            return board;
        }

        internal static ISquare MockSquareWithoutPiece(int row, int col)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(null);
            theSquare.Stub(s => s.ContainsPiece).Return(false);
            return theSquare;
        }

        internal static ISquare MockSquare()
        {
            return GenerateMock<ISquare>();
        }

        internal static ISquare MockSquare(int row, int col)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            return theSquare;
        }

        internal static ISquare MockSquareWithHasEnPassantMark(int row, int col, bool hasEnPassantMark)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(null);
            theSquare.Stub(s => s.ContainsPiece).Return(false);
            theSquare.Stub(s => s.HasEnPassantMark).Return(hasEnPassantMark);
            return theSquare;
        }

        internal static ISquare MockSquareWithPiece(int row, int col, IPiece aPiece = null)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            IPiece thePiece = aPiece ?? GenerateMock<IPiece>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(thePiece);
            theSquare.Stub(s => s.ContainsPiece).Return(true);
            return theSquare;
        }

        internal static ISquare MockSquareWithPiece(IPiece aPiece = null)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            IPiece thePiece = aPiece ?? GenerateMock<IPiece>();
            theSquare.Stub(s => s.Piece).Return(thePiece);
            theSquare.Stub(s => s.ContainsPiece).Return(true);
            return theSquare;
        }

        internal static IMove MockMove()
        {
            return GenerateMock<IMove>();
        }

        internal static IMove MockMoveWithFromSquareAndToSquare(ISquare fromSquare, ISquare toSquare)
        {
            IMove move = MockMove();
            move.Stub(m => m.FromRow).Return(fromSquare.Row);
            move.Stub(m => m.FromCol).Return(fromSquare.Col);
            move.Stub(m => m.ToRow).Return(toSquare.Row);
            move.Stub(m => m.ToCol).Return(toSquare.Col);
            return move;
        }

        internal static IPiece MockPieceWithColour(Colour theColour)
        {
            IPiece piece = MockPiece();
            piece.Stub(b => b.Colour).Return(theColour);
            return piece;
        }

        internal static IKing MockKingWithColour(Colour theColour)
        {
            IKing king = MockKing();
            king.Stub(b => b.Colour).Return(theColour);
            return king;
        }

        internal static IKing MockKing()
        {
            return GenerateMock<IKing>();
        }

        internal static IKnight MockKnight()
        {
            return GenerateMock<IKnight>();
        }

        internal static IPiece MockPiece()
        {
            return GenerateMock<IPiece>();
        }

        internal static IPawn MockPawn()
        {
            return GenerateMock<IPawn>();
        }

        internal static IPawn MockPawnWithHasMoved(bool hasMoved)
        {
            IPawn pawn = GenerateMock<IPawn>();
            pawn.Stub(p => p.HasMoved).Return(hasMoved);
            return pawn;
        }

        internal static IPiece StubPieceCanMoveForSpecificSquares(IPiece piece, bool canMove, ISquare fromSquare, ISquare toSquare)
        {
            piece.Stub(p => p.CanMove(fromSquare, toSquare)).Return(canMove);
            return piece;
        }
    }
}
