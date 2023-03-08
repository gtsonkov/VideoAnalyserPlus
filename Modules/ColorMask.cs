using System.Drawing;

namespace Modules
{
    public class ColorMask
    {
        public Color BaseColor { get; set; }

        public int Radius { get; set; }

        public int Red_Min { get; set; }

        public int Green_Min { get; set; }

        public int Blue_Min { get; set; }

        public int Red_Max { get; set; }

        public int Green_Max { get; set; }

        public int Blue_Max { get; set; }
    }
}