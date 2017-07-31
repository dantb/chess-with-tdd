using NUnit.Framework;
using static Rhino.Mocks.MockRepository;

namespace ChessWithTDD.Tests
{
    [TestFixture]
    public class StrictServiceLocatorTests
    {
        //This is the system under test
        private StrictServiceLocator _serviceLocator;
        //These are the mocked services
        private IBoardCache _boardCache;
        private IBoardInitialiser _boardInitialiser;
        private ICheckManager _checkManager;
        private IMoveExecutor _moveExecutor;
        private IMoveValidator _moveValidator;
        private IPawnManager _pawnManager;
        private IMoveIntoCheckValidator _moveIntoCheckValidator;

        [OneTimeSetUp]
        public void InstantiateServiceLocatorWithDependencies()
        {
            _boardInitialiser = GenerateMock<IBoardInitialiser>();
            _pawnManager = GenerateMock<IPawnManager>();
            _boardCache = GenerateMock<IBoardCache>();
            _checkManager = GenerateMock<ICheckManager>();
            _moveValidator = GenerateMock<IMoveValidator>();
            _moveExecutor = GenerateMock<IMoveExecutor>();
            _moveIntoCheckValidator = GenerateMock<IMoveIntoCheckValidator>();
            _serviceLocator =
                new StrictServiceLocator(_boardCache, _boardInitialiser, _checkManager, _moveExecutor,
                    _moveValidator, _pawnManager, _moveIntoCheckValidator);
        }

        [Test]
        public void BoardCacheServiceIsImplemented()
        {
            IBoardCache boardCacheService = _serviceLocator.GetServiceBoardCache();

            Assert.AreEqual(boardCacheService, _boardCache);
        }

        [Test]
        public void BoardInitialiserServiceIsImplemented()
        {
            IBoardInitialiser boardInitialiserService = _serviceLocator.GetServiceBoardInitialiser();

            Assert.AreEqual(boardInitialiserService, _boardInitialiser);
        }

        [Test]
        public void CheckManagerServiceIsImplemented()
        {
            ICheckManager checkManagerService = _serviceLocator.GetServiceCheckManager();

            Assert.AreEqual(checkManagerService, _checkManager);
        }

        [Test]
        public void MoveValidatorServiceIsImplemented()
        {
            IMoveValidator moveValidatorService = _serviceLocator.GetServiceMoveValidator();

            Assert.AreEqual(moveValidatorService, _moveValidator);
        }

        [Test]
        public void PawnManagerServiceIsImplemented()
        {
            IPawnManager pawnManagerService = _serviceLocator.GetServicePawnManager();

            Assert.AreEqual(pawnManagerService, _pawnManager);
        }

        [Test]
        public void MoveExecutorServiceIsImplemented()
        {
            IMoveExecutor moveExecutorService = _serviceLocator.GetServiceMoveExecutor();

            Assert.AreEqual(moveExecutorService, _moveExecutor);
        }

        [Test]
        public void MoveIntoCheckValidatorServiceIsImplemented()
        {
            IMoveIntoCheckValidator moveIntoCheckValidator = _serviceLocator.GetServiceMoveIntoCheckValidator();

            Assert.AreEqual(moveIntoCheckValidator, _moveIntoCheckValidator);
        }
    }
}
