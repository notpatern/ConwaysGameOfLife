namespace ConwaysGameOfLife.Controls
{
    internal class MainPanel
    {
        Rectangle rectangle;
        private int size;
        private int scale;
        private SolidBrush brush;

        public MainPanel(int size, int scale, Color color)
        {
            this.rectangle = new Rectangle(0, 0, size * scale, size * scale);
            this.size = size;
            this.scale = scale;
            brush = new SolidBrush(color);
        }

        public void Render(Graphics g)
        {
            g.FillRectangle(brush, rectangle);
        }
    }
}
