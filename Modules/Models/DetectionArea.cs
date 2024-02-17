using Modules.Interfaces;
using System.Drawing;

namespace Modules.Models
{
    public class DetectionArea : IDetectionArea
    {
        private Rectangle rectangle;

        public DetectionArea(int x, int y, int width, int height, string label)
        {
            this.rectangle = new Rectangle(x, y, width, height);
            this.Label = label;
        }

        public DetectionArea(string label)
        {
            this.rectangle = new Rectangle();
            this.Label = label;
        }

        public int Width
        {
            get
            {
                return this.rectangle.Width;
            }

            set
            {
                try
                {
                    this.rectangle.Width = value;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public int Height
        {
            get
            {
                return this.rectangle.Height;
            }

            set
            {
                try
                {
                    this.rectangle.Height = value;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public int X
        {
            get
            {
                return this.rectangle.X;
            }

            set
            {
                try
                {
                    this.rectangle.X = value;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public int Y
        {
            get
            {
                return this.rectangle.Y;
            }

            set
            {
                try
                {
                    this.rectangle.Y = value;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public Size Size
        {
            get
            {
                return this.rectangle.Size;
            }

            set
            {
                try
                {
                    this.rectangle.Size = value;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public int PixelSize
        {
            get
            {
                return this.rectangle.X * this.rectangle.Height;
            }
        }

        public string Label { get; set; }
    }
}