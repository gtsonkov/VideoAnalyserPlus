using Modules;
using Modules.Interfaces;

namespace VT
{
    public partial class MainForm : Form, IStreamable
    {
        private FilterPlayer _player;

        internal string _file = string.Empty;

        internal FilterMask color1;
        internal FilterMask color2;

        private List<Rectangle> objectsColor1;
        private List<Rectangle> objectsColor2;

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
            this.color1 = new FilterMask();
            this.color2 = new FilterMask();
        }

        public MainForm(object obj)
        {
            InitializeComponent();
            this._file = obj.ToString() as string;
        }

        public void DisplayFrame(Bitmap frame, List<Rectangle>[] detectedAreas)
        {
            this.objectsColor1 = detectedAreas[0];

            this.objectsColor2 = detectedAreas[1];

            Graphics pic = Graphics.FromImage(frame);

            if (objectsColor1 != null && objectsColor1.Count() > 0)
            {
                Color penColor = Color.FromArgb(0, 255, 0);
                var pen = new Pen(penColor, 3);

                pic.DrawRectangles(pen, objectsColor1
                                        .Where(x => x.Width >= this.color1.MinPixelSize.Width
                                        && x.Height >= this.color1.MinPixelSize.Height).ToArray());
            }

            if (objectsColor2 != null && objectsColor2.Count() > 0)
            {
                Color penColor = Color.FromArgb(255, 0, 255);
                var pen = new Pen(penColor, 3);

                pic.DrawRectangles(pen, objectsColor2
                                                       .Where(x => x.Width >= this.color2.MinPixelSize.Width
                                                       && x.Height >= this.color2.MinPixelSize.Height).ToArray());
            }

            this.screenBox1.Image = frame;
        }

        //Set colors to tracking
        internal void SetFilterColors(FilterMask colorA, FilterMask colorB)
        {
            if (this._player != null)
            {
                this.color1 = colorA;
                this.color2 = colorB;

                this._player.FilterColor_A = this.color1;
                this._player.FilterColor_B = this.color2;
            }
        }

        //Enable/Disable Color A (Color 1) Tracking
        internal void SetTrackingControlColorA(bool trackColor)
        {
            if (this._player != null)
            {
                this.trackColor1 = trackColor;
                this._player.EnableTrackColor_A = this.trackColor1;
            }
        }

        //Enable/Disable Color B (Color 2) Tracking
        internal void SetTrackingControlColorB(bool trackColor)
        {
            if (this._player != null)
            {
                this.trackColor2 = trackColor;
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
                this._player.Dispose();
                this._player = null;
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

        private void screenBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.objectsColor1 != null)
            {
                foreach (Rectangle rect in this.objectsColor1)
                {
                    if (rect.Contains(e.Location))
                    {
                        // Create a new form with a zoomed-in view of the rectangle
                        ShowSelected zoomForm = new ShowSelected(this.screenBox1.Image, rect);
                        zoomForm.Show();
                        break;
                    }
                }
            }

            if (this.objectsColor1 != null)
            {
                foreach (Rectangle rect in this.objectsColor2)
                {
                    if (rect.Contains(e.Location))
                    {
                        // Create a new form with a zoomed-in view of the rectangle
                        ShowSelected zoomForm = new ShowSelected(this.screenBox1.Image, rect);
                        zoomForm.Show();
                        break;
                    }
                }
            }
        }
            
    }
}