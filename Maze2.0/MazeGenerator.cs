using Maze2._0.ElementsMaze;

namespace Maze2._0
{
	class MazeGenerator
	{
		private Maze _maze;
		private IElementMaze[,] _structMaze;
		Random _rd = new Random();
		Stack<Point> _stack = new Stack<Point>();
		List<Point> _noVisited = new List<Point>();

		public MazeGenerator(Maze maze)
		{
			_maze = maze;	
			_structMaze = new IElementMaze[_maze.Height, _maze.Width];

			for (int i = 0; i < _maze.Height; i++)
			{
				for (int j = 0; j < _maze.Width; j++)
				{
					if (i == 0 || i == _maze.Height - 1 || j == 0 || j == _maze.Width - 1)
						_structMaze[i, j] = _maze.HardWall.Clone();
					else if ((i % 2 != 0 && j % 2 != 0) && (i <= _maze.Height - 1 && j <= _maze.Width - 1))
					{
						_structMaze[i, j] = _maze.Room1;
						_noVisited.Add(new Point(j, i));
					}
					else
					{
						_structMaze[i, j] = _maze.WeakWall.Clone();
						_maze.WeakWall.Hardness = _rd.Next(1, 6);
					}
				}
			}

			_maze.End = _noVisited[_rd.Next(1, (_noVisited.Count - 1))];
		}

		private bool IsInBounds(Point p)
		{
			return p.x >= 0 && p.x < _maze.Width && p.y >= 0 && p.y < _maze.Height;
		}


		private List<Point> GetUnvisited(Point p)
		{
			var neighbour = new List<Point>();
			var leftPoint = new Point(p.x - 2, p.y);
			var rightPoint = new Point(p.x + 2, p.y);
			var upPoint = new Point(p.x, p.y - 2);
			var downPoint = new Point(p.x, p.y + 2);

			if (IsInBounds(leftPoint) && _noVisited.Contains(leftPoint))
			{
				neighbour.Add(leftPoint);
			}
			if (IsInBounds(rightPoint) && _noVisited.Contains(rightPoint))
			{
				neighbour.Add(rightPoint);
			}
			if (IsInBounds(upPoint) && _noVisited.Contains(upPoint))
			{
				neighbour.Add(upPoint);
			}
			if (IsInBounds(downPoint) && _noVisited.Contains(downPoint))
			{
				neighbour.Add(downPoint);
			}

			return neighbour;
		}

		private void RemoveWall(Point p1, Point p2)
		{
			if (p1.x == p2.x)
				_structMaze[Math.Min(p1.y, p2.y) + 1, p1.x] = _maze.Room1;
			else
				_structMaze[p1.y, Math.Min(p1.x, p2.x) + 1] = _maze.Room1;
		}

		public IElementMaze[,] Generate()
		{
			var current = new Point(1, 1);
			_noVisited.Remove(current);

			while (_noVisited.Count > 0)
			{
				var neighbours = GetUnvisited(current);

				if (neighbours.Count > 0)
				{
					_stack.Push(current);
					var next = neighbours[_rd.Next(neighbours.Count)];
					RemoveWall(current, next);
					current = next;
					_noVisited.Remove(next);
				}
				else if (_stack.Count > 0)
					current = _stack.Pop();
				else
				{
					current = _noVisited[_rd.Next(0, (_noVisited.Count - 1))];
					_noVisited.Remove(current);
				}
			}

			return _structMaze;
		}
	}
}
