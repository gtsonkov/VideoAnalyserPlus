using Emgu.CV;

namespace Modules.Interfaces
{
    public interface ICaptureDevice
    {
        string DeviceName { get; }
        Resolution Resolution { get; }
        IEnumerable<Resolution> SupportedResolutions { get; }
        VideoCapture VideoSorce { get; }

        void SetResolution(Resolution resolution);
    }
}