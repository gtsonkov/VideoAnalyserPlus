using Modules;
using Modules.Interfaces;
using Modules.Wrappers;
using System.Text;

namespace VT
{
    public partial class SelectCaptureDevice : Form
    {
        private IDsDeviceWrapper[] devices;
        private IResolution resulution;
        private ICaptureDevice selectedDevice;

        public SelectCaptureDevice()
        {
            InitializeComponent();
            this.Load += async (sender, e) => { await RefreshDeviceListAsync(); };
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            await RefreshDeviceListAsync();
        }

        private void UpdateDeviceListUI(ICollection<string> captureDevices)
        {
            this.deviceList.Items.Clear();

            if (captureDevices.Count > 0)
            {
                this.deviceList.Items.AddRange(captureDevices.ToArray());
            }
            else
            {
                MessageBox.Show("Keine Aufnahmegerät gefunden!");
            }

            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }

        private async Task RefreshDeviceListAsync()
        {
            List<string> captureDevices = ((List<string>) await FetchCaptureDevicesAsync());
        }

        private async Task<ICollection<string>> FetchCaptureDevicesAsync()
        {
            this.devices = DsDeviceWrapper.GetDevices().ToArray();

            List<string> deviceNames = devices.Select(device => device.Name).ToList();
            return deviceNames;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (this.deviceList.SelectedIndex >= 0)
            {

                var mainForm = (MainForm)Application.OpenForms["MainForm"];

                mainForm.DisposePreviosSorce();

                mainForm.SetPayerWithCaptureDivece(this.selectedDevice, mainForm);

                this.Close();
            }
        }

        private async void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;

            if (this.devices != null && devices.Count() > 0)
            {
                int deviceIndex = this.deviceList.SelectedIndex;
                await (LoadSelectedDevice(deviceIndex));
                await (LoadResolutionsToComboMenu());
            }
        }

        private async Task<string> LoadResolutionsToComboMenu()
        {
            this.resolutionsComboBox.Items.Clear();

            List<string> resolutions = new List<string>();

            foreach (var item in this.selectedDevice.SupportedResolutions)
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(item.Width.ToString());
                stringBuilder.Append("x");
                stringBuilder.Append(item.Height.ToString());
                stringBuilder.Append(" /");

                if (item.FrameRate != null && item.FrameRate > 0)
                {
                    stringBuilder.Append(item.FrameRate.ToString() + "fps");
                }
                else
                {
                    stringBuilder.Append("NaN");
                }

                resolutions.Add(stringBuilder.ToString());
            }

            resolutionsComboBox.Items.AddRange(resolutions.ToArray());
            return string.Empty;
        }

        private async Task LoadSelectedDevice(int deviceIndex)
        {
            string deviceName = this.deviceList.SelectedItem.ToString();

            this.selectedDevice = new CaptureDevice(devices[deviceIndex], deviceName, deviceIndex);

            if (this.resulution == null)
            {
                this.resulution = selectedDevice.SupportedResolutions.FirstOrDefault();
                this.selectedDevice.SetResolution(resulution);
            }
        }

        private void resolutionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedResolution = this.selectedDevice.SupportedResolutions.ToList()
                                                [this.resolutionsComboBox.SelectedIndex];
                this.selectedDevice.SetResolution(selectedResolution);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}