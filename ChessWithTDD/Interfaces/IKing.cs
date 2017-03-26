using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWithTDD
{
    public interface IKing : IPiece
    {
        bool InCheckState { get; set; }
    }
}
