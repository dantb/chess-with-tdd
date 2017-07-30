using System;

namespace ChessWithTDD
{
    public class MoveExecutor : IMoveExecutor
    {
        private IPawnManager _pawnManager;
        private ICheckManager _checkManager;

        public MoveExecutor(IPawnManager pawnManager, ICheckManager checkManager)
        {
            _pawnManager = pawnManager;
            _checkManager = checkManager;
        }

        public void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            ExecuteMoveWithoutUpdatingCheckAndMate(board, fromSquare, toSquare);

            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, board, toSquare.Piece);
            board.MoveWithoutCheckAndMateUpdated = data;
            //Evaluate check states after move has been applied
            _checkManager.UpdateCheckAndCheckMateStates(board, toSquare);
            board.MoveWithoutCheckAndMateUpdated = null;
        }

        public void ExecuteMoveWithoutUpdatingCheckAndMate(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IPawn)
            {
                _pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, board);
            }

            //Squares that had been marked two turns ago should be unmarked
            _pawnManager.UnmarkEnPassantSquares(board.TurnCounter);

            //This is where we actually execute the move
            ActualApply(board, fromSquare, toSquare);

            //Update board cache for easy access to pieces
            board.UpdateBoardCache();
        }

        private void ActualApply(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            theBoard.GetSquare(toSquare.Row, toSquare.Col).Piece = fromSquare.Piece;
            theBoard.GetSquare(toSquare.Row, toSquare.Col).ContainsPiece = true;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).Piece = null;
            theBoard.GetSquare(fromSquare.Row, fromSquare.Col).ContainsPiece = false;
            theBoard.PendingUpdates.Add(fromSquare);
            theBoard.PendingUpdates.Add(toSquare);
        }
    }
}
