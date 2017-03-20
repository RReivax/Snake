using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

static class Dim
{
    public const int W = 40;
    public const int H = 30; 
}

namespace Snake 
{
    class Game : Panel
    {
        public Game()
        {
            Map = new Cell[Dim.H, Dim.W];
            currentScore = 0;
            this.Show();
        }

        /**
         * Generates a new fruit and wall
         * */
        public void fruitEaten()
        {
            
        }

        private int currentScore;
        private LinkedList<Coord> Snake;
        private Cell[,] Map;
    }
}
