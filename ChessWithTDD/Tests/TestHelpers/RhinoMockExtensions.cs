using Rhino.Mocks.Interfaces;

namespace ChessWithTDD.Tests.TestHelpers
{
    public static class RhinoMockExtensions
    {
        internal static void OverridePrevious<T>(this IMethodOptions<T> options)
        {
            options.Repeat.Any();
        }
    }
}
