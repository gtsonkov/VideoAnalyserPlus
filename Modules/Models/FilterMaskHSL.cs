using System.Drawing;

namespace Modules.Models
{
    public class FilterMaskHSL
    {
        private const int defaultMinObjectSize = 1;

        private int minObjectSize;

        private int radius;

        public FilterMaskHSL()
        {
            MinObjectSize = defaultMinObjectSize;
            radius = 0;
        }

        public Color BaseColor { get; set; }

        /// <summary>
        /// Radius of colors. Can not be negative
        /// </summary>
        public int Radius
        {
            get
            {
                return radius;
            }

            set
            {
                if (value >= 0)
                {
                    radius = value;
                }
            }
        }

        public int H_Min { get; set; }

        public int S_Min { get; set; }

        public int L_Min { get; set; }

        public int H_Max { get; set; }

        public int S_Max { get; set; }

        public int L_Max { get; set; }

        /// <summary>
        /// Minimum Object Size size (pixel x pixel). Always > 0
        /// </summary>
        public int MinObjectSize
        {
            get
            {
                return minObjectSize;
            }
            set
            {
                minObjectSize = value;
            }
        }
    }
}