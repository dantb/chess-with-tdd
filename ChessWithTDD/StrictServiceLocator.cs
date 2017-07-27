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
        private IPositionStateManager _positionStateManager;

        public StrictServiceLocator(IBoardCache boardCache, 
                                    IBoardInitialiser boardInitialiser,
                                    ICheckManager checkManager,
                                    IMoveExecutor moveExecutor,
                                    IMoveValidator moveValidator, 
                                    IPawnManager pawnManager,
                                    IPositionStateManager positionStateManager)
        {
            _boardCache = boardCache;
            _boardInitialiser = boardInitialiser;
            _checkManager = checkManager;
            _moveExecutor = moveExecutor;
            _moveValidator = moveValidator;
            _pawnManager = pawnManager;
            _positionStateManager = positionStateManager;
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

        public IMoveExecutor GetServiceMoveExecutor()
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

        public IPositionStateManager GetServicePositionStateManager()
        {
            return _positionStateManager;
        }
    }
}
