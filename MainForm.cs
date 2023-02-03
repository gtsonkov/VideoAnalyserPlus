using Emgu.CV;
using VT;

namespace VideoAnalyserPlus
{
    public partial class MainForm : Form
    {

        private string file = string.Empty;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog(Owner); // Show Explorer browser dialog.

            if (result == DialogResult.OK) // Get result after click OK
            {
                this.file = openFileDialog1.FileName;
            }
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            //this.stopThread = false;
            //this._trackingThread = new Thread(TrackColor);
            //this._trackingThread.Start();
            using (var form = new VideoPlayerForm(this.file))
            {
                form.ShowDialog();
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            
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
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}