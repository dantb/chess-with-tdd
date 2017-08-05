using Autofac;
using ChessWithTDD;
using System;
using System.IO;

namespace ChessWithTDDSystemTests
{
    internal static class CommonTestHelpers
    {
        private static string _positionFilesFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../PositionFiles/"));

        internal static PositionLoader PositionLoaderService { get; } = new PositionLoader();

        internal static string GetPositionFilePath(string folderName, string fileName)
        {
            return Path.Combine(_positionFilesFolder, folderName, fileName);
        }

        internal static IBoard NewBoard()
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
