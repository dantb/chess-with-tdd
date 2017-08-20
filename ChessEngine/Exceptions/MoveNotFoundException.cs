using System;

namespace ChessEngine
{
    public class MoveNotFoundException : Exception
    {
        public MoveNotFoundException(string message) : base(message) { }
    }
}
