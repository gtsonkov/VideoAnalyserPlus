using DirectShowLib;
using Modules.Interfaces;
using Moq;

namespace Modules.Tests
{
    public class CaptureDeviceTests
    {
        private Mock<IDsDeviceWrapper> _deviceWrapperMock;

        [SetUp]
        public void Setup()
        {
            this._deviceWrapperMock = new Mock<IDsDeviceWrapper>();
        }

        [Test]
        public void CaptureDevice_Constructor_NullSource_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(null, "someName", 0));
        }
    

        [Test]
        public void CaptureDevice_Constructor_EmptyDeviceName_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(_deviceWrapperMock.Object, string.Empty, 0));
        }
    }
}