﻿using DirectShowLib;
using Modules.Interfaces;

namespace Modules
{
    public class DsDeviceWrapper : IDsDeviceWrapper
    {
        private DsDevice _device;

        public DsDeviceWrapper(DsDevice device)
        {
                this.Device = device;
        }

        public DsDevice Device
        {
            get 
            { 
                return _device; 
            }
            private set 
            {
                if (_device != null) 
                {
                    _device = value;
                }
                else
                {
                    throw new InvalidOperationException("Device cannot be null");
                }
            }
        }
    }
}