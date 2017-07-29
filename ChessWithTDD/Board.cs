using System;
using System.Collections.Generic;
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
        private List<MoveGenerationData> _orderedMoveData = new List<MoveGenerationData>();

        /// <summary>
        /// The board should not be instantiated directly but should be resolved via the Autofac container builder.
        /// This will resolve the tree of dependencies at run time, <see cref="ContainerConfiguration"/>
        /// </summary>
        public Board(IStrictServiceLocator serviceLocator)
        {
            InitialiseBoardDimensions();
            IBoardInitialiser boardInitialiser = serviceLocator.GetServiceBoardInitialiser();
            boardInitialiser.InitialiseBoardPieces(this);
            _moveExecutor = serviceLocator.GetServiceMoveExecutor();
            _moveValidator = serviceLocator.GetServiceMoveValidator();
            _boardCache = serviceLocator.GetServiceBoardCache();
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

        public List<MoveGenerationData> OrderedMoveData { get { return _orderedMoveData; } }

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
            MoveIntoCheckValidator moveIntoCheckValidator = new MoveIntoCheckValidator();
            if (!_moveValidator.MoveIsValid(fromSquare, toSquare, this))
            {
                return false;
            }
            else if (!fromSquare.Piece.CanMove(fromSquare, toSquare))
            {
                return false;
            }
            //last validation we should do, assuming everything else is fine, is the validation requiring future board
            //positions to evaluate - such as moving into check
            return !moveIntoCheckValidator.MoveCausesMovingTeamCheck(this, fromSquare, toSquare);
        }      

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            _moveExecutor.ExecuteMove(this, fromSquare, toSquare);

            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, this, toSquare.Piece);
            _orderedMoveData.Add(data);
            MoveAppliedEventArgs e = new MoveAppliedEventArgs(data);
            MoveAppliedEvent?.Invoke(this, e);

            TurnCounter++;
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
    }
}
