using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0.ElementsMaze
{
    class EndRoom : Room
    {
        public EndRoom() : base()
        {
            _view = (char)127;
        }
    }
}
