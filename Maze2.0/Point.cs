using System.Diagnostics.CodeAnalysis;

namespace Maze2._0
{
	public struct Point
	{
		public int x { get; set; }
		public int y { get; set; }
		public Point(int _x, int _y)
		{
			x = _x;
			y = _y;
		}

		public bool Equals([NotNullWhen(true)] Point p)
		{
			return this.x.Equals(p.x) && this.y.Equals(p.y) ? true : false;
		}
	}
}
