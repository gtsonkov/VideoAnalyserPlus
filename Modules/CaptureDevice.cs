using DirectShowLib;
using Emgu.CV;
using Emgu.CV.CvEnum;
using System.Runtime.InteropServices;

namespace Modules
{
    public class CaptureDevice
    {
        private VideoCapture? currentSorce;
        private Resolution? currentResolution;
        private DsDevice captureDevice;

        private string? deviceName;
        List<Resolution> supportedResolutions;

        public CaptureDevice(DsDevice sorce, string deviceName, int position)
        {
            if (sorce == null || deviceName == string.Empty)
            {
                throw new ArgumentNullException("Value null or empty.");
            }

            if (position < 0)
            {
                throw new InvalidOperationException("Device position can not be negative value.");
            }

            this.captureDevice = sorce;
            this.DeviceName = deviceName;
            this.supportedResolutions = GetSupportedResolutions();

            if (position >= 0)
            {
                try
                {
                    this.VideoSorce = new VideoCapture(position);
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
        }

        public VideoCapture VideoSorce
        {
            get
            {
                return this.currentSorce;
            }

            private set
            {
                this.currentSorce = value;
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
                this.deviceName = value;
            }
        }

        public List<Resolution> SupportedResolutions
        {
            get
            {
                return this.supportedResolutions;
            }
        }

        public Resolution Resolution
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

        public void SetResolution(Resolution resolution)
        {
            this.Resolution = resolution;
        }

        public void SetResolution(string resolution)
        {
            this.Resolution = GetResolution(resolution);
        }

        private void SetCurrentResolution()
        {
            if (this.currentSorce != null && currentResolution != null)
            {
                this.currentSorce.Set(CapProp.FrameWidth, this.currentResolution.Width);
                this.currentSorce.Set(CapProp.FrameHeight, this.currentResolution.Height);
            }
        }

        private List<Resolution> GetSupportedResolutions()
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

                    var AvailableResolutions = new List<string>();

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
                                    AvailableResolutions.Clear();
                                    bitCount = v.BmiHeader.BitCount;
                                }

                                AvailableResolutions.Add(v.BmiHeader.Width + "x" + v.BmiHeader.Height);
                            }

                            DsUtils.FreeAMMediaType(mediaTypes[0]);
                        }
                    }

                    List<Resolution> temp = new List<Resolution>();

                    foreach (var element in AvailableResolutions)
                    {
                        var r = GetResolution(element);

                        if (!(temp.Any(x => r.Width == x.Width && r.Height == x.Height)))
                        {
                            temp.Add(r);
                        }
                    }

                    return temp;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return new List<Resolution>();
        }

        private Resolution GetResolution(string value)
        {
            try
            {
                if (value != null && value != string.Empty)
                {
                    var temp = value.Split("x").Select(x => int.Parse(x)).ToArray();

                    return new Resolution(temp[0], temp[1]);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return null;
        }
    }
}