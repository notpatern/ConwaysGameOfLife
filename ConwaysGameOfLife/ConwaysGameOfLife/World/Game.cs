namespace ConwaysGameOfLife.World;
using Cell;
using System;
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

    public void RandomGenInit()
    {
        _grid.RandomGen();
        gameTimer.Stop();

        form.Invalidate();
    }

    public void RestartInit()
    {
        _grid.Restart();
        gameTimer.Stop();

        form.Invalidate();
    }

    public void Run(object? sender, EventArgs e)
    {
        _grid.UpdateGrid();

        form.Invalidate();
    }
}