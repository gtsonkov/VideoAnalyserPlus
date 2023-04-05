﻿using DirectShowLib;
using Modules;
using Modules.Interfaces;
using System.Text;

namespace VT
{
    public partial class SelectCaptureDevice : Form
    {
        private List<string> captureDevices;
        private DsDevice[]? devices;
        private Resolution resulution;
        private CaptureDevice selectedDevice;

        public SelectCaptureDevice()
        {
            InitializeComponent();
            this.captureDevices = new List<string>();
            GetCaptureDevices();
            FillDropDevicesDownMenu();

            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }

        private void FillDropDevicesDownMenu()
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

        private async void refreshBtn_Click(object sender, EventArgs e)
        {
            this.deviceList.Items.Clear();
            this.captureDevices.Clear();
            await (GetCaptureDevices());
            FillDropDevicesDownMenu();

            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;
        }

        private async Task GetCaptureDevices()
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

                mainForm.DisposePreviosSorce();

                mainForm.SetPayerWithCaptureDivece(this.selectedDevice, mainForm);

                this.Close();
            }
        }

        private async void deviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.OkBtn.Enabled = this.deviceList.SelectedIndex >= 0;

            if (this.devices != null)
            {
                int deviceIndex = this.deviceList.SelectedIndex;
                await(LoadSelectedDevice(deviceIndex));
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
                    stringBuilder.Append(item.FrameRate.ToString() +"fps");
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
            DsDevice capture = devices[deviceIndex];

            IDsDeviceWrapper currentCapture = new DsDeviceWrapper(capture);

            this.selectedDevice = new CaptureDevice(currentCapture, deviceName, deviceIndex);

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