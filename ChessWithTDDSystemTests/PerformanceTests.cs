using Autofac;
using ChessWithTDD;
using NUnit.Framework;
using System.Diagnostics;
using static ChessWithTDDSystemTests.CommonTestHelpers;

namespace ChessWithTDDSystemTests
{
    [TestFixture]
    public class PerformanceTests
    {
        private const string GeneralTestsFolder = "GeneralTests";
        private const string FullGameToCheckMate_1File = "FullGameToCheckMate_1.txt";


        [Test]
        public void TestFullLoadingOfBoardPerformanceWithAndWithoutCloningOfBoard()
        {
            string path = GetPositionFilePath(GeneralTestsFolder, FullGameToCheckMate_1File);

            // load up without cloning
            ContainerConfiguration.ConfigureWithMoveIntoCheckValidatorUsingOldImplementation();
            IBoard board;
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                board = scope.Resolve<IBoard>();
            }
            Stopwatch swWithoutCloning = new Stopwatch();
            swWithoutCloning.Start();
            PositionLoaderService.LoadPositionIntoBoard(board, path);
            swWithoutCloning.Stop();
            double withoutCloningTime = swWithoutCloning.ElapsedMilliseconds;

            // now with cloning (which is now the default implementation)
            IBoard secondBoard;
            ContainerConfiguration.Configure();
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                secondBoard = scope.Resolve<IBoard>();
            }

            Stopwatch swWithCloning = new Stopwatch();
            swWithCloning.Start();
            PositionLoaderService.LoadPositionIntoBoard(secondBoard, path);
            swWithCloning.Stop();
            double withCloningTime = swWithCloning.ElapsedMilliseconds;

            // assert that this is a lot faster
            Assert.True( withCloningTime < withoutCloningTime * 20 );
        }
    }
}
