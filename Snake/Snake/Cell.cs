using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    enum CellType {HEAD, SNAKE, FRUIT, WALL, EMPTY};
    class Cell : PictureBox
    {
        static Image img_head = Image.FromFile("images/snake_head.png");
        static Image img_snake = Image.FromFile("images/snake.png");
        static Image img_fruit = Image.FromFile("images/fruit.png");
        static Image img_wall = Image.FromFile("images/wall.png");

        public CellType type { private set; get; }
        public Cell(CellType t)
        {
            type = t;
            switch (t)
            {
                case CellType.EMPTY:
                    this.BackColor = Color.Black;
                    this.Height = 20;
                    this.Width = 20;
                        break;
                case CellType.SNAKE:
                    this.Image = img_snake;
                    break;
                case CellType.HEAD:
                    this.Image = img_head;
                    break;
                case CellType.WALL:
                    this.Image = img_wall;
                    break;
                case CellType.FRUIT:
                    this.Image = img_fruit;
                    break;
                default:
                    break;
            }
        }
    }
}
