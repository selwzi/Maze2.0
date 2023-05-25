using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0.ElementsMaze
{
    interface IWall : IElementMaze
    {
        IWall Clone();
        bool IsBroken();
    }
}
