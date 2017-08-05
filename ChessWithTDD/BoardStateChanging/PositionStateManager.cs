using Autofac;
using System.Collections.Generic;

namespace ChessWithTDD
{
    public class PositionStateManager : IPositionStateManager
    {
        Queue<MoveGenerationData> _doneMoveQueue = new Queue<MoveGenerationData>();
        Stack<MoveGenerationData> _undoneMoveStack = new Stack<MoveGenerationData>();

        public IBoard RedoneMoveBoard(IBoard oldBoard)
        {
            if (_undoneMoveStack.Count == 0)
            {
                //nothing to redo
                return oldBoard;
            }

            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                IBoard board = scope.Resolve<IBoard>();
                int counter = 0;
                int originalCount = _doneMoveQueue.Count;
                Queue<MoveGenerationData> newQueue = new Queue<MoveGenerationData>();
                while (counter < originalCount)
                {
                    MoveGenerationData data = _doneMoveQueue.Dequeue();
                    newQueue.Enqueue(data); //still need to keep this
                    ISquare fromSquare = board.GetSquare(data.Move.FromRow, data.Move.FromCol);
                    ISquare toSquare = board.GetSquare(data.Move.ToRow, data.Move.ToCol);
                    board.Apply(fromSquare, toSquare);
                    counter++;
                }
                if (_undoneMoveStack.Count > 0)
                {
                    MoveGenerationData data = _undoneMoveStack.Pop();
                    ISquare fromSquare = board.GetSquare(data.Move.FromRow, data.Move.FromCol);
                    ISquare toSquare = board.GetSquare(data.Move.ToRow, data.Move.ToCol);
                    board.Apply(fromSquare, toSquare);
                    newQueue.Enqueue(data); //requeue again in the new done queue 
                }
                _doneMoveQueue = newQueue;
                return board;
            }
        }

        public void SaveMove(MoveGenerationData data)
        {
            _doneMoveQueue.Enqueue(data);
            //wipes out the undone moves since we've taken a different route (not via redo)
            _undoneMoveStack.Clear();
        }

        public IBoard UndoneMoveBoard()
        {
            using (var scope = ContainerConfiguration.Container.BeginLifetimeScope())
            {
                IBoard board = scope.Resolve<IBoard>();
                int counter = 0;
                int originalCount = _doneMoveQueue.Count;
                Queue<MoveGenerationData> newQueue = new Queue<MoveGenerationData>();
                while (counter < originalCount - 1)
                {
                    MoveGenerationData data = _doneMoveQueue.Dequeue();
                    newQueue.Enqueue(data); //still need to keep this
                    ISquare fromSquare = board.GetSquare(data.Move.FromRow, data.Move.FromCol);
                    ISquare toSquare = board.GetSquare(data.Move.ToRow, data.Move.ToCol);
                    board.Apply(fromSquare, toSquare);
                    counter++;
                }
                if (_doneMoveQueue.Count > 0)
                {
                    _undoneMoveStack.Push(_doneMoveQueue.Dequeue()); //take off final one
                }
                _doneMoveQueue = newQueue;
                return board;
            }
        }
    }
}
