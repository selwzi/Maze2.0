using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze2._0.ElementsMaze;

namespace Maze2._0
{
    interface IElementMazeFactory
    {
        IRoom CreateRoom();
        IRoom CreateEndRoom();
        IWall CreateHardWall();
        IWall CreateWeakWall(int hardness);
    }
}
