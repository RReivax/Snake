using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Coord
    {
        Coord(uint xdef, uint ydef)
        {
            x = xdef;
            y = ydef;
        }
        uint x { get; set; }
        uint y { get; set; }
    }
}
