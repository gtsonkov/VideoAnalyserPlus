using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Modules;
using Modules.Interfaces;

namespace VT
{
    public partial class MainForm : Form, IStreamable
    {
        private VideoCapture _capture;

        private Player _player;

        internal CaptureDevice currCaptureDevice;

        internal string _file = string.Empty;

        internal ColorMask color1;
        internal ColorMask color2;

        internal bool trackColor1;
        internal bool trackColor2;

        private Mat _frame;

        //To Do: Make it dynamic
        private int _frameRate = 160;
        private const int toolbarWight = 100;
        private bool _isPaused;
        private int defaultWide = 812;
        private int defaultHeight = 575;

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

            if (this._file == string.Empty && this.currCaptureDevice == null)
            {
                MessageBox.Show("Bitte eine Quelle festliegen (Kamera oder Videodatei.)", "Warnung");
                return;
            }
            else
            {
                //Strat video form capture device

                if (this.currCaptureDevice != null)
                {
                    this._player = new Player(this.currCaptureDevice, this);

                    try
                    {
                        this._player.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Warnung");
                        return;
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
                        MessageBox.Show(ex.Message, "Warnung");
                        return;
                    }
                }
            }

            //this._frame = new Mat();
            //
            //this.Height = (this._capture.Height) + toolbarWight;
            //this.Width = this._capture.Width;
            //
            //this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            //this._capture.ImageGrabbed += ProcessFrameEventHandler;
            //this._capture.Start();
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

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopPlaying();
        }

        private void StopPlaying()
        {
            if (this._player != null) 
            {
                this._isPaused = false;
                this._player.Stop();
                this.screenBox1.Image = null;
                this.Height = this.defaultHeight;
                this.Width = this.defaultWide;
            }  
        }

        private void VideoPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this._player != null)
            {
                this._player.Stop();
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

        public void DisplayFrame(Bitmap frame)
        {
            
            this.screenBox1.Image = frame;
        }
    }
}