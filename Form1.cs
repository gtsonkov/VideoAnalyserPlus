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

            this._capture = new VideoCapture(file);

            this._frame = new Mat();

            this.screenBox.Image = BitmapExtension.ToBitmap(this._frame);

            this.screenBox.Show();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            stopThread = false;
            trackingThread = new Thread(TrackColor);
            trackingThread.Start();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {

        }

        private void TrackColor()
        {
            while (!stopThread)
            {
                this._capture.Read(_frame);

                if (this._frame.IsEmpty)
                {
                    break;
                }

                //To Do: Use RGB
                Mat hsv = new Mat();
                CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);

                //To Do: Make it dynamic 
                var lower = new ScalarArray(new MCvScalar(0, 0, 0));
                var upper = new ScalarArray(new MCvScalar(200, 255, 255));

                Mat mask = new Mat();

                CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);
                CvInvoke.InRange(hsv, lower, upper, mask);

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hierarchy = new Mat();
                CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

                for (int i = 0; i < contours.Size; i++)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                    //To Do: Make minimum size (rect.Height & rect.Width) dynamic
                    if (rect.Height > 5 && rect.Width > 5)
                    {
                        CvInvoke.Rectangle(_frame, rect, new MCvScalar(0, 255, 0), 2);
                    }
                }

                //ImageViewer.Image = BitmapExtension.ToBitmap(this._frame);

                CvInvoke.Imshow("VT-Color Tracker", this._frame);
                this.screenBox.Image = BitmapExtension.ToBitmap(this._frame);
            }
        }
    }
}