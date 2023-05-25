using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze2._0.ElementsMaze
{
    class Room : IRoom
    {
        protected char _view = ' ';

        protected Room()
        {
        }

        public static Room GetRoom() => new Room();
        public char Display() => _view;
    }
}
