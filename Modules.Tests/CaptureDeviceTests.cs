using Modules.Interfaces;
using Moq;
using Emgu.CV;

namespace Modules.Tests
{
    public class CaptureDeviceTests
    {
        private Mock<IDsDeviceWrapper> _deviceWrapperMock;
        private Mock<VideoCapture> _capture;
        private CaptureDevice _device;
        private string originName = "Device01";
        private int postion = 0;

        [SetUp]
        public void Setup()
        {
            this._deviceWrapperMock = new Mock<IDsDeviceWrapper>();
            this._capture = new Mock<VideoCapture>(1);
            this._device = new CaptureDevice(this._deviceWrapperMock.Object, this.originName, this._capture.Object);
        }

        [Test]
        public void CaptureDevice_Constructor_PositivePosition()
        {
            // Arrange
            IDsDeviceWrapper sorce = new Mock<IDsDeviceWrapper>().Object;
            string deviceName = "Test Device";
            int position = 1;

            // Act
            CaptureDevice captureDevice = new CaptureDevice(sorce, deviceName, position);

            // Assert
            Assert.AreEqual(deviceName, captureDevice.DeviceName);
            Assert.IsNotNull(captureDevice.VideoSorce);
        }

        [Test]
        public void CaptureDevice_Constructor_ZeroPosition()
        {
            // Arrange
            IDsDeviceWrapper sorce = new Mock<IDsDeviceWrapper>().Object;
            string deviceName = "Test Device";
            int position = 0;

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => new CaptureDevice(sorce, deviceName, position));
        }

        [Test]
        public void CaptureDevice_Constructor_NegativePosition()
        {
            // Arrange
            IDsDeviceWrapper sorce = new Mock<IDsDeviceWrapper>().Object;
            string deviceName = "Test Device";
            int position = -1;

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => new CaptureDevice(sorce, deviceName, position));
        }

        [Test]
        public void CaptureDevice_Constructor_NullSorce()
        {
            // Arrange
            IDsDeviceWrapper sorce = null;
            string deviceName = "Test Device";
            int position = 1;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(sorce, deviceName, position));
        }

        [Test]
        public void CaptureDevice_Constructor_NullSource_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(null, "someName", 1));
        }
    
        [Test]
        public void CaptureDevice_Constructor_EmptyDeviceName_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CaptureDevice(_deviceWrapperMock.Object, string.Empty, 0));
        }
        
        [Test]
        public void CaptureDevice_Constructor_NegativePosition_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => new CaptureDevice(_deviceWrapperMock.Object, this.originName, -1));
        }
        
        [Test]
        public void CaptureDevice_Set_Name_Set_Correctly_From_Constructor()
        {
            Assert.AreEqual(this.originName, this._device.DeviceName);
        }
    }
}