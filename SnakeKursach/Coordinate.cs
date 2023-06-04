using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeKursach
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate()
        {
            X = 0;
            Y = 0;
        }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
