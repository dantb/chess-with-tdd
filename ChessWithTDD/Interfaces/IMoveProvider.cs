using System;

namespace ChessWithTDD
{
    public interface IMoveProvider
    {
        event MoveProviderEventHandler MoveChosenEvent;
    }

    public class MoveProviderEventArgs : EventArgs
    {
        public MoveProviderEventArgs(Move theMove)
        {
            TheMove = theMove;
        }

        public Move TheMove { get; }
    }

    public delegate void MoveProviderEventHandler(object sender, MoveProviderEventArgs eventArgs);
}
