using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0.ElementsMaze
{
    class HardWall : IWall
    {
        readonly char _view = '\u2588';
        public IWall Clone() => new HardWall();
        public char Display() => _view;
        public bool IsBroken() => false;
    }
}
