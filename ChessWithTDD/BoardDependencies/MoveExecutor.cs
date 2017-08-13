namespace ChessWithTDD
{
    public class MoveExecutor : IMoveExecutor
    {
        private IPawnManager _pawnManager;
        private ICheckManager _checkManager;
        private ICastlingExecutor _castlingExecutor;

        public MoveExecutor(IPawnManager pawnManager, ICheckManager checkManager, ICastlingExecutor castlingExecutor)
        {
            _pawnManager = pawnManager;
            _checkManager = checkManager;
            _castlingExecutor = castlingExecutor;
        }

        public void ExecuteMove(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            ExecuteMoveWithoutUpdatingCheckAndMate(board, fromSquare, toSquare);

            UpdateCheckAndMateStates(board, fromSquare, toSquare);
        }

        private void UpdateCheckAndMateStates(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            MoveGenerationData data = new MoveGenerationData(fromSquare, toSquare, board, toSquare.Piece);

            // TODO : During the updating of check and mate states we'll need to "fake" apply this current move, to get the board's
            // positioning correct but without the check and mate being updated (had these been included this would cause a stack overflow)
            // This cannot be the best solution to this problem, the TODO is fix this in a nicer way
            board.MoveWithoutCheckAndMateUpdated = data;

            //Evaluate check states after move has been applied
            _checkManager.UpdateCheckAndCheckMateStates(board, toSquare);

            // reset the data back to null (no fake move needs to be applied now)
            board.MoveWithoutCheckAndMateUpdated = null;
        }

        public void ExecuteMoveWithoutUpdatingCheckAndMate(IBoard board, ISquare fromSquare, ISquare toSquare)
        {
            if (fromSquare.Piece is IPawn)
            {
                _pawnManager.MakePawnSpecificAmendments(fromSquare, toSquare, board);
            }

            if (fromSquare.Piece is IKing)
            {
                _castlingExecutor.ExecuteCastlingMove(fromSquare, toSquare, board);
            }

            if (fromSquare.Piece is IRook)
            {
                (fromSquare.Piece as IRook).HasMoved = true;
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
