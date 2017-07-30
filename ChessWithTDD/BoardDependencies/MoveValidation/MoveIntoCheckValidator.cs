using Autofac;
using System.Windows.Forms;

namespace ChessWithTDD
{
    public class MoveIntoCheckValidator : IMoveIntoCheckValidator
    {
        public bool MoveCausesMovingTeamCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            try
            {
                if (toSquare.Piece is IKing)
                {
                    //special case, not into check since this would end the game
                    return false;
                }
                else
                {
                    //it doesn't matter whether the moving piece is a king or not, we still need to run the scenario
                    //that this move is applied and then analyse the resulting board
                    return MoveResultsInOurKingBeingInCheck(theBoard, fromSquare, toSquare);
                }
            }
            catch
            {
                //error meant the move screwed up the board - special error handling as this can help find edge cases
                MessageBox.Show("Error in move into check validator.");
                return false;
            }          
        }

        private bool MoveResultsInOurKingBeingInCheck(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            IBoard newBoard = GetNewBoardWithThisMoveApplied(theBoard, fromSquare, toSquare);

            //can the other team whose turn it is move onto our king after our move?
            ISquare newBoardKingSquare = newBoard.OtherTeamKingSquare;
            foreach (ISquare square in newBoard.MovingTeamPieceSquares)
            {
                if (newBoard.MoveIsValid(square, newBoardKingSquare))
                {
                    return true;
                }
            }
            return false;
        }

        private IBoard GetNewBoardWithThisMoveApplied(IBoard theBoard, ISquare fromSquare, ISquare toSquare)
        {
            IBoard newBoard;
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                newBoard = scope.Resolve<IBoard>();
            }
            foreach (MoveGenerationData data in theBoard.OrderedMoveData)
            {
                ISquare fs = newBoard.GetSquare(data.Move.FromRow, data.Move.FromCol);
                ISquare ts = newBoard.GetSquare(data.Move.ToRow, data.Move.ToCol);
                newBoard.Apply(fs, ts);
            }
            if (theBoard.MoveWithoutCheckAndMateUpdated != null)
            {
                MoveGenerationData data = theBoard.MoveWithoutCheckAndMateUpdated;
                ISquare fs = newBoard.GetSquare(data.Move.FromRow, data.Move.FromCol);
                ISquare ts = newBoard.GetSquare(data.Move.ToRow, data.Move.ToCol);
                newBoard.ApplyWithoutUpdatingCheckAndMate(fs, ts);
            }
            ISquare newBoardFromSquare = newBoard.GetSquare(fromSquare.Row, fromSquare.Col);
            ISquare newBoardToSquare = newBoard.GetSquare(toSquare.Row, toSquare.Col);
            newBoard.ApplyWithoutUpdatingCheckAndMate(newBoardFromSquare, newBoardToSquare);
            return newBoard;
        }
    }
}
