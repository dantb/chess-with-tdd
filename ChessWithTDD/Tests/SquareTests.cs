using NUnit.Framework;
using static ChessWithTDD.Tests.CommonTestMethods;

namespace ChessWithTDD.Tests
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
            IPiece thePiece = MockPiece();
            Square square = new Square(0, 0);

            square.AddPiece(thePiece);

            Assert.True(square.ContainsPiece && square.Piece.Equals(thePiece));
        }

        [Test]
        public void SquareInitialisedWithRowAndColCorrectly()
        {
            int row = 4;
            int col = 4;
            Square square = new Square(row, col);

            Assert.AreEqual(square.Row, row);
            Assert.AreEqual(square.Col, col);
        }
    }
}
