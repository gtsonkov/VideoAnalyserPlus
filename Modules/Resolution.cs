namespace Modules
{
    public class Resolution
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public Resolution(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override int GetHashCode()
        {
            return (Width << 16) ^ Height;
        }
    }
}