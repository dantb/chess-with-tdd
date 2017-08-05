using Autofac;
using ChessWithTDD;
using NUnit.Framework;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class EnPassantTests
    {
        private const string EnPassantFolderPath = "../PositionFiles/EnPassant/";
        private const string WhitePawnCapturesBlackPawnUsingEnPassantFile = "WhitePawnCapturesBlackPawnUsingEnPassant";

        private PositionLoader _positionLoader;

        [OneTimeSetUp]
        public void SetUp()
        {
            _positionLoader = new PositionLoader();
        }

        [Test]
        public void WhitePawnCapturesBlackPawnUsingEnPassant()
        {
            const string path =  EnPassantFolderPath + WhitePawnCapturesBlackPawnUsingEnPassantFile;
            IBoard board = NewBoard();

            _positionLoader.LoadPositionIntoBoard(board, path);

            //Assert.That();
            Assert.Fail();
        }

        private IBoard NewBoard()
        {
            ContainerConfiguration.Configure();
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                IBoard board = scope.Resolve<IBoard>();
                return board;
            }
        }
    }
}
