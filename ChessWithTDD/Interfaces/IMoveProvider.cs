using System;

namespace ChessWithTDD
{
    public interface IMoveProvider
    {
        event EventHandler MoveChosenEvent;
    }

    public class MoveProviderEventArgs : EventArgs
    {
        public MoveProviderEventArgs(IMove theMove)
        {
            TheMove = theMove;
        }

        public IMove TheMove { get; private set; }
    }
}
