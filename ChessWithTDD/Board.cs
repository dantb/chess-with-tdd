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
                return TurnCounter % 2 == 0 ? _boardCache.WhiteKingSquare : _boardCache.BlackKingSquare;
            }
        }

        public HashSet<ISquare> MovingTeamPieceSquares
        {
            get
            {
                return TurnCounter % 2 == 0 ? _boardCache.WhitePieceSquares : _boardCache.BlackPieceSquares;
            }
        }

        public ISquare OtherTeamKingSquare
        {
            get
            {
                return TurnCounter % 2 == 0 ? _boardCache.BlackKingSquare : _boardCache.WhiteKingSquare;
            }
        }

        public HashSet<ISquare> OtherTeamPieceSquares
        {
            get
            {
                return TurnCounter % 2 == 0 ? _boardCache.BlackPieceSquares : _boardCache.WhitePieceSquares;
            }
        }

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

            TurnCounter++;
        }

        public void SetSquare(ISquare square)
        {
            _squares[square.Row][square.Col] = square;
        }

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
