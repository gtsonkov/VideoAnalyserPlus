using System.Drawing;

namespace Modules.Interfaces
{
    public interface IDetectionArea
    {
        int Height { get; set; }
        string Label { get; set; }
        int PixelSize { get; }
        Size Size { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }
    }
}