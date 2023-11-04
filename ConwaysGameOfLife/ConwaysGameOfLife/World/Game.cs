namespace ConwaysGameOfLife.World;
using Cell;
using System.Windows.Forms;

public class Game
{
    private readonly int _sleepTime;
    public readonly Grid _grid;
    Form1 form;
    public Timer gameTimer;

    public Game(int nbCells, int sleepTime, List<Coords> coords, bool pedestrian, int scale, Form1 form)
    {
        this._sleepTime = sleepTime;
        this._grid = new Grid(nbCells, coords, pedestrian, scale);
        this.form = form;
        InitTimer();
    }

    void InitTimer()
    {
        gameTimer = new Timer();
        gameTimer.Interval = (_sleepTime);
        gameTimer.Tick += new EventHandler(Run);
    }

    public void Run(object? sender, EventArgs e)
    {
        _grid.UpdateGrid();

        form.Invalidate();
    }
}