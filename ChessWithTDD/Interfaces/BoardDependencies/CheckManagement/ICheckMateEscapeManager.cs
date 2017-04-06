using System.Collections.Generic;

namespace ChessWithTDD
{
    public interface ICheckMateEscapeManager
    {
        bool ThreateningPieceIsUnblockable(ISquare threateningSquare, ISquare kingSquare);

        bool KingCanEscape(IBoard theBoard, ISquare kingSquare);

        bool ThreateningPieceCanBeCaptured(HashSet<ISquare> friendlySquares, IBoard theBoard, ISquare threateningSquare);
    }
}
