using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace VideoAnalyserPlus
{
    public partial class MainForm : Form
    {
        private VideoCapture _capture;

        private Mat _frame;

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

            this.ImageViewer.Image = BitmapExtension.ToBitmap(this._frame);

            this.ImageViewer.Show();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {

        }

        private void TrackColor()
        {
            while (!stopThread)
            {
                _capture.Read(_frame);
                if (_frame.IsEmpty) break;

                Mat hsv = new Mat();
                CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);

                //To Do: Make it dynamic
                var lower = new ScalarArray(new MCvScalar(0, 0, 0));
                var upper = new ScalarArray(new MCvScalar(200, 255, 255));

                Mat mask = new Mat();

                CvInvoke.CvtColor(_frame, hsv, ColorConversion.Bgr2Hsv);
                CvInvoke.InRange(hsv, lower, upper, mask);

                ImageViewer.Image = BitmapExtension.ToBitmap(this._frame);
            }
        }
    }