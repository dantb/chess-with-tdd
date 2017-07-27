using System;

namespace ChessWithTDD
{
    class PositionStateManager : IPositionStateManager
    {
        public IBoard RedoneMoveBoard()
        {
            throw new NotImplementedException();
        }

        public void SaveMove(ISquare fromSquare, ISquare toSquare, IBoard board)
        {
            throw new NotImplementedException();
        }

        public IBoard UndoneMoveBoard()
        {
            throw new NotImplementedException();
        }
    }
}
