namespace ConwaysGameOfLife.World;
using Cell;

public class Grid
{
    private Random random;
    private int _n;
    private bool _pedestrian;
    private int _scale;
    private SolidBrush _brush;
    private List<Coords> _coords;
    public int N
    {
        get => _n;
        set => _n = value;
    }

    private Cell[,] _tabCells;

    public Grid(int nbCells, List<Coords> aliveCellsCoords, bool pedestrian, int scale)
    {
        this.N = nbCells;
        this._scale = scale;
        this._brush = new SolidBrush(Color.White);
        this._pedestrian = pedestrian;
        this._coords = aliveCellsCoords;
        _tabCells = new Cell[N, N];

        for (int y = 0; y < N; y++)
        {
            for (int x = 0; x < N; x++)
            {
                _tabCells[y, x] = new Cell(false);
                _tabCells[y, x].IsAlive = aliveCellsCoords.Contains(new Coords(x, y));
            }
        }
    }

    public void RandomGen()
    {
        for (int y = 0; y < N; y++)
        {
            for (int x = 0; x < N; x++)
            {
                random = new Random();
                int prob = random.Next(100);
                _tabCells[y, x] = new Cell(false);
                if (prob <= 15)
                    _tabCells[y, x].IsAlive = true;
            }
        }
    }

    public void Restart()
    {
        _tabCells = new Cell[N, N];

        for (int y = 0; y < N; y++)
        {
            for (int x = 0; x < N; x++)
            {
                _tabCells[y, x] = new Cell(false);
                _tabCells[y, x].IsAlive = _coords.Contains(new Coords(x, y));
            }
        }
    }

    public int GetNbAliveNeighbor(int i, int j)
    {
        var amountOfLiveCells = 0;

        for (var y = -1; y < 2; y++)
        {
            for (var x = -1; x < 2; x++)
            {
                if (!(x + i >= N || x + i < 0 || y + j >= N || y + j < 0) && !(j == y + j && i == x + i))
                {
                    if (_tabCells[x + i, y + j].IsAlive)
                    {
                        amountOfLiveCells++;
                    }
                }
            }
        }

        return amountOfLiveCells;
    }
    
    public void DisplayGrid(PaintEventArgs g)
    {
        for (var y = 0; y < N; y++)
        {
            for (int x = 0; x < N; x++)
            {
                if (_tabCells[y, x].IsAlive)
                {
                    Rectangle rectangle = new Rectangle(x * _scale, y * _scale, _scale, _scale);
                    g.Graphics.FillRectangle(_brush, rectangle);
                }
            }
        }
    }
    
    public void UpdateGrid()
    {
        for (var y = 0; y < N; y++)
        {
            for (var x = 0; x < N; x++)
            {
                switch (_tabCells[y, x].IsAlive)
                {
                    case true when (GetNbAliveNeighbor(y,x) == 3 || GetNbAliveNeighbor(y,x) == 2):
                        _tabCells[y, x].ComeAlive();
                        break;
                    case true when (GetNbAliveNeighbor(y,x) != 3 && GetNbAliveNeighbor(y,x) != 2):
                        _tabCells[y, x].PassAway();
                        break;
                    case false when !_pedestrian ? GetNbAliveNeighbor(y,x) == 3 : GetNbAliveNeighbor(y,x) == 3 || GetNbAliveNeighbor(y,x) == 8:
                        _tabCells[y, x].ComeAlive();
                        break;
                }
            }
        }
        
        for (var y = 0; y < N; y++)
        {
            for (var x = 0; x < N; x++)
            {
                _tabCells[y,x].Update();
            }
        }
    }
}