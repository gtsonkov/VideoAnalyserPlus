using Modules.Interfaces;

namespace Modules
{
    public class Resolution : IResolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public int? FrameRate { get; set; }

        public Resolution(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public Resolution(int width, int height, int? frameRate)
        {
            this.Width = width;
            this.Height = height;
            this.FrameRate = frameRate;
        }
    }
}