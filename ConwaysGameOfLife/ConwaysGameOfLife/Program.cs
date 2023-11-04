using ConwaysGameOfLife.World;
using ConwaysGameOfLife.Cell;

namespace ConwaysGameOfLife
{
    public abstract class GameOfLife
    {       
        static void Main(string[] args)
        {
            Application.Run(new Form1(200, 5, Color.Black, 1, true));
        }
    }
}