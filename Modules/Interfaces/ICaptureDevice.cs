using Emgu.CV;

namespace Modules.Interfaces
{
    public interface ICaptureDevice
    {
        string DeviceName { get; }
        IResolution Resolution { get; }
        IEnumerable<IResolution> SupportedResolutions { get; }
        VideoCapture VideoSorce { get; }

        void SetResolution(IResolution resolution);
    }
}