using Maze2._0.ElementsMaze;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Maze2._0
{
    class Maze : IMaze
    {
		int _width, _height;
		IElementMaze[,] _structMaze;

		public int Height
        {
            get { return _height; }
            set 
            {
                if (value % 2 == 0) throw new ArgumentException();
                _height = value;
            } 
        }
        public int Width 
        {
            get { return _width; }
            set 
            {
                if (value % 2 == 0) throw new ArgumentException();
                _width = value;
            } 
        }
        
		public HardWall HardWall { get; set; }
		public WeakWall WeakWall { get; set; }
		public Room Room1 { get; set; }
		public EndRoom EndRoom { get; set; }
		public Point Start { get; set; }
		public Point End { get; set; }

		public void Create()
        {
			var generator = new MazeGenerator(this);
            _structMaze = generator.Generate();
			_structMaze[End.y, End.x] = EndRoom;
		}

		public IElementMaze this[int i, int j]
        {
            get => _structMaze[i, j];
            set => _structMaze[i, j] = value;
        }

		public string Print()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    result.Append(_structMaze[i, j].Display());
                result.Append('\n');
            }
            return result.ToString();
        }

	}
}
