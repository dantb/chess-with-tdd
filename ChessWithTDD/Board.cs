using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class Board : IBoard
    {
        private List<List<ISquare>> _squares;
        private IMoveValidator _moveValidator;
        private IMoveExecutor _moveExecutor;
        private IBoardCache _boardCache;
        private IMoveIntoCheckValidator _moveIntoCheckValidator;

        /// <summary>
        /// The board should not be instantiated directly but should be resolved via the Autofac container builder.
        /// This will resolve the tree of dependencies at run time, for mappings see <see cref="ContainerConfiguration"/>
        /// </summary>
        public Board(IStrictServiceLocator serviceLocator)
        {
            InitialiseBoardDimensions();
            IBoardInitialiser boardInitialiser = serviceLocator.GetServiceBoardInitialiser();
            boardInitialiser.InitialiseBoardPieces(this);
            _moveExecutor = serviceLocator.GetServiceMoveExecutor();
            _moveValidator = serviceLocator.GetServiceMoveValidator();
            _boardCache = serviceLocator.GetServiceBoardCache();
            _moveIntoCheckValidator = serviceLocator.GetServiceMoveIntoCheckValidator();
            _boardCache.InitialiseBoardCache(this);
        }

        public event MoveAppliedEventHandler MoveAppliedEvent;

        #region Properties

        public List<ISquare> PendingUpdates { get; set; } = new List<ISquare>();

        public bool InCheck { get; set; } = false;

        public bool CheckMate { get; set; } = false;

        public int TurnCounter { get; set; } = 0;

        public int ColCount { get { return _squares.Count; } }

        public int RowCount { get { return _squares.FirstOrDefault().Count; } }

        public List<List<ISquare>> Squares { get { return _squares; } }

        public ISquare MovingTeamKingSquare
        {
            get
            {
                return TeamWithTurn == Colour.White ? _boardCache.WhiteKingSquare : _boardCache.BlackKingSquare;
            }
        }

        public HashSet<ISquare> MovingTeamPieceSquares
        {
            get
            {
                return TeamWithTurn == Colour.White ? _boardCache.WhitePieceSquares : _boardCache.BlackPieceSquares;
            }
        }

        public ISquare OtherTeamKingSquare
        {
            get
            {
                return TeamWithTurn == Colour.White ? _boardCache.BlackKingSquare : _boardCache.WhiteKingSquare;
            }
        }

        public HashSet<ISquare> OtherTeamPieceSquares
        {
            get
            {
                return TeamWithTurn == Colour.White ? _boardCache.BlackPieceSquares : _boardCache.WhitePieceSquares;
            }
        }

        public Colour TeamWithTurn
        {
            get
            {
                return TurnCounter % 2 == 0 ? Colour.White : Colour.Black;
            }
        }

        public ObservableCollection<MoveGenerationData> OrderedMoveData { get; } = new ObservableCollection<MoveGenerationData>();

        public MoveGenerationData MoveWithoutCheckAndMateUpdated { get; set; }

        #endregion

        #region Public methods

        public ISquare GetSquare(int row, int col)
        {
            return _squares[row][col];
        }

        public void UpdateBoardCache()
        {
            _boardCache.UpdateBoardCache();
        }

        public bool MoveIsValid(ISquare fromSquare, ISquare toSquare)
        {
            if (!_moveValidator.MoveIsValid(fromSquare, toSquare, this))
            {
                return false;
            }
            else if (!fromSquare.Piece.CanMove(fromSquare, toSquare))
            {
                return false;
            }
            else if (_moveIntoCheckValidator.MoveCausesMovingTeamCheck(this, fromSquare, toSquare))
            {
                //this has a requirement of being the final validation - there is a unit test to ensure this correct ordering
                return false;
            }
            return true;
        }      

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, this, fromSquare.Piece);

            _moveExecutor.ExecuteMove(this, fromSquare, toSquare);

            DoPostMoveApplicationUpdates(data);
        }

        public void ApplyWithoutUpdatingCheckAndMate(ISquare fromSquare, ISquare toSquare)
        {
            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, this, fromSquare.Piece);

            _moveExecutor.ExecuteMoveWithoutUpdatingCheckAndMate(this, fromSquare, toSquare);

            DoPostMoveApplicationUpdates(data);
        }

        public void SetSquare(ISquare square)
        {
            _squares[square.Row][square.Col] = square;
        }

        #endregion

        private void InitialiseBoardDimensions()
        {
            _squares = new List<List<ISquare>>();
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                List<ISquare> rowOfBoard = new List<ISquare>();
                for (int j = 0; j < BOARD_DIMENSION; j++)
                {
                    rowOfBoard.Add(new Square(i, j));
                }
                _squares.Add(rowOfBoard);
            }
        }

        private void DoPostMoveApplicationUpdates(MoveGenerationData data)
        {
            MoveAppliedEventArgs e = new MoveAppliedEventArgs(data);
            MoveAppliedEvent?.Invoke(this, e);

            TurnCounter++;

            //should be the last thing to happen, since only now is the move application complete: there is a unit test for this requirement
            OrderedMoveData.Add(data);
        }
    }
}
