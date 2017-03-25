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
            int Y, X;
            if ((vec1.y + vec2.y) < 0) 
                Y = Space.H - 1;
            else 
                Y = (vec1.y + vec2.y) % (Space.H - 1);

            if ((vec1.x + vec2.x) < 0)
                X = Space.W - 1;
            else
                X = (vec1.x + vec2.x) % (Space.W - 1);

            return new Snake.Coord(Y, X);
        }
    }
}
