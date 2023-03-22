using System.Drawing;

namespace Utilities
{
    public static class ConstantData
    {
        public static readonly Color DefaultColor_A = Color.FromArgb(0, 255, 0);

        public static readonly Color DefaultColor_B = Color.FromArgb(255, 0, 255);

        public static readonly int DefaultBorderRectangles = 3;

        public const string Message_RectangleBorderWigth_ZeroOrNegative = "Die Rechteckrahmen breite muss > 0 sein. "
                                                                            + "Wohlen Sie die standard Rahmen diche setzen?";
        
        public const string Message_Tittle_Warning = "Warnung";
    }
}