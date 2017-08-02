using NUnit.Framework;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class CastlingMoveValidatorTests
    {
        [Test]
        public void InvalidCastleIfKingHasMoved()
        {

        }

        [Test]
        public void InvalidCastleIfKingInCheck()
        {

        }

        [Test]
        public void InvalidKingSideCastleIfRightRookHasMoved()
        {

        }

        [Test]
        public void InvalidQueenSideCastleIfLeftRookHasMoved()
        {

        }

        [Test]
        public void InvalidKingSideCastleIfPieceBetweenKingAndRook()
        {

        }

        [Test]
        public void InvalidQueenSideCastleIfPieceBetweenKingAndRook()
        {

        }

        [Test]
        public void InvalidKingSideCastleIfKingMovesThroughAttackedSquare()
        {

        }

        [Test]
        public void InvalidQueenSideCastleIfKingMovesThroughAttackedSquare()
        {

        }

        [Test]
        public void InvalidKingSideCastleIfKingWouldBeInCheckAfterMove()
        {

        }

        [Test]
        public void InvalidQueenSideCastleIfKingWouldBeInCheckAfterMove()
        {

        }

        [Test]
        public void ValidKingSideCastle()
        {

        }

        [Test]
        public void ValidQueenSideCastle()
        {

        }
    }
}