using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Modules.Interfaces;
using System.Drawing;

namespace Modules
{
    public class FilterPlayer : IPlayable
    {
        private VideoCapture _capture;
        private IStreamable _streamFrame;
        private CaptureDevice currCaptureDevice;
        private Mat _frame;

        private FilterMask color1;
        private FilterMask color2;

        private bool trackColor1;
        private bool trackColor2;

        private bool _isPaused;

        public FilterPlayer(CaptureDevice currCaptureDevice, IStreamable stream)
        {
            if (currCaptureDevice == null)
            {
                throw new ArgumentNullException("Capture device can not be null.");
            }

            this.currCaptureDevice = currCaptureDevice;
            this._streamFrame = stream;

            this._capture = currCaptureDevice.VideoSorce;
        }

        public void Pause()
        {
            this._capture.Pause();
            this._isPaused = true;
        }

        public IStreamable SetStream
        {
            set
            {
                this._streamFrame = value;
            }
        }

        //Return resolution from curren capture
        public Resolution Resolution
        {
            get
            {
                return this.currCaptureDevice.Resolution;
            }
        }

        public bool EnableTrackColor_A
        {
            get
            {
                return this.trackColor1;
            }
            set
            {
                this.trackColor1 = value;
            }
        }

        public bool EnableTrackColor_B
        {
            get
            {
                return this.trackColor2;
            }
            set
            {
                this.trackColor2 = value;
            }
        }

        //Strat playing
        public async void Play()
        {
            if (this._isPaused)
            {
                this._capture.Start();
                this._isPaused = false;
                return;
            }

            if (this.currCaptureDevice == null)
            {
                throw new ArgumentNullException("Bitte eine Quelle festliegen (Kamera oder Videodatei.)", "Warnung");
            }
            else
            {
                try
                {
                    this._capture = this.currCaptureDevice.VideoSorce;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            this._frame = new Mat();

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.Start();
        }

        public FilterMask FilterColor_A
        {
            get
            {
                return this.color1;
            }
            set
            {
                this.color1 = value;
            }
        }

        public FilterMask FilterColor_B
        {
            get
            {
                return this.color2;
            }
            set
            {
                this.color2 = value;
            }
        }


        public void Stop()
        {
            StopPlaying();
            this._isPaused = false;
        }

        public async void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            List<Rectangle> color1Objects = new List<Rectangle>();

            if (this.trackColor1 && this.color1 != null)
            {
                var lower = new ScalarArray(new MCvScalar(color1.Blue_Min, color1.Green_Min, color1.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color1.Blue_Max, color1.Green_Max, color1.Red_Max, 255));

                color1Objects = TrackCurrentColor(lower, upper, rgb, this.color1.MinPixelSize.Width, this.color1.MinPixelSize.Height);
            }

            List<Rectangle> color2Objects = new List<Rectangle>();

            if (this.trackColor2 && this.color2 != null)
            {
                var lower = new ScalarArray(new MCvScalar(color2.Blue_Min, color2.Green_Min, color2.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color2.Blue_Max, color2.Green_Max, color2.Red_Max, 255));

               color2Objects = TrackCurrentColor(lower, upper, rgb, this.color2.MinPixelSize.Width, this.color2.MinPixelSize.Height);
            }

            List<Rectangle>[] objectsFoundet = new List<Rectangle>[] {color1Objects, color2Objects};

            this._streamFrame.DisplayFrame(BitmapExtension.ToBitmap(this._frame), objectsFoundet);
        }

        public void Dispose()
        {
            this.Stop();
            this.currCaptureDevice = null;
            this._capture.Dispose();

            if (this._frame != null)
            {
                this._frame.Dispose();
                this._frame = null;
            }
        }

        private List<Rectangle> TrackCurrentColor(IInputArray lower, IInputArray upper, Mat rgb, int pixelSizeW, int pixelSizeH)
        {
            Mat mask = new Mat();

            CvInvoke.InRange(rgb, lower, upper, mask);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            List<Rectangle> rectangles = new List<Rectangle>();

            for (int i = 0; i < contours.Size; i++)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Width >= pixelSizeW && rect.Height >= pixelSizeH)
                {
                    rectangles.Add(rect);
                }
            }

            //The list of rectangles schoud be sorted to assure that when Click to appier firs the mallest deteckted area
            //if there are some nested areas
            var orderedListOfRectangles = rectangles.OrderBy(x=> x.Width * x.Height).ToList();

           return orderedListOfRectangles;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopPlaying();
        }

        private void StopPlaying()
        {
            if (this._capture != null)
            {
                this._capture.Dispose();
            }

            this._isPaused = false;
        }
    }
} 