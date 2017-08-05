using Autofac;
using ChessWithTDD;
using NUnit.Framework;
using System;
using System.IO;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class EnPassantTests
    {
        private const string EnPassantFolder = "EnPassant";
        private const string WhitePawnCapturesBlackPawnUsingEnPassantFile = "WhitePawnCapturesBlackPawnUsingEnPassant.txt";

        private string _positionFilesFolder;
        private PositionLoader _positionLoader;

        [OneTimeSetUp]
        public void SetUp()
        {
            _positionLoader = new PositionLoader();
            _positionFilesFolder =  Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../PositionFiles/"));
        }

        [Test]
        public void WhitePawnCapturesBlackPawnUsingEnPassant()
        {
            string path = Path.Combine(_positionFilesFolder, EnPassantFolder, WhitePawnCapturesBlackPawnUsingEnPassantFile);
            IBoard board = NewBoard();

            _positionLoader.LoadPositionIntoBoard(board, path);

            ISquare takenBlackPawnSquare = board.GetSquare(4, 5);
            Assert.False(takenBlackPawnSquare.ContainsPiece);
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
