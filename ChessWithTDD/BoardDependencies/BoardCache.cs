using System.Collections.Generic;
using static ChessWithTDD.BoardConstants;

namespace ChessWithTDD
{
    public class BoardCache : IBoardCache
    {
        private ISquare _blackKingSquare;
        private ISquare _whiteKingSquare;
        private IBoard _theBoard;

        public ISquare BlackKingSquare
        {
            get
            {
                return _blackKingSquare;
            }
        }

        public ISquare WhiteKingSquare
        {
            get
            {
                return _whiteKingSquare;
            }
        }

        public IBoard TheBoard
        {
            get
            {
                return _theBoard;
            }
        }

        public void InitialiseBoardCache(IBoard theBoard)
        {
            _theBoard = theBoard;
            _whiteKingSquare = theBoard.GetSquare(WHITE_BACK_ROW, KING_COLUMN);
            _blackKingSquare = theBoard.GetSquare(BLACK_BACK_ROW, KING_COLUMN);
        }

        public void UpdateBoardCache()
        {
            List<ISquare> squaresToRemoveFromUpdates = new List<ISquare>();
            foreach (var square in _theBoard.PendingUpdates)
            {
                if (square.ContainsPiece)
                {
                    if (square.Piece is IKing)
                    {
                        if (square.Piece.Colour == Colour.White)
                        {
                            _whiteKingSquare = _theBoard.GetSquare(square.Row, square.Col);
                            squaresToRemoveFromUpdates.Add(square);
                        }
                        else if (square.Piece.Colour == Colour.Black)
                        {
                            _blackKingSquare = _theBoard.GetSquare(square.Row, square.Col);
                            squaresToRemoveFromUpdates.Add(square);
                        }
                    }
                }
            }
            foreach (var square  in squaresToRemoveFromUpdates)
            {
                _theBoard.PendingUpdates.Remove(square);
            }
        }
    }
}
