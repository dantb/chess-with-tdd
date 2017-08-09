using System.Collections.Generic;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class BoardCache : IBoardCache
    {
        private HashSet<ISquare> _whitePieceSquares;
        private HashSet<ISquare> _blackPieceSquares;
        private ISquare _blackKingSquare;
        private ISquare _whiteKingSquare;
        private IBoard _theBoard;

        public BoardCache()
        {
            _whitePieceSquares = new HashSet<ISquare>();
            _blackPieceSquares = new HashSet<ISquare>();
        }

        public ISquare BlackKingSquare { get { return _blackKingSquare; } }

        public ISquare WhiteKingSquare { get { return _whiteKingSquare; } }

        public IBoard TheBoard { get { return _theBoard; } }

        public HashSet<ISquare> WhitePieceSquares { get { return _whitePieceSquares; } }

        public HashSet<ISquare> BlackPieceSquares { get { return _blackPieceSquares; } }

        public void InitialiseBoardCache(IBoard theBoard)
        {
            _theBoard = theBoard;
            _whiteKingSquare = theBoard.GetSquare(WHITE_BACK_ROW, KING_COLUMN);
            _blackKingSquare = theBoard.GetSquare(BLACK_BACK_ROW, KING_COLUMN);
            InitialisePawnRows(theBoard);
            InitialiseWhiteBackRow(theBoard);
            InitialiseBlackBackRow(theBoard);
        }

        public void UpdateBoardCache()
        {
            HashSet<ISquare> squaresToRemoveFromUpdates = new HashSet<ISquare>();
            foreach (var square in _theBoard.PendingUpdates)
            {
                if (square.ContainsPiece)
                {
                    if (square.Piece is IKing)
                    {
                        AddKingToCache(squaresToRemoveFromUpdates, square);
                    }
                    else
                    {
                        AddPieceToCache(squaresToRemoveFromUpdates, square);
                    }
                }
                else
                {
                    RemoveSquareFromCaches(squaresToRemoveFromUpdates, square);
                }
            }
            foreach (var square  in squaresToRemoveFromUpdates)
            {
                _theBoard.PendingUpdates.Remove(square);
            }
        }

        private void RemoveSquareFromCaches(HashSet<ISquare> squaresToRemoveFromUpdates, ISquare square)
        {
            //no longer cache since the cache is piece driven
            _whitePieceSquares.Remove(square);
            _blackPieceSquares.Remove(square);
            squaresToRemoveFromUpdates.Add(square);
        }

        private void AddPieceToCache(HashSet<ISquare> squaresToRemoveFromUpdates, ISquare square)
        {
            if (square.Piece.Colour == Colour.White)
            {
                _whitePieceSquares.Add(_theBoard.GetSquare(square.Row, square.Col));
                _blackPieceSquares.Remove(square); //TODO UNIT TEST THIS REQUIREMENT - of course we have to remove from the other cache in capture case
                squaresToRemoveFromUpdates.Add(square);
            }
            else if (square.Piece.Colour == Colour.Black)
            {
                _blackPieceSquares.Add(_theBoard.GetSquare(square.Row, square.Col));
                _whitePieceSquares.Remove(square); //TODO UNIT TEST THIS REQUIREMENT - of course we have to remove from the other cache in capture case
                squaresToRemoveFromUpdates.Add(square);
            }
        }

        private void AddKingToCache(HashSet<ISquare> squaresToRemoveFromUpdates, ISquare square)
        {
            if (square.Piece.Colour == Colour.White)
            {
                _whiteKingSquare = _theBoard.GetSquare(square.Row, square.Col);
                _whitePieceSquares.Add(square);
                _blackPieceSquares.Remove(square);
                squaresToRemoveFromUpdates.Add(square);
            }
            else if (square.Piece.Colour == Colour.Black)
            {
                _blackKingSquare = _theBoard.GetSquare(square.Row, square.Col);
                _blackPieceSquares.Add(square);
                _whitePieceSquares.Remove(square);
                squaresToRemoveFromUpdates.Add(square);
            }
        }

        private void InitialisePawnRows(IBoard theBoard)
        {
            for (int i = 0; i < BOARD_DIMENSION; i++)
            {
                _whitePieceSquares.Add(theBoard.GetSquare(WHITE_PAWN_INITAL_ROW, i));
                _blackPieceSquares.Add(theBoard.GetSquare(BLACK_PAWN_INITAL_ROW, i));
            }
        }

        private void InitialiseBlackBackRow(IBoard theBoard)
        {
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, LEFT_ROOK_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, RIGHT_ROOK_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, LEFT_BISHOP_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, RIGHT_BISHOP_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, LEFT_KNIGHT_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, RIGHT_KNIGHT_COL));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, QUEEN_COLUMN));
            _blackPieceSquares.Add(theBoard.GetSquare(BLACK_BACK_ROW, KING_COLUMN));
        }

        private void InitialiseWhiteBackRow(IBoard theBoard)
        {
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, LEFT_ROOK_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, RIGHT_ROOK_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, LEFT_BISHOP_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, RIGHT_BISHOP_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, LEFT_KNIGHT_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, RIGHT_KNIGHT_COL));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, QUEEN_COLUMN));
            _whitePieceSquares.Add(theBoard.GetSquare(WHITE_BACK_ROW, KING_COLUMN));
        }
    }
}
