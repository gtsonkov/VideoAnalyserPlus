using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Modules;

namespace VT
{
    public partial class MainForm : Form
    {
        private VideoCapture _capture;

        internal int deviceIndex = -1;
        internal string _file = string.Empty;

        private Mat _frame;

        //To Do: Make it dynamic
        private int _frameRate = 60;
        private const int toolbarWight = 100;
        private bool _isPaused;
        private int defaultWide = 812;
        private int defaultHeight = 575;

        internal ColorMask color1;
        internal ColorMask color2;

        internal bool trackColor1;
        internal bool trackColor2;

        public MainForm()
        {
            InitializeComponent();
            this.color1 = new ColorMask();
            this.color2 = new ColorMask();
        }

        public MainForm(object obj)
        {
            InitializeComponent();
            this._file = obj.ToString() as string;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            if (this._isPaused)
            {
                this._capture.Start();
                this._isPaused = false;
                return;
            }

            if (this._file == string.Empty && this.deviceIndex == -1)
            {
                MessageBox.Show("Bitte eine Quelle festliegen (Kamera oder Videodatei.)");
                return;
            }
            else
            {
                if (this.deviceIndex != -1)
                {
                    this._capture = new VideoCapture(deviceIndex);

                    try
                    {
                        if (this._capture.Height == 0 || this._capture.Width == 0)
                        {
                            throw new ArgumentException("Keine Aufnahmegerät gefunden.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warnung");
                        return;
                    }

                    this._capture.Set(CapProp.FrameWidth, 1920);
                    this._capture.Set(CapProp.FrameWidth, 1080);
                }
                else
                {
                    try
                    {
                        this._capture = new VideoCapture(this._file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warnung");
                        return;
                    }
                }
            }

            this._frame = new Mat();

            this.Height = (this._capture.Height) + toolbarWight;
            this.Width = this._capture.Width;

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.Start();
        }

        internal void SorceChange()
        {
            this.StopPlaying();
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            this._capture.Pause();
            this._isPaused = true;
        }

        private void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            if (this.trackColor1)
            {
                var lower = new ScalarArray(new MCvScalar(color1.Blue_Min, color1.Green_Min, color1.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color1.Blue_Max, color1.Green_Max, color1.Red_Max, 255));

                var recColor = new MCvScalar(0, 255, 0);

                TrackCurrentColor(lower, upper, rgb, recColor);
            }

            if (this.trackColor2)
            {
               var lower = new ScalarArray(new MCvScalar(color2.Blue_Min, color2.Green_Min, color2.Red_Min, 255));
               var upper = new ScalarArray(new MCvScalar(color2.Blue_Max, color2.Green_Max, color2.Red_Max, 255));

               var recColor = new MCvScalar(255, 0, 255);

                TrackCurrentColor(lower, upper, rgb, recColor);
            }

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
            StopPlaying();
            this._isPaused = false;
        }

        private void StopPlaying()
        {
            this._capture.Dispose();
            this.screenBox1.Image = null;
            this.Height = this.defaultHeight;
            this.Width = this.defaultWide;
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

        private void kameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var camSettings = new SelectCaptureDevice())
            {
                camSettings.ShowDialog();
            }
        }

        private void videodateiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var fileSelection = new FileSoreceSelection())
            {
                fileSelection.ShowDialog();
            }
        }

        private void prozesseinstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var colorSettings = new ColorSettings(color1, color2))
            {
                colorSettings.ShowDialog();
            }
        }
    }
}