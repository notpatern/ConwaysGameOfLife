namespace ConwaysGameOfLife.Cell;

public struct Coords
{
    private int _x;
    private int _y;
    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }
    
    public Coords(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return "";
    }
}