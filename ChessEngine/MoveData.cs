using ChessWithTDD;

namespace ChessEngine
{
    /// <summary>
    /// Data transfer object containing the squares required to perform a move
    /// </summary>
    public class MoveData
    {
        public MoveData(ISquare fromSquare, ISquare toSquare)
        {
            FromSquare = fromSquare;
            ToSquare = toSquare;
        }

        public ISquare FromSquare { get; }
        public ISquare ToSquare { get; }
    }
}