using Modules;
using System.Drawing;

namespace Utilities
{
    public static class VpTool
    {
        public static Color_HSL RgbToHsl(Color rgb)
        {
            Color_HSL currenHSL_Color = new Color_HSL();
            currenHSL_Color.BaseColor_RGB = rgb;

            double currR = rgb.R / 255.0;
            double currG = rgb.G / 255.0;
            double currB = rgb.B / 255.0;

            double cmax = Math.Max(currR, Math.Max(currG, currB));
            double cmin = Math.Min(currR, Math.Min(currG, currB));
            double delta = cmax - cmin;

            // Calculate H
            if (delta == 0)
            {
                currenHSL_Color.H = 0;
            }
            else if (cmax == currR)
            {
                currenHSL_Color.H = ((currG - currB) / delta) % 6;
            }
            else if (cmax == currG)
            {
                currenHSL_Color.H = (currB - currR) / delta + 2;
            }
            else
            {
                currenHSL_Color.H = (currR - currG) / delta + 4;
            }

            currenHSL_Color.H *= 60;

            if (currenHSL_Color.H < 0)
            {
                currenHSL_Color.H += 360;
            }

            // Calculate L
            currenHSL_Color.L = ((cmax + cmin) / 2);

            // Calculate S
            if (delta == 0)
            {
                currenHSL_Color.S = 0;
            }
            else
            {
                currenHSL_Color.S = delta / (1 - Math.Abs(2 * currenHSL_Color.L - 1));
            }

            return currenHSL_Color;
        }
    }
}