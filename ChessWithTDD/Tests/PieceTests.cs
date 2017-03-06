using NUnit.Framework;
using static ChessWithTDD.CommonTestMethods;

namespace ChessWithTDD
{
    [TestFixture]
    public class PieceTests
    {
        [Test]
        public void NewPieceAlwaysHasInvalidColour()
        {
            Piece thePiece = new Piece();

            Assert.AreEqual(thePiece.Colour, Colour.Invalid);
        }

        [TestCase(1,2,3,4)]
        [Test]
        public void PieceCannotMoveIfToSquareContainsAPieceOfSameColour(int rowFrom, int colFrom, int rowTo, int colTo)
        {
            Piece piece = new Piece();
            Colour pieceColour = piece.Colour;
            ISquare fromSquare = MockSquareWithPiece(rowFrom, colFrom, piece);
            //Want the mock piece's colour to be the same as our real piece under test
            IPiece pieceColourInvalid = MockPieceWithColour(Colour.Invalid);
            ISquare toSquare = MockSquareWithPiece(rowTo, colTo, pieceColourInvalid);
            IMove move = MockMoveWithFromSquareAndToSquare(fromSquare, toSquare);

            bool canMove = piece.CanMove(fromSquare, toSquare);

            Assert.False(canMove);
        }
    }
}
