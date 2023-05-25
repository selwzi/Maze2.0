using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze2._0.ElementsMaze;

namespace Maze2._0
{
    class ElementMazeFactory : IElementMazeFactory
	{
		public IRoom CreateRoom() => Room.GetRoom();

		public IWall CreateWeakWall(int hardness) => new WeakWall(hardness);

		public IWall CreateHardWall() => new HardWall();

		public IRoom CreateEndRoom() => new EndRoom();
	}
}
