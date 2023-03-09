using DirectShowLib;
using Modules;
using System.Management;

namespace VT
{
    public partial class SelectCaptureDevice : Form
    {
        private List<string> captureDevices;
        private DsDevice[]? devices;
        private List<ManagementObject> foundedDevices;

        public SelectCaptureDevice()
        {
            InitializeComponent();
            this.captureDevices = new List<string>();
            GetCaptureDevices();
            FillDropDownMenu();

            foundedDevices = GetVideoCaptureDevices().ToList();

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

        private void GetSupportedResolutions()
        {

        }

        private void GetCaptureDevices()
        {
            this.devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            foreach (var device in this.devices)
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

            //Testing with both libs (DirectShowLib and .net)

            if (this.devices != null)
            {
                var currDevice = this.devices[int.Parse(this.deviceList.SelectedIndex.ToString())];
            }

            if (this.foundedDevices != null)
            {
                var selectedDevice = foundedDevices[int.Parse(this.deviceList.SelectedIndex.ToString())];
                var resolutions = GetDeviceResolution(selectedDevice);
            }
        }

        private IEnumerable<Resolution> GetDeviceResolution(ManagementObject crrDevices)
        {
            IEnumerable<Resolution> result = new List<Resolution>();
                    
            result = GetSupportedResolutions(crrDevices);
                
            return result;
        }

        private IEnumerable<ManagementObject> GetVideoCaptureDevices()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption LIKE '%(video)%'");

            foreach (ManagementObject device in searcher.Get())
            {
                yield return device;
            }
        }

        private IEnumerable<Resolution> GetSupportedResolutions(ManagementObject device)
        {
            var resolutions = new List<Resolution>();

            var name = (string)device["Name"];
            var deviceId = GetDeviceId(name);

            var searcher = new ManagementObjectSearcher("SELECT * FROM WmiMediaSupportedFormats WHERE InstanceName='" + deviceId + "'");

            foreach (ManagementObject supportedFormat in searcher.Get())
            {
                int width = (int)supportedFormat["HorizontalResolution"];
                int height = (int)supportedFormat["VerticalResolution"];

                var resolution = new Resolution(width, height);
                if (!resolutions.Contains(resolution))
                {
                    resolutions.Add(resolution);
                }
            }

            return resolutions;
        }

        private string GetDeviceId(string name)
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Caption='" + name + "'");

            foreach (ManagementObject device in searcher.Get())
            {
                return (string)device["DeviceID"];
            }

            return string.Empty;
        }
    }
}