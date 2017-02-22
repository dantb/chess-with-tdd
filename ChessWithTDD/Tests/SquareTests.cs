using NUnit.Framework;
using Rhino.Mocks;

namespace ChessWithTDD
{
    [TestFixture]
    public class SquareTests
    {
        [Test]
        public void SquareInitialisedHasNoPieceInIt()
        {
            Square square = new Square(0, 0);

            Assert.False(square.ContainsPiece);
        }

        [Test]
        public void SquareContainsPieceAfterCallingAddPiece()
        {
            IPiece thePiece = MockRepository.GenerateMock<IPiece>();
            Square square = new Square(0, 0);

            square.AddPiece(thePiece);

            Assert.True(square.ContainsPiece && square.Piece.Equals(thePiece));
        }

        [Test]
        public void SquaresAreEqualWhenTheyHaveSamePosition()
        {
            Square square1 = new Square(3, 3);
            Square square2 = new Square(3, 3);

            Assert.AreEqual(square1, square2);
        }
    }
}
