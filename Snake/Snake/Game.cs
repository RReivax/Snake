using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Snake 
{
    static class Space
    {
        public const int W = 40;
        public const int H = 30;
        public static Coord VecNorth = new Coord(-1, 0);
        public static Coord VecSouth = new Coord(1, 0);
        public static Coord VecWest = new Coord(0, -1);
        public static Coord VecEast = new Coord(0, 1);
        public static Coord[] Vec = { VecNorth, VecWest, VecSouth, VecEast };
        public enum Orientation { NORTH, WEST, SOUTH, EAST}
    }

    class Game 
    {
        public Game(int lvl = 1)
        {
            level = lvl;
            Map = new Cell[Space.H, Space.W];
            currentScore = 0;
            toGrow = 0;
        }

        /**
         * Inits random snake position and fruit
         **/         
        public void initGame()
        {
            currentScore = 0;
            Random rand = new Random();
            // Creates empty map
            for (int i = 0; i < Space.W; i++) for (int j = 0; j < Space.H; j++) Map[j, i] = new Cell(CellType.EMPTY);
            // Generates snake (head + 2 body)
            Snake.AddFirst(new Coord(5 + rand.Next(Space.H - 5), 5 + rand.Next(Space.W - 5)));
            currentOrientation = (Space.Orientation)rand.Next(4);
            Snake.AddLast(Snake.First.Value + Space.Vec[(int)currentOrientation]);
            Snake.AddLast(Snake.Last.Value + Space.Vec[(int)currentOrientation]);
            foreach(Coord c in Snake){
                Map[c.y , c.x] = new Cell(CellType.SNAKE);
            }
            Map[Snake.First.Value.x, Snake.First.Value.y] = new Cell(CellType.HEAD);
            // Adds a fruit on the map
            bool fruitOk = false;
            do
            {
                int y = rand.Next(Space.H);
                int x = rand.Next(Space.W);
                if(Map[y,x].type != CellType.SNAKE && Map[y,x].type != CellType.HEAD)
                {
                    Map[y, x] = new Cell(CellType.FRUIT);
                    fruitOk = true;
                }
                
            } while (fruitOk);
        }

        /**
         * To be called 
         **/
        public bool update(Space.Orientation dir)
        {
            Coord next = Snake.First.Value + Space.Vec[(int)dir];
            switch (Map[next.y, next.x].type)
            {
                case CellType.FRUIT:
                    fruitEaten();
                    move(dir);
                    break;
                case CellType.EMPTY:
                    move(dir);
                    break;
                case CellType.SNAKE:
                case CellType.WALL:
                    return false;
            }
            return true;
        }

        /**
         * Moves snakes in direction and handle snake growing 
         **/
        private void move(Space.Orientation dir)
        {
            Coord currentHead = Snake.First.Value;
            Map[currentHead.x, currentHead.y] = new Cell(CellType.SNAKE);
            Snake.AddFirst(currentHead + Space.Vec[(int)dir]);
            Map[Snake.First.Value.x, Snake.First.Value.y] = new Cell(CellType.HEAD);
            if (toGrow == 0)
            {
                Map[Snake.Last.Value.x, Snake.Last.Value.y] = new Cell(CellType.EMPTY);
                Snake.RemoveLast();
            }
            else
            {
                toGrow--;
                currentScore += 1;
            }
        }

        /**
         * Generates a new fruit and wall
         **/
        public void fruitEaten()
        {
            toGrow += level;
        }

        private int level;
        private int toGrow;
        private int currentScore;
        private LinkedList<Coord> Snake;
        public Space.Orientation currentOrientation { get; private set; }
        public Cell[,] Map { get; private set; }
    }
}
