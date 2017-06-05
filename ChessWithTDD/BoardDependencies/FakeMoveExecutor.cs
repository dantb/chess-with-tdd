using System;

namespace ChessWithTDD
{
    public class FakeMoveExecutor : IFakeMoveExecutor
    {
        public void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }

        public void ResetBoard(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
