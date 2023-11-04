using System.Resources;

namespace ConwaysGameOfLife.Cell;

public class Cell
{
    private bool _isAlive;
    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    private bool _nextState;

    public bool NextState
    {
        get => _nextState;
        set => _nextState = value;
    }

    public Cell(bool state)
    {
        this.IsAlive = state;
        this.NextState = state;
    }

    public void ComeAlive()
    {
        NextState = true;
    }

    public void PassAway()
    {
        NextState = false;
    }

    public void Update()
    {
        IsAlive = NextState;
    }
}