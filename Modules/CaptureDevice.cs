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
        HashSet<Resolution> supportedResolutions;

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
            this.supportedResolutions = GetSupportedResolutions().ToHashSet();

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

        public IEnumerable<Resolution> SupportedResolutions
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

        //public void SetResolution(string resolution)
        //{
        //    this.Resolution = GetResolution(resolution);
        //}

        private void SetCurrentResolution()
        {
            if (this.currentSorce != null && currentResolution != null)
            {
                this.currentSorce.Set(CapProp.FrameWidth, this.currentResolution.Width);
                this.currentSorce.Set(CapProp.FrameHeight, this.currentResolution.Height);
            }
        }

        private IEnumerable<Resolution> GetSupportedResolutions()
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

                    //var AvailableResolutions = new List<string>();
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
    }
}