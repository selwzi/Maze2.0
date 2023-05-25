using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0.ElementsMaze
{
    class WeakWall : IWall
    {
        readonly char _view = '\u2593';
        public int Hardness { get; set; }

        public bool IsBroken()
        {
            Hardness--;
            return (Hardness == 0) ? true : false;
        }

        public WeakWall(int strength)
        {
            Hardness = strength;
        }

        public IWall Clone() => new WeakWall(Hardness);
        public char Display() => _view;

    }
}
