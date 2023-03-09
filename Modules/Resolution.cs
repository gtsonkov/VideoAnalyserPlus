namespace Modules
{
    public class Resolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Resolution(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
    }
}