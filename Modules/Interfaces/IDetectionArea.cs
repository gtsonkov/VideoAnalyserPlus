﻿using System.Drawing;

namespace Modules.Interfaces
{
    public interface IDetectionArea
    {
        int Height { get; set; }
        ILabel Label { get;}
        int PixelSize { get; }
        Size Size { get; set; }
        int Width { get; set; }
        int X { get; set; }
        int Y { get; set; }

        public Rectangle GetRectangle { get; }

        public bool Contains(int x, int y);

        public bool Contains(Point point);
    }
}