using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace VT
{
    public partial class VideoPlayerForm : Form
    {
        private VideoCapture _capture;

        private Mat _frame;

        //To Do: Make it dynamic
        private int _frameRate = 30;

        private string _file = string.Empty;
        private bool _stopThread;

        public VideoPlayerForm()
        {
            InitializeComponent();
        }

        public VideoPlayerForm(object obj)
        {
            InitializeComponent();
            this._file = (string)obj.ToString();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            this._capture = new VideoCapture(this._file);

            this._frame = new Mat();

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;

            this._capture.Start();
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {

        }

        private void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            var lower = new ScalarArray(new MCvScalar(35, 50, 50));
            var upper = new ScalarArray(new MCvScalar(75, 255, 255));

            var recColor = new MCvScalar(0, 255, 0);

            TrackCurrentColor(lower, upper, rgb, recColor);

            lower = new ScalarArray(new MCvScalar(100, 50, 50));
            upper = new ScalarArray(new MCvScalar(135, 255, 255));

            recColor = new MCvScalar(255, 0, 255);

            TrackCurrentColor(lower, upper, rgb, recColor);

            //_capture.Retrieve(this._frame);

            //screenBox.Image = BitmapExtension.ToBitmap(this._frame);

            CvInvoke.Imshow("Color Tracking", this._frame);
            CvInvoke.WaitKey(this._frameRate);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.Stop();
            this._stopThread = true;
            //this._trackingThread.Abort();
        }

        private void TrackColor()
        {
            while (!_stopThread)
            {
                this._capture.Read(this._frame);

                if (_frame.IsEmpty)
                {
                    break;
                }

                Mat rgb = this._frame.Clone();

                var lower = new ScalarArray(new MCvScalar(35, 50, 50));
                var upper = new ScalarArray(new MCvScalar(75, 255, 255));

                var recColor = new MCvScalar(0, 255, 0);

                TrackCurrentColor(lower, upper, rgb, recColor);

                lower = new ScalarArray(new MCvScalar(250, 25, 100));
                upper = new ScalarArray(new MCvScalar(255, 85, 200));

                recColor = new MCvScalar(255, 0, 0);

                TrackCurrentColor(lower, upper, rgb, recColor);

                //screenBox.Image = BitmapExtension.ToBitmap(this._frame);

                CvInvoke.Imshow("Color Tracking", this._frame);
                CvInvoke.WaitKey(this._frameRate);
            }
        }

        private void TrackCurrentColor(IInputArray lower, IInputArray upper, Mat rgb, MCvScalar colorRec)
        {
            Mat mask = new Mat();

            CvInvoke.InRange(rgb, lower, upper, mask);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Height > 10 && rect.Width > 10)
                {
                    CvInvoke.Rectangle(_frame, rect, colorRec, 2);
                }
            }
        }

        private void VideoPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._capture != null)
            {
                this._capture.Dispose();
            }

            if (this._frame != null)
            {
                this._frame.Dispose();
            }
        }
    }
}