using System;

namespace ChessWithTDD
{
    public class MoveExecutor : IMoveExecutor
    {
        private IPawnManager _pawnManager;
        private ICheckManager _checkManager;

        public MoveExecutor(IStrictServiceLocator serviceLocator)
        {
            _pawnManager = serviceLocator.GetServicePawnManager();
            _checkManager = serviceLocator.GetServiceCheckManager();
        }

        public void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            throw new NotImplementedException();
        }
    }
}
