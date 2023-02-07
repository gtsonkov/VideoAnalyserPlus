using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Text.RegularExpressions;

namespace VT
{
    public partial class VideoPlayerForm : Form
    {
        private VideoCapture _capture;

        private Mat _frame;

        //To Do: Make it dynamic
        private int _frameRate = 60;
        private const int toolbarWight = 100;
        private string _file = string.Empty;
        private bool _isPaused;

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
            if (this._isPaused)
            {
                this._capture.Start();
                this._isPaused = false;
                return;
            }

            //At this version: if _file ist empty just execute the default video capture device
            //Else execute the video sorce

            if (this._file == string.Empty)
            {
                try
                {
                    this._capture = new VideoCapture(0);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException (ex.Message);
                }
            }
            else
            {
                try
                {
                    this._capture = new VideoCapture(this._file);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException ("Selected videosorce can not be played");
                }
            }

            this._frame = new Mat();

            this.Height = (this._capture.Height) + toolbarWight;
            this.Width = this._capture.Width;

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.Start();
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            this._capture.Pause();
            this._isPaused= true;
        }

        private void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            var lower = new ScalarArray(new MCvScalar(255, 204 , 255));
            var upper = new ScalarArray(new MCvScalar(255, 255, 204));

            var recColor = new MCvScalar(0, 255, 0);

            TrackCurrentColor(lower, upper, rgb, recColor);

            lower = new ScalarArray(new MCvScalar(255, 0, 0));
            upper = new ScalarArray(new MCvScalar(255, 255, 255));

            recColor = new MCvScalar(255, 0, 255);


            TrackCurrentColor(lower, upper, rgb, recColor);

            ShowVideo();

            //_capture.Retrieve(this._frame);

            //CvInvoke.Imshow("Color Tracking", this._frame);
            CvInvoke.WaitKey(this._frameRate);
        }

        private void ShowVideo()
        {
            this.screenBox1.Image = BitmapExtension.ToBitmap(this._frame);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            this._capture.Dispose();
            this._isPaused = false;
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

                if (rect.Height > 1 && rect.Width > 1)
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