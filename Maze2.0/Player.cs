using Maze2._0.ElementsMaze;

namespace Maze2._0
{
    class Player:IElementMaze
    {
        readonly char View;

        public Player(char symbol)
        {
            View = symbol;
        }

        public Point Location { get; private set; }

        public char Display() => View;

        public void MoveTo(Point position)
        {
            Location =  new Point(position.x, position.y);
        }
    }
}
