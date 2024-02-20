using Emgu.CV;

namespace Modules.Interfaces
{
    public interface ICaptureDevice
    {
        public string DeviceName { get; }
        public IResolution Resolution { get; }
        public IEnumerable<IResolution> SupportedResolutions { get; }
        public VideoCapture VideoSorce { get; }
        public void SetResolution(IResolution resolution);
    }
}