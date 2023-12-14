﻿using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Modules.Interfaces;

using System.Runtime.InteropServices;

namespace Modules
{
    public class CaptureDevice : ICaptureDevice
    {
        private VideoCapture? currentSorce;
        private IResolution? currentResolution;
        private DsDevice captureDevice;

        private string? deviceName;
        HashSet<IResolution> supportedResolutions;

        public CaptureDevice(IDsDeviceWrapper sorce, string deviceName, int position)
        {

            this.SetSorce(sorce);

            this.DeviceName = deviceName;

            if (position < 0)
            {
                throw new InvalidOperationException("Device position can not be negative value.");
            }

            this.supportedResolutions = GetSupportedResolutions().ToHashSet();

            this.VideoSorce = new VideoCapture(position);
        }

        public CaptureDevice(IDsDeviceWrapper sorce, string deviceName, VideoCapture capture)
        {
            this.SetSorce(sorce);

            this.DeviceName = deviceName;

            this.VideoSorce = capture;
        }

        public VideoCapture VideoSorce
        {
            get
            {
                return this.currentSorce;
            }

            private set
            {
                try
                {
                    this.currentSorce = value;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }

            }
        }

        public string DeviceName
        {
            get
            {
                return this.deviceName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Value can not be null or empty.");
                }
                string temp = value;

                this.deviceName = value;
            }
        }

        public IEnumerable<IResolution> SupportedResolutions
        {
            get
            {
                return this.supportedResolutions;
            }
        }

        public IResolution Resolution
        {
            get
            {
                return this.currentResolution;
            }
            private set
            {
                this.currentResolution = value;
                SetCurrentResolution();
            }
        }

        public void SetResolution(IResolution resolution)
        {
            this.Resolution = resolution;
        }

        //Sets the current resolution of the video source
        private void SetCurrentResolution()
        {
            if (this.currentSorce != null && currentResolution != null)
            {
                this.currentSorce.Set(CapProp.FrameWidth, this.currentResolution.Width);
                this.currentSorce.Set(CapProp.FrameHeight, this.currentResolution.Height);
            }
        }

        private IEnumerable<IResolution> GetSupportedResolutions()
        {
            try
            {
                int hr = 0;
                int bitCount = 0;

                if (this.captureDevice != null)
                {
                    var vidDev = this.captureDevice;

                    IBaseFilter sourceFilter = null;

                    var m_FilterGraph2 = new FilterGraph() as IFilterGraph2;

                    hr = m_FilterGraph2.AddSourceFilterForMoniker(vidDev.Mon, null, vidDev.Name, out sourceFilter);

                    var pins = new List<IPin>();

                    hr = sourceFilter.EnumPins(out var ppEnum);

                    IntPtr fetched = IntPtr.Zero;

                    IPin[] pin = new IPin[1];

                    while (ppEnum.Next(1, pin, fetched) == 0 && pin[0] != null)
                    {
                        pins.Add(pin[0]);
                    }

                    HashSet<Resolution> temp = new HashSet<Resolution>();

                    foreach (var pRaw2 in pins)
                    {
                        VideoInfoHeader v = new VideoInfoHeader();
                        IEnumMediaTypes mediaTypeEnum;
                        hr = pRaw2.EnumMediaTypes(out mediaTypeEnum);

                        AMMediaType[] mediaTypes = new AMMediaType[1];
                        while (mediaTypeEnum.Next(1, mediaTypes, fetched) == 0 && mediaTypes[0] != null)
                        {

                            Marshal.PtrToStructure(mediaTypes[0].formatPtr, v);

                            if (v.BmiHeader.Size != 0 && v.BmiHeader.BitCount != 0)
                            {
                                if (v.BmiHeader.BitCount > bitCount)
                                {
                                    bitCount = v.BmiHeader.BitCount;
                                }

                                int frameRate = (v.AvgTimePerFrame > 0) ? Convert.ToInt32(1e7 / v.AvgTimePerFrame) : 0;

                                Resolution currResolution = new Resolution(v.BmiHeader.Width, v.BmiHeader.Height);

                                if (frameRate > 0.1)
                                {
                                    currResolution.FrameRate = frameRate;
                                }

                                temp.Add(currResolution);
                            }

                            DsUtils.FreeAMMediaType(mediaTypes[0]);
                        }
                    }

                    return temp;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return new HashSet<Resolution>();
        }

        private void SetSorce(IDsDeviceWrapper Sorce)
        {
            if (Sorce == null)
            {
                throw new ArgumentNullException("Sorce can not be null.");
            }

            this.captureDevice = Sorce.Device;
        }
    }
}