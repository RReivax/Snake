using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Coord
    {
        public Coord(int xdef, int ydef)
        {
            x = xdef;
            y = ydef;
        }
        public int x { get; set; }
        public int y { get; set; }
        public static Coord operator +(Coord vec1, Coord vec2) {
            return new Snake.Coord(vec1.x + vec2.x, vec1.y + vec2.y);
        }
    }
}
