using System.Drawing;

namespace Modules
{
    public class FilterMaskRGB
    {
        private Resolution minPixelSize;

        private const int minPixelSizeW = 1;
        private const int minPixelSizeH = 1;

        private int radius;

        public FilterMaskRGB()
        {
            this.MinPixelSize = new Resolution(minPixelSizeW,minPixelSizeH);
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
        public Resolution MinPixelSize
        {
            get
            {
                return this.minPixelSize;
            }
            set
            {
                if (value != null)
                {
                    if (value.Width > 0 && value.Height > 0)
                    {
                        this.minPixelSize = value;
                    }
                }
                else
                {
                    throw new InvalidOperationException("Resolution Width and Height must be bigger than 0");
                }
            }
        }
    }
}