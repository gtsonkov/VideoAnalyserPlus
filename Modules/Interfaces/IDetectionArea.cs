using System.Drawing;

namespace Modules.Interfaces
{
    public interface IDetectionArea
    {
        public int Height { get; set; }
        public ILabel Label { get;}
        public int PixelSize { get; }
        public Size Size { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle GetRectangle { get; }

        public bool Contains(int x, int y);

        public bool Contains(Point point);
    }
}