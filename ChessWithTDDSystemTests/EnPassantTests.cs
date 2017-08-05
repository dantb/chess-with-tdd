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
        private const string BlackPawnCapturesWhitePawnUsingEnPassantFile = "BlackPawnCapturesWhitePawnUsingEnPassant.txt";

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
            string path = GetPositionFilePath(EnPassantFolder, WhitePawnCapturesBlackPawnUsingEnPassantFile);
            IBoard board = NewBoard();

            _positionLoader.LoadPositionIntoBoard(board, path);

            ISquare takenBlackPawnSquare = board.GetSquare(4, 5);
            Assert.False(takenBlackPawnSquare.ContainsPiece);
        }

        [Test]
        public void BlackPawnCapturesWhitePawnUsingEnPassant()
        {
            string path = GetPositionFilePath(EnPassantFolder, BlackPawnCapturesWhitePawnUsingEnPassantFile);
            IBoard board = NewBoard();

            _positionLoader.LoadPositionIntoBoard(board, path);

            ISquare takenBlackPawnSquare = board.GetSquare(3, 2);
            Assert.False(takenBlackPawnSquare.ContainsPiece);
        }

        private string GetPositionFilePath(string folderName, string fileName)
        {
            return Path.Combine(_positionFilesFolder, folderName, fileName);
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
