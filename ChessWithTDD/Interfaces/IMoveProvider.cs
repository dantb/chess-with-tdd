using System;

namespace ChessWithTDD
{
    public interface IMoveProvider
    {
        event MoveProviderEventHandler MoveChosenEvent;
    }

    public class MoveProviderEventArgs : EventArgs
    {
        public MoveProviderEventArgs(IMove theMove)
        {
            TheMove = theMove;
        }

        public IMove TheMove { get; private set; }
    }

    public delegate void MoveProviderEventHandler(object sender, MoveProviderEventArgs eventArgs);
}
