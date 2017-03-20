using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Coord
    {
        public Coord(int ydef, int xdef)
        {
            x = xdef;
            y = ydef;
        }
        public int x { get; set; }
        public int y { get; set; }
        public static Coord operator +(Coord vec1, Coord vec2) {
            return new Coord((vec1.y + vec2.y)%(Space.H-1), (vec1.x + vec2.x)%(Space.W-1));
        }
    }
}
