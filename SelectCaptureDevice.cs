using Emgu.CV;

namespace VT
{
    public partial class SelectCaptureDevice : Form
    {
        private List<string> captureDevices;

        public SelectCaptureDevice()
        {
            InitializeComponent();
            this.captureDevices = new List<string>();
            GetCaptureDevices();
            FillDropDownMenu();
        }

        private void FillDropDownMenu()
        {
            if (captureDevices.Count > 0)
            {
                comboBox1.Items.AddRange(this.captureDevices.ToArray());
            }
            else
            {
                MessageBox.Show("Keine Aufnahmegerät gefunden!");
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            GetCaptureDevices();
            FillDropDownMenu();
        }

        private void GetCaptureDevices()
        {
            int iterator = 0;

            while (true)
            {
                using (VideoCapture capture = new VideoCapture(iterator, VideoCapture.API.Any))
                {
                    if (capture.IsOpened)
                    {
                        this.captureDevices.Add(capture.BackendName);
                        continue;
                    }

                    break;
                }
            }
        }
    }
}