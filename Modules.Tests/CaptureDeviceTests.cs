using Modules.Interfaces;
using Moq;

namespace Modules.Tests
{
    public class CaptureDeviceTests
    {
        private Mock<IDsDeviceWrapper> _deviceWrapperMock;
        private CaptureDevice _device;
        private string originName = "Device01";
        private int postion = 0;

        [SetUp]
        public void Setup()
        {
            this._deviceWrapperMock = new Mock<IDsDeviceWrapper>();
           this._device = new CaptureDevice(this._deviceWrapperMock.Object,this.originName,postion);
        }

        [Test]
        public void CaptureDevice_Constructor_NullSource_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(null, "someName", 1));
        }
    
        //[Test]
        //public void CaptureDevice_Constructor_EmptyDeviceName_ThrowsException()
        //{
        //    Assert.Throws<ArgumentNullException>(() => new CaptureDevice(_deviceWrapperMock.Object, string.Empty, 0));
        //}
        //
        //[Test]
        //public void CaptureDevice_Constructor_NegativePosition_ThrowsException()
        //{
        //    Assert.Throws<InvalidOperationException>(() => new CaptureDevice(_deviceWrapperMock.Object, this.originName, -1));
        //}
        //
        //[Test]
        //public void CaptureDevice_Set_Name_Set_Correctly_From_Constructor()
        //{
        //    Assert.AreEqual(this.originName, this._device.DeviceName);
        //}
    }
}