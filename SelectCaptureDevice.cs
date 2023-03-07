using DirectShowLib;

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

            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }

        private void FillDropDownMenu()
        {
            if (captureDevices.Count > 0)
            {
                deviceList.Items.AddRange(this.captureDevices.ToArray());
            }
            else
            {
                MessageBox.Show("Keine Aufnahmegerät gefunden!");
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            this.deviceList.Items.Clear();
            this.captureDevices.Clear();
            GetCaptureDevices();
            FillDropDownMenu();

            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }

        private void GetCaptureDevices()
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);


            foreach (var device in devices)
            {
                this.captureDevices.Add(device.Name);
            }
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (this.deviceList.SelectedIndex >= 0)
            {
                var mainForm = (MainForm)Application.OpenForms["MainForm"];
                mainForm.deviceIndex = this.deviceList.SelectedIndex;
                if (mainForm._file != string.Empty) 
                {
                    mainForm.SorceChange();
                    mainForm._file = string.Empty;
                }

                this.Close();
            }
        }

        private void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }
    }
}