using Rhino.Mocks;

namespace ChessWithTDD
{
    internal static class CommonTestMethods
    {
        internal static IBoard MockBoardWithCorrectDimensions()
        {
            IBoard theBoard = MockRepository.GenerateMock<IBoard>();
            theBoard.Stub(b => b.RowCount).Return(8);
            theBoard.Stub(b => b.ColCount).Return(8);
            return theBoard;
        }

        internal static ISquare MockSquareWithoutPiece(int row, int col)
        {
            ISquare theSquare = MockRepository.GenerateMock<ISquare>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(null);
            theSquare.Stub(s => s.ContainsPiece).Return(false);
            return theSquare;
        }

        internal static ISquare MockSquareWithPiece(int row, int col, IPiece aPiece = null)
        {
            ISquare theSquare = MockRepository.GenerateMock<ISquare>();
            IPiece thePiece = aPiece ?? MockRepository.GenerateMock<IPiece>();
            theSquare.Stub(s => s.Row).Return(row);
            theSquare.Stub(s => s.Col).Return(col);
            theSquare.Stub(s => s.Piece).Return(thePiece);
            theSquare.Stub(s => s.ContainsPiece).Return(true);
            return theSquare;
        }

        internal static IMove MockMove()
        {
            return MockRepository.GenerateMock<IMove>();
        }

        internal static IMove MockMoveWithFromSquareAndToSquare(ISquare fromSquare, ISquare toSquare)
        {
            IMove move = MockMove();
            move.Stub(m => m.FromSquare).Return(fromSquare);
            move.Stub(m => m.ToSquare).Return(toSquare);
            return move;
        }

        internal static IPiece MockPieceWithColour(Colour theColour)
        {
            IPiece piece = MockPiece();
            piece.Stub(b => b.Colour).Return(theColour);
            return piece;
        }

        internal static IPiece MockPiece()
        {
            return MockRepository.GenerateMock<IPiece>();
        }

        internal static IPiece MockPieceWithCanMove(bool canMove, IMove aMove = null)
        {
            IPiece piece = MockPiece();
            IMove move = aMove ?? MockMove();
            piece.Stub(p => p.CanMove(move)).Return(canMove);
            return piece;
        }

        internal static IPiece StubPieceCanMoveForSpecificMove(IPiece piece, bool canMove, IMove aMove)
        {
            piece.Stub(p => p.CanMove(aMove)).Return(canMove);
            return piece;
        }
    }
}
