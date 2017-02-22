using NUnit.Framework;

namespace ChessWithTDD
{
    [TestFixture]
    public class MoveTests
    {
        [Test]
        public void MoveIntialisesWithFromSquareAndToSquareCorrectly()
        {
            ISquare toSquare = CommonTestMethods.MockSquareWithoutPiece(0,0);
            ISquare fromSquare = CommonTestMethods.MockSquareWithoutPiece(1, 1);
            Move move = new Move(fromSquare, toSquare);

            Assert.That(move.ToSquare.Equals(toSquare) && move.FromSquare.Equals(fromSquare));
        }

        [TestCase(2, 4, 6, 7)]
        [TestCase(3, 3, 1, 1)]
        [TestCase(1, 3, 1, 5)]
        [Test]
        public void ApplyMoveToBoardChangesBoardStateCorrectly(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            IPiece thePiece = CommonTestMethods.MockPiece();
            ISquare fromSquare = new Square(rowFrom, colFrom);
            fromSquare.Piece = thePiece;
            fromSquare.ContainsPiece = true;
            ISquare toSquare = new Square(rowTo, colTo);
            IBoard board = new Board();
            board.SetSquare(fromSquare);
            board.SetSquare(toSquare);
            Move move = new Move(fromSquare, toSquare);

            move.ApplyToBoard(board);

            Assert.That(!board.GetSquare(rowFrom, colFrom).ContainsPiece && board.GetSquare(rowFrom, colFrom).Piece == null);
            Assert.That(board.GetSquare(rowTo, colTo).ContainsPiece && board.GetSquare(rowTo, colTo).Piece == thePiece);
        }        
    }
}
