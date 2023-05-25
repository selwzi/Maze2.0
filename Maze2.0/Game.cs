using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0
{
	class Game
	{
		static Game singleGame;
		public Player Player1 { get; set; }
		public Maze Maze { get; set; }
		public IElementMazeFactory Factory { get; set; }
		private Game(Maze _maze, Player _player, IElementMazeFactory _factory)
		{
			Maze = _maze;
			Player1 = _player;
			Factory = _factory;
		}

		public static Game GetGame()
		{
			if (singleGame == null)
			{
				var factory = new ElementMazeFactory();
				var maze = new MazeBuilder()
					.SetSize(13, 15)
					.SetElementMaze()
					.SetStartPosition(new Point(1, 1))
					.Build();

				var player0 = new Player((char)2);
				singleGame = new Game(maze, player0, factory);
			}
			return singleGame;
		}
	}
}
