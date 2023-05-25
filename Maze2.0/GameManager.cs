using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze2._0.ElementsMaze;

namespace Maze2._0
{
    class GameManager
	{
		private readonly Game game;

		public GameManager(Game game)
		{
			this.game = game;
		}

		public void Start()
		{
			var start = game.Maze.Start;
			var end = game.Maze.End;
			game.Player1.MoveTo(start);
			game.Maze[game.Player1.Location.x, game.Player1.Location.y] = game.Player1;

			while (true)
			{
				Console.Clear();
				Console.WriteLine(game.Maze.Print());

				if (game.Player1.Location.Equals(end))
				{
					Console.WriteLine("Игра окончена");
					break;
				}

				ConsoleKeyInfo key = Console.ReadKey(true);

				if (key.Key == ConsoleKey.Escape)
				{
					Console.WriteLine("Игра закрыта");
					break;
				}

				if (key.Key == ConsoleKey.W)
				{
					Load(new Point(game.Player1.Location.x, game.Player1.Location.y - 1));
				}

				if (key.Key == ConsoleKey.S)
				{
					Load(new Point(game.Player1.Location.x, game.Player1.Location.y + 1));
				}

				if (key.Key == ConsoleKey.A)
				{
					Load(new Point(game.Player1.Location.x - 1, game.Player1.Location.y));
				}

				if (key.Key == ConsoleKey.D)
				{
					Load(new Point(game.Player1.Location.x + 1, game.Player1.Location.y));
				}

				if (key.Key == ConsoleKey.R)
				{
					game.Player1.MoveTo(start);
					game.Maze.Create();
					game.Maze[game.Player1.Location.y, game.Player1.Location.x] = game.Player1;
					end = game.Maze.End;
				}

			}
		}

		private void Load(Point nextCoordinate)
		{
			var coordinate = game.Player1.Location;
			var nextElement = game.Maze[nextCoordinate.y, nextCoordinate.x];

			if (nextElement is IRoom)
			{
				game.Maze[nextCoordinate.y, nextCoordinate.x] = game.Player1;
				game.Player1.MoveTo(nextCoordinate);
				game.Maze[coordinate.y, coordinate.x] = game.Factory.CreateRoom();
			}
			else if (nextElement is IWall)
			{
				var wall = nextElement as IWall;
				if (wall.IsBroken() == true)
				{
					game.Maze[nextCoordinate.y, nextCoordinate.x] = game.Factory.CreateRoom();
				}
			}
		}
	}
}
