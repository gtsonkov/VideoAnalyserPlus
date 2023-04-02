using Emgu.CV;
using Modules;
using Modules.Interfaces;
using Utilities;

namespace VT
{
    public partial class MainForm : Form, IStreamable
    {
        private FilterPlayer _player;
        private Bitmap _unfilteredFrame;

        internal string _file = string.Empty;

        internal FilterMaskRGB color1;
        internal FilterMaskRGB color2;

        private List<Rectangle> objectsColor1;
        private List<Rectangle> objectsColor2;
        private Pen penColor1;
        private Pen penColor2;

        internal bool trackColor1;
        internal bool trackColor2;
        internal bool sorceRedy;

        private const int toolbarHeight = 100;
        private const int BordersHeight = 21;
        private const int BordersWidth = 18;

        private bool _isPaused;
        private int defaultWide = 812;
        private int defaultHeight = 575;

        private bool fullscreen = false;

        public MainForm()
        {
            InitializeComponent();
            this.color1 = new FilterMaskRGB();
            this.color2 = new FilterMaskRGB();

            SetPenColor1(ConstantData.DefaultColor_A, ConstantData.DefaultBorderRectangles);
            SetPenColor2(ConstantData.DefaultColor_B, ConstantData.DefaultBorderRectangles);
            SetPenForColor1(ConstantData.DefaultColor_A, ConstantData.DefaultBorderRectangles);
            SetPenForColor2(ConstantData.DefaultColor_B, ConstantData.DefaultBorderRectangles);
        }

        private void SetPenColor2(Color defaultColor_B, int defaultBorderRectangles)
        {
            //throw new NotImplementedException();
        }

        private void SetPenColor1(Color defaultColor_A, int defaultBorderRectangles)
        {
            //throw new NotImplementedException();
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

            //Make a Copy of the original frame befor drawing the recs
            this._unfilteredFrame = (Bitmap)frame.Clone();

            Graphics pic = Graphics.FromImage(frame);

            if (objectsColor1 != null && objectsColor1.Count() > 0)
            {
                pic.DrawRectangles(this.penColor1, objectsColor1.ToArray());
            }

            if (objectsColor2 != null && objectsColor2.Count() > 0)
            {
                pic.DrawRectangles(this.penColor2, objectsColor2.ToArray());
            }

            try
            {
                this.screenBox1.Image = frame;
            }
            catch (Exception ex)
            {

            }

            
        }

        //Set colors to tracking
        internal void SetFilterColor_A(FilterMaskRGB color)
        {
            if (this._player != null)
            {
                this.color1 = color;
                this._player.FilterColor_A = this.color1;
            }
        }

        internal void SetFilterColor_B(FilterMaskRGB color)
        {
            if (this._player != null)
            {
                this.color2 = color;
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
        internal void SetPayerWithCaptureDivece(CaptureDevice device, IStreamable form)
        {
            if (device == null || form == null)
            {
                throw new ArgumentNullException("Device und form can not be null.");
            }

            this._player = new FilterPlayer(device, form);

            //The sorce is set and redy to use
            this.sorceRedy = true;
        }

        internal void SetPayerWithVideoFile(VideoCapture device, IStreamable form)
        {
            if (device == null || form == null)
            {
                throw new ArgumentNullException("Device und form can not be null.");
            }

            this._player = new FilterPlayer(device, form);

            //The sorce is set and redy to use
            this.sorceRedy = true;
        }

        internal void DisposePreviosSorce()
        {
            this.SorceChange();
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

            AdjustPlayerScreenResolution();
        }

        //If sorce chenge, stop playing current sorce first
        private void SorceChange()
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
            var currentSorceResolution = this._player.Resolution;

            float scaleFactorX = (float)screenBox1.Width / currentSorceResolution.Width;
            float scaleFactorY = (float)screenBox1.Height / currentSorceResolution.Height;

            Point imagePoint = new Point((int)(e.X / scaleFactorX), (int)(e.Y / scaleFactorY));

            if (this.objectsColor1 != null)
            {
                //The list of rectangles shoud be sorted to assure, that when user click on of those, to appier firs the smallest deteckted area
                //if there are some nested areas
                var orderedListOfRectangles = this.objectsColor1.OrderBy(x => x.Width * x.Height).ToList();

                foreach (var rect in orderedListOfRectangles)
                {
                    if (rect.Contains(imagePoint))
                    {
                        ShowSelected zoomForm = new ShowSelected(this._unfilteredFrame, rect);
                        zoomForm.Show();
                        break;
                    }
                }
            }

            if (this.objectsColor2 != null)
            {
                //The list of rectangles shoud be sorted to assure, that when user click on of those, to appier firs the smallest deteckted area
                //if there are some nested areas
                var orderedListOfRectangles = this.objectsColor2.OrderBy(x => x.Width * x.Height).ToList();

                foreach (Rectangle rect in orderedListOfRectangles)
                {
                    if (rect.Contains(imagePoint))
                    {
                        // Create a new form with a zoomed-in view of the rectangle
                        ShowSelected zoomForm = new ShowSelected(this._unfilteredFrame, rect);
                        zoomForm.Show();
                        break;
                    }
                }
            }
        }

        private void AdjustPlayerScreenResolution()
        {
            //Set the Image box size to the sorce size
            this.Height = (this._player.Resolution.Height) + toolbarHeight + BordersHeight;
            this.Width = this._player.Resolution.Width + BordersWidth;
        }

        private void AdjustResolutionBtn_Click(object sender, EventArgs e)
        {
            AdjustPlayerScreenResolution();
        }

        internal void SetPenForColor1(Color color, int border)
        {
            if (color == null)
            {
                MessageBox.Show("Bitte wähen Sie zu erst eine Farbe für das Rechteck.", "Warnung");
            }
            else
            {
                int currentBorderWidth = border;

                if (currentBorderWidth <= 0)
                {
                    var dialog = MessageBox.Show(ConstantData.Message_RectangleBorderWigth_ZeroOrNegative
                                                  , ConstantData.Message_Tittle_Warning
                                                  , MessageBoxButtons.YesNo);

                    if (dialog != DialogResult.Yes)
                    {
                        return;
                    }
                }

                this.penColor1 = new Pen(color, currentBorderWidth);
            }
        }

        internal void SetPenForColor1(Color color)
        {
            if (color == null)
            {
                return;
            }

            if (this.penColor1 == null)
            {
                this.penColor1 = new Pen(color, ConstantData.DefaultBorderRectangles);
            }
            else
            {
                this.penColor1.Color = color;
            }
        }

        internal void SetPenForColor1(int border)
        {
            if (this.penColor1 == null)
            {
                MessageBox.Show("Bitte wähen Sie zu erst eine Farbe für das Rechteck.", "Warnung");
            }
            else
            {
                if (border > 0)
                {
                    this.penColor1.Width = border;
                }
            }
        }

        internal void SetPenForColor2(Color color, int border)
        {
            if (color == null)
            {
                MessageBox.Show("Bitte wähen Sie zu erst eine Farbe für das Rechteck.", "Warnung");
            }
            else
            {
                int currentBorderWidth = border;

                if (currentBorderWidth <= 0)
                {
                    var dialog = MessageBox.Show(ConstantData.Message_RectangleBorderWigth_ZeroOrNegative
                                                , ConstantData.Message_Tittle_Warning
                                                , MessageBoxButtons.YesNo);

                    if (dialog != DialogResult.Yes)
                    {
                        return;
                    }
                }

                this.penColor2 = new Pen(color, currentBorderWidth);
            }
        }

        internal void SetPenForColor2(Color color)
        {
            if (color == null)
            {
                return;
            }

            if (this.penColor2 == null)
            {
                this.penColor2 = new Pen(color, ConstantData.DefaultBorderRectangles);
            }
            else
            {
                this.penColor2.Color = color;
            }
        }

        internal void SetPenForColor2(int border)
        {
            if (this.penColor2 == null)
            {
                MessageBox.Show("Bitte wähen Sie zu erst eine Farbe für das Rechteck.", "Warnung");
            }
            else
            {
                if (border > 0)
                {
                    this.penColor2.Width = border;
                }
            }
        }

        internal Pen GetPen_Color1()
        {
            return this.penColor1;
        }

        internal Pen GetPen_Color2()
        {
            return this.penColor2;
        }
    }
}