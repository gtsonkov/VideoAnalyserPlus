using Modules.Interfaces;

namespace Modules.Models
{
    public class Resolution : IResolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int? FrameRate { get; set; }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Resolution(int width, int height, int? frameRate)
        {
            Width = width;
            Height = height;
            FrameRate = frameRate;
        }
    }
}