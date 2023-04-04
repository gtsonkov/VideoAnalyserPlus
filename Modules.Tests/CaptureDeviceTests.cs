using DirectShowLib;
using Modules.Interfaces;
using Moq;

namespace Modules.Tests
{
    public class CaptureDeviceTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CaptureDevice_Constructor_NullSource_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(null, "someName", 0));
        }
    

        [Test]
        public void CaptureDevice_Constructor_EmptyDeviceName_ThrowsException()
        {
            var mockDsDevice = new Mock<IDsDeviceWrapper>();
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(mockDsDevice.Object, string.Empty, 0));
        }
    }
}