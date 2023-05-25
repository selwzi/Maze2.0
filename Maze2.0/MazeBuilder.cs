using Maze2._0.ElementsMaze;

namespace Maze2._0
{
    class MazeBuilder
    {
        Maze _maze;
        IElementMazeFactory _elements;

		public MazeBuilder()
        {
            _maze = new Maze();
            _elements = new ElementMazeFactory();
        }

        public MazeBuilder SetSize(int height, int width)
        {
            _maze.Height = height;
            _maze.Width = width;
            return this;
        }

        public MazeBuilder SetElementMaze()
        {
            _maze.HardWall = _elements.CreateHardWall() as HardWall;
            _maze.WeakWall = _elements.CreateWeakWall(5) as WeakWall;
            _maze.Room1 = _elements.CreateRoom() as Room;
			_maze.EndRoom = _elements.CreateEndRoom() as EndRoom;
            return this;
		}

		public MazeBuilder SetStartPosition(Point start)
		{
			_maze.Start = start;
            return this;
		}

		public Maze Build()
        {
            _maze.Create();
            return _maze;
        }
	}
}
