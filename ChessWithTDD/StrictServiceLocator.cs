using System;

namespace ChessWithTDD
{
    public class StrictServiceLocator : IStrictServiceLocator
    {
        private IBoardCache _boardCache;
        private IBoardInitialiser _boardInitialiser;
        private ICheckManager _checkManager;
        private IMoveExecutor _moveExecutor;
        private IMoveValidator _moveValidator;
        private IPawnManager _pawnManager;

        public StrictServiceLocator(IBoardCache boardCache, 
                                    IBoardInitialiser boardInitialiser,
                                    ICheckManager checkManager,
                                    IMoveExecutor moveExecutor,
                                    IMoveValidator moveValidator, 
                                    IPawnManager pawnManager)
        {
            _boardCache = boardCache;
            _boardInitialiser = boardInitialiser;
            _checkManager = checkManager;
            _moveExecutor = moveExecutor;
            _moveValidator = moveValidator;
            _pawnManager = pawnManager;
        }

        public IBoardCache GetServiceBoardCache()
        {
            return _boardCache;
        }

        public IBoardInitialiser GetServiceBoardInitialiser()
        {
            return _boardInitialiser;
        }

        public ICheckManager GetServiceCheckManager()
        {
            return _checkManager;
        }

        public IMoveExecutor GetServiceMoveExecuter()
        {
            return _moveExecutor;
        }

        public IMoveValidator GetServiceMoveValidator()
        {
            return _moveValidator;
        }

        public IPawnManager GetServicePawnManager()
        {
            return _pawnManager;
        }
    }
}
