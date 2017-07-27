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
        private IPositionStateManager _positionStateManager;

        public Board(IStrictServiceLocator serviceLocator)
        {
            InitialiseBoardDimensions();
            IBoardInitialiser boardInitialiser = serviceLocator.GetServiceBoardInitialiser();
            boardInitialiser.InitialiseBoardPieces(this);
            _moveExecutor = serviceLocator.GetServiceMoveExecutor();
            _moveValidator = serviceLocator.GetServiceMoveValidator();
            _boardCache = serviceLocator.GetServiceBoardCache();
            _positionStateManager = serviceLocator.GetServicePositionStateManager();
            _boardCache.InitialiseBoardCache(this);
        }

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
            return fromSquare.Piece.CanMove(fromSquare, toSquare);
        }      

        public void Apply(ISquare fromSquare, ISquare toSquare)
        {
            _moveExecutor.ExecuteMove(this, fromSquare, toSquare);

            _positionStateManager.SaveMove(fromSquare, toSquare, this);

            TurnCounter++;
        }

        public void SetSquare(ISquare square)
        {
            _squares[square.Row][square.Col] = square;
        }

        public IBoard UndoneMoveBoard()
        {
            throw new NotImplementedException();
        }

        public IBoard RedoneMoveBoard()
        {
            throw new NotImplementedException();
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
