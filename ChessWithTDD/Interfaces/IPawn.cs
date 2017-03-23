using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessWithTDD
{
    public interface IPawn : IPiece
    {
        bool HasMoved { get; set; }
    }
}
