using Modules;
using System.Drawing;

namespace Utilities
{
    public static class VpTool
    {
        public static Color_HLS_Scalled RgbToScaledHls(Color rgb)
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

            Color_HLS_Scalled finalHLS = ScalHSLtoEmguHLS(currenHSL_Color);

            return finalHLS;
        }

        private static Color_HLS_Scalled ScalHSLtoEmguHLS (Color_HSL color)
        {
            var result = new Color_HLS_Scalled();
            int scalar = 255;

            //Scal H => original H / 2
            result.H = (int)Math.Round((color.H /2));

            //Scall L and S => 0 >= L or S <=1 of base 255 (255 = 1; ex. 128 = 0,5);
            result.L = (int)(Math.Round(color.L * scalar));
            result.S = (int)(Math.Round(color.S * scalar));

            return result;
        }

    }
}