using Rhino.Mocks;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    internal static class CommonTestMethods
    {
        internal static ISquare MockSquareWithoutPiece(int row, int col)
        {
            ISquare theSquare = GenerateMock<ISquare>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(null);
            theSquare.Stub(s => s.ContainsPiece).Return(false);
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
