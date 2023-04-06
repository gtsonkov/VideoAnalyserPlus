using DirectShowLib;
using Modules.Interfaces;

namespace Modules.Wrappers
{
    public class DsDeviceWrapper : IDsDeviceWrapper
    {
        private DsDevice _device;

        public DsDeviceWrapper(DsDevice device)
        {
            Device = device;
        }

        public DsDevice Device
        {
            get
            {
                return this._device;
            }
            private set
            {
                if (value != null)
                {
                    this._device = value;
                }
                else
                {
                    throw new InvalidOperationException("Device cannot be null");
                }
            }
        }

        public IEnumerable<DsDeviceWrapper> GetDevices() 
        {
            DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

            HashSet<DsDeviceWrapper> result = new HashSet<DsDeviceWrapper>();

            foreach (DsDevice device in devices) 
            {
                DsDeviceWrapper currDevice = new DsDeviceWrapper(device);
                result.Add(currDevice);
            }

            return result;
        }
    }
}