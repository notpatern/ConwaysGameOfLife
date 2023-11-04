using ConwaysGameOfLife.Cell;
using ConwaysGameOfLife.Controls;
using ConwaysGameOfLife.World;
using System.Drawing;

namespace ConwaysGameOfLife
{
    public partial class Form1 : Form
    {
        Game game;
        SolidBrush brush;
        MainPanel mainPanel;
        Button play;
        Button restart;
        Button pause;
        Button random;
        Button quit;

        private int size;
        private int scale;

        #region Cell Lists
        // default life rules
        /*List<Coords> alternator = new List<Coords>()
        {
            new Coords(0, 0), new Coords(1, 0), new Coords(0, 1),
            new Coords(1, 1)
        };
        */

        // default life rules
        /*
        List<Coords> glider = new List<Coords>() {
            new Coords(0, 1), new Coords(1, 2), new Coords(2, 2),
            new Coords(2, 1), new Coords(2, 0)
        };
        */

        // default life rules
        private List<Coords> cannon = new List<Coords>() {
            new Coords(1, 5), new Coords(2, 5), new Coords(1, 6), new Coords(2, 6), new Coords(11, 5),
            new Coords(11, 6), new Coords(11, 7), new Coords(12, 4), new Coords(12, 8), new Coords(13, 3),
            new Coords(13, 9), new Coords(14, 3) ,new Coords(14, 9), new Coords(15, 6), new Coords(16, 8),
            new Coords(16, 4), new Coords(17, 5), new Coords(17, 6), new Coords(17, 7), new Coords(18, 6),
            new Coords(21, 5), new Coords(22, 5), new Coords(21, 4), new Coords(22, 4), new Coords(21, 3),
            new Coords(22, 3), new Coords(23, 2), new Coords(23, 6), new Coords(25, 6), new Coords(25, 7),
            new Coords(25, 1), new Coords(25, 2), new Coords(35,4), new Coords(36, 4), new Coords(35, 3),
            new Coords(36, 3)
         };

        // make sure to use the pedestrian life rules
        private List<Coords> pulsar = new List<Coords>()
        {
            new Coords(11, 10), new Coords(11, 11), new Coords(11, 9), new Coords(12, 9), new Coords(13, 9),
            new Coords(12, 11), new Coords(13, 11), new Coords(6, 10), new Coords(5, 9), new Coords(4, 8),
            new Coords(3, 9), new Coords(2, 10), new Coords(3, 11), new Coords(4, 12), new Coords(5, 11)
        };
        #endregion

        public Form1(int size, int scale, Color color, int speed, bool pedestrian)
        {
            this.size = size;
            this.scale = scale;
            game = new Game(size, speed, FourPulsarsSimulation(), pedestrian, scale, this);
            brush = new SolidBrush(Color.White);
            mainPanel = new MainPanel(size, scale, color);
            InitWindow();
            InitButtons();
            play.Click += delegate (object? sender, EventArgs e) { game.gameTimer.Start(); };
            restart.Click += delegate (object? sender, EventArgs e) { game._grid.Restart(); };
            pause.Click += delegate (object? sender, EventArgs e) { game.gameTimer.Stop(); };
            random.Click += delegate (object? sender, EventArgs e) { game._grid.RandomGen(); };
            quit.Click += delegate (object? sender, EventArgs e) { Close(); };
            Paint += Render;
        }

        public void InitWindow()
        {
            Text = "Conway's Game Of Life";
            DoubleBuffered = true;
            Size defaultSize = new Size(scale * size + 100, scale * size);

            if (defaultSize.Height < 230)
                defaultSize.Height = 230;

            Size = defaultSize;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
        }
        public void InitButtons()
        {
            play = new Button();
            play.Text = "Play";
            play.Size = new Size(100, 50);
            play.FlatAppearance.BorderColor = Color.White;
            play.FlatAppearance.CheckedBackColor = Color.White;
            play.BackColor = Color.White;
            play.Location = new Point(size * scale, scale);
            Controls.Add(play);

            pause = new Button();
            pause.Text = "Pause";
            pause.Size = new Size(100, 50);
            pause.FlatAppearance.BorderColor = Color.White;
            pause.FlatAppearance.CheckedBackColor = Color.White;
            pause.Location  = new Point(size * scale, 60);
            Controls.Add(pause);

            restart = new Button();
            restart.Text = "Restart";
            restart.Size = new Size(100, 50);
            restart.FlatAppearance.BorderColor = Color.White;
            restart.FlatAppearance.CheckedBackColor = Color.White;
            restart.Location = new Point(size * scale, 120);
            Controls.Add(restart);

            random = new Button();
            random.Text = "Random";
            random.Size = new Size(100, 50);
            random.FlatAppearance.BorderColor = Color.White;
            random.FlatAppearance.CheckedBackColor = Color.White;
            random.Location = new Point(size * scale, 180);
            Controls.Add(random);

            quit = new Button();
            quit.Text = "Quit";
            quit.Size = new Size(100, 50);
            quit.FlatAppearance.BorderColor = Color.White;
            quit.FlatAppearance.CheckedBackColor= Color.White;
            quit.BackColor = Color.White;
            quit.Location = new Point(size * scale, 240);
            Controls.Add(quit);
        }
        public void Render(object? sender, PaintEventArgs e)
        {
            mainPanel.Render(e.Graphics);
            game._grid.DisplayGrid(e);
        }

        #region Simulations
        private List<Coords> DisplaySimulation()
        {
            Coords[] newDisplay = new Coords[pulsar.Count];

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X + 55, pulsar[i].Y + 40);
            }
            cannon.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X, pulsar[i].Y + 10);
            }
            cannon.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X, pulsar[i].Y + 50);
            }
            cannon.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X, pulsar[i].Y + 39);
            }
            cannon.AddRange(newDisplay);

            return cannon;
        }

        private List<Coords> FourPulsarsSimulation()
        {
            List<Coords> newPulsar = new List<Coords>();
            Coords[] newDisplay = new Coords[pulsar.Count];

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X + 90, pulsar[i].Y + 75);
            }
            newPulsar.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X + 90, pulsar[i].Y + 64);
            }
            newPulsar.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X + 90, pulsar[i].Y + 125);
            }
            newPulsar.AddRange(newDisplay);

            for (int i = 0; i < newDisplay.Length; i++)
            {
                newDisplay[i] = new Coords(pulsar[i].X + 90, pulsar[i].Y + 114);
            }
            newPulsar.AddRange(newDisplay);

            return newPulsar;
        }
        #endregion
    }
}