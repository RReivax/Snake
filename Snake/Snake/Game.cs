using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    static class Space {
        public const int W = 40;
        public const int H = 30;
        public enum Orientation { NORTH, WEST, SOUTH, EAST };
    }

    class Game : Panel
    {
        public Game()
        {
            Map = new Cell[Space.H, Space.W];
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
