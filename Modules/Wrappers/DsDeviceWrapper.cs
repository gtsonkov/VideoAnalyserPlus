using DirectShowLib;
using Modules.Interfaces;

namespace Modules.Wrappers
{
    public class DsDeviceWrapper : IDsDeviceWrapper
    {
        private DsDevice _device;
        private string _deviceName;

        public DsDeviceWrapper(DsDevice device)
        {
            this.Device = device;
            this.Name = device.Name;
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

        public string Name
        {
            get
            {
                return this._deviceName;
            }
            private set
            {
                this._deviceName = value;
            }
        }

        public static IEnumerable<DsDeviceWrapper> GetDevices()
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