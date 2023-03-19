using System.Drawing;

namespace Modules
{
    public class FilterMaskRGB
    {
        private const int defaultMinObjectSize = 1;

        private int minObjectSize;

        private int radius;

        public FilterMaskRGB()
        {
            this.MinObjectSize = defaultMinObjectSize;
            this.radius = 0;
        }

        public Color BaseColor { get; set; }

        /// <summary>
        /// Radius of colors. Can not be negative
        /// </summary>
        public int Radius 
        {
            get 
            {
                return this.radius;
            }
            
            set
            {
                if (value >= 0) 
                {
                    this.radius = value;
                }
            }
        }

        public int Red_Min { get; set; }

        public int Green_Min { get; set; }

        public int Blue_Min { get; set; }

        public int Red_Max { get; set; }

        public int Green_Max { get; set; }

        public int Blue_Max { get; set; }

        /// <summary>
        /// Minimum pixel size (pixel x pixel). Always > 0
        /// </summary>
        public int MinObjectSize
        {
            get
            {
                return this.minObjectSize;
            }
            set
            {
                this.minObjectSize = value;
            }
        }
    }
}