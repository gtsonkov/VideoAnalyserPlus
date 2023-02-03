using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace VideoAnalyserPlus
{
    public partial class MainForm : Form
    {
        private VideoCapture _capture;

        private Mat _frame;

        private Thread _trackingThread;

        private bool stopThread;

        //To Do: Make it dynamic
        private int _frameRate = 30;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string file = string.Empty;

            DialogResult result = openFileDialog1.ShowDialog(Owner); // Show Explorer browser dialog.

            if (result == DialogResult.OK) // Get result after click OK
            {
                file = openFileDialog1.FileName;
            }

            try
            {
                this._capture = new VideoCapture(file);

                this._frame = new Mat();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //this.stopThread = false;
            //this._trackingThread = new Thread(TrackColor);
            //this._trackingThread.Start();

            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.ImageGrabbed -= ProcessFrameEventHandler;

            this._capture.Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            this.stopThread = true;
            //this._trackingThread.Abort();
        }

        //private void TrackColor()
        //{
        //    while (!this.stopThread)
        //    {
        //        this._capture.Read(_frame);
        //
        //        if (this._frame.IsEmpty)
        //        {
        //            break;
        //        }
        //        
        //        //To Do: Use RGB
        //        Mat hsv = new Mat();
        //        CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);
        //
        //        //To Do: Implement new Method to avoid copy code (at the moment just for test)
        //        #region First Color
        //
        //        //To Do: Make it dynamic 
        //        var lower = new ScalarArray(new MCvScalar(0, 0, 0));
        //        var upper = new ScalarArray(new MCvScalar(200, 255, 255));
        //
        //        Mat mask = new Mat();
        //
        //        CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);
        //        CvInvoke.InRange(hsv, lower, upper, mask);
        //
        //        VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
        //        Mat hierarchy = new Mat();
        //        CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
        //
        //        for (int i = 0; i < contours.Size; i++)
        //        {
        //            Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
        //
        //            //To Do: Make minimum size (rect.Height & rect.Width) dynamic
        //            if (rect.Height > 5 && rect.Width > 5)
        //            {
        //                CvInvoke.Rectangle(_frame, rect, new MCvScalar(0, 255, 0), 2);
        //            }
        //        }
        //        #endregion
        //
        //        #region Second Color
        //
        //        //To Do: Make it dynamic 
        //        lower = new ScalarArray(new MCvScalar(20, 25, 10));
        //        upper = new ScalarArray(new MCvScalar(100, 150, 105));
        //
        //        CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);
        //        CvInvoke.InRange(hsv, lower, upper, mask);
        //
        //        VectorOfVectorOfPoint contours2 = new VectorOfVectorOfPoint();
        //        Mat hierarchy2 = new Mat();
        //        CvInvoke.FindContours(mask, contours2, hierarchy2, RetrType.External, ChainApproxMethod.ChainApproxSimple);
        //
        //        for (int i = 0; i < contours2.Size; i++)
        //        {
        //            Rectangle rect = CvInvoke.BoundingRectangle(contours2[i]);
        //
        //            //To Do: Make rectangle color dynamic
        //            CvInvoke.Rectangle(_frame, rect, new MCvScalar(255, 255, 255), 2);
        //        }
        //        #endregion
        //
        //        //screenBox.Image = BitmapExtension.ToBitmap(this._frame);
        //
        //        CvInvoke.Imshow("VT-Color Tracker", this._frame);
        //        CvInvoke.WaitKey(this._frameRate);
        //    }
        //}

        private void TrackColor()
        {
            while (!stopThread)
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

        private void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            screenBox.Image = BitmapExtension.ToBitmap(this._frame);

            var lower = new ScalarArray(new MCvScalar(35, 50, 50));
            var upper = new ScalarArray(new MCvScalar(75, 255, 255));

            var recColor = new MCvScalar(0, 255, 0);

            TrackCurrentColor(lower, upper, rgb, recColor);

            lower = new ScalarArray(new MCvScalar(250, 25, 100));
            upper = new ScalarArray(new MCvScalar(255, 85, 200));

            recColor = new MCvScalar(255, 0, 0);

            TrackCurrentColor(lower, upper, rgb, recColor);

            _capture.Retrieve(this._frame);

            //screenBox.Image = BitmapExtension.ToBitmap(this._frame);

            CvInvoke.Imshow("Color Tracking", this._frame);
            CvInvoke.WaitKey(this._frameRate);
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

        private void screenBox_Click(object sender, EventArgs e)
        {
            //To Do: What happen when mouse over
        }

        private void userCameraBtn_Click(object sender, EventArgs e)
        {
            int defaultCaptureDevice = 0;

            try
            {
                //To Do: make device selection dynamic
                this._capture = new VideoCapture(defaultCaptureDevice);
                this._frame = new Mat();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
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