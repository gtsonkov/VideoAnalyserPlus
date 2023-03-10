using Modules;
using Modules.Interfaces;

namespace VT
{
    public partial class MainForm : Form, IStreamable
    {
        private FilterPlayer _player;

        internal string _file = string.Empty;

        internal ColorMask color1;
        internal ColorMask color2;

        internal bool trackColor1;
        internal bool trackColor2;
        internal bool sorceRedy;

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

        public void DisplayFrame(Bitmap frame)
        {

            this.screenBox1.Image = frame;
        }

        //Set colors to tracking
        internal void SetFilterColors (ColorMask colorA, ColorMask colorB) 
        {
            if (this._player != null)
            {
                this.color1 = colorA;
                this.color2 = colorB;

                this._player.FilterColor_A = this.color1;
                this._player.FilterColor_B = this.color2;
            }
        }

        //Enable/Disable Colors (A)/(B) Tracking
        internal void SetTrackingControl(bool trackColorA, bool trackColorB)
        {
            if (this._player != null) 
            {
                this.trackColor1 = trackColorA;
                this.trackColor2 = trackColorB;

                this._player.EnableTrackColor_A = this.trackColor1;
                this._player.EnableTrackColor_B = this.trackColor2;
            }
        }

        //Create Player including capture device
        internal void SetPlayer(CaptureDevice device, IStreamable form)
        {
            if (device == null || form == null)
            {
                throw new ArgumentNullException("Device und form can not be null.");
            }

            this._player = new FilterPlayer(device, form);

            //The sorce is set and redy to use
            this.sorceRedy = true;
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            //If paused, just cotinue playing
            if (this._isPaused)
            {
                this._player.Play();
                this._isPaused = false;
                return;
            }

            if (this._file == string.Empty && this._player == null)
            {
                MessageBox.Show("Bitte eine Quelle festliegen (Kamera oder Videodatei.)", "Warnung");
                return;
            }
            else
            {
                //Strat video form capture device

                if (this._player != null)
                {
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
                    //To do: Play video file sorce
                }
            }

            //Set the Image box size to the sorce size
            this.Height = (this._player.Resolution.Height) + toolbarWight;
            this.Width = this._player.Resolution.Width;
        }

        //If sorce chenge, stop playing current sorce first
        internal void SorceChange()
        {
            this.StopPlaying();
        }

        private void PauseBtn_Click(object sender, EventArgs e)
        {
            if (this._player != null) 
            {
                this._player.Pause();
                this._isPaused = true;
            }
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
    }
}