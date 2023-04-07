using DirectShowLib;

namespace Modules.Interfaces
{
    public interface IDsDeviceWrapper
    {
        public DsDevice Device { get; }
        public string Name { get; }
    }
}