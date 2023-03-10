using Emgu.CV;
using Emgu.CV.Structure;
using Modules.Interfaces;

namespace Modules
{
    public class Player : IPlayer
    {
        private VideoCapture _capture;

        internal CaptureDevice currCaptureDevice;

        internal string _file = string.Empty;

        internal ColorMask color1;
        internal ColorMask color2;

        internal bool trackColor1;
        internal bool trackColor2;

        private Mat _frame;

        //To Do: Make it dynamic
        private int _frameRate = 60;
        private const int toolbarWight = 100;
        private bool _isPaused;
        private int defaultWide = 812;
        private int defaultHeight = 575;

        public void Pause()
        {
            this._capture.Pause();
            this._isPaused = true;
        }

        public void Play()
        {
            if (this._isPaused)
            {
                this._capture.Start();
                this._isPaused = false;
                return;
            }

            if (this._file == string.Empty && this.currCaptureDevice == null)
            {
                throw new ArgumentNullException("Bitte eine Quelle festliegen (Kamera oder Videodatei.)", "Warnung");
            }
            else
            {
                if (this.currCaptureDevice != null)
                {
                    //this._capture = new VideoCapture(deviceIndex);
                    try
                    {
                        this._capture = this.currCaptureDevice.VideoSorce;
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(ex.Message);
                    }

                    //this._capture.Set(CapProp.FrameWidth, 1024);
                    //this._capture.Set(CapProp.FrameHeight, 576);
                }
                else
                {
                    try
                    {
                        this._capture = new VideoCapture(this._file);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException(ex.Message);
                    }
                }
            }

            this._frame = new Mat();

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.Start();
        }

        public void Stop()
        {
            StopPlaying();
            this._isPaused = false;
        }

        private void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat rgb = this._frame.Clone();

            if (this.trackColor1)
            {
                var lower = new ScalarArray(new MCvScalar(color1.Blue_Min, color1.Green_Min, color1.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color1.Blue_Max, color1.Green_Max, color1.Red_Max, 255));

                var recColor = new MCvScalar(0, 255, 0);

                TrackCurrentColor(lower, upper, rgb, recColor);
            }

            if (this.trackColor2)
            {
                var lower = new ScalarArray(new MCvScalar(color2.Blue_Min, color2.Green_Min, color2.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color2.Blue_Max, color2.Green_Max, color2.Red_Max, 255));

                var recColor = new MCvScalar(255, 0, 255);

                TrackCurrentColor(lower, upper, rgb, recColor);
            }

            ShowVideo();

            //_capture.Retrieve(this._frame);

            //CvInvoke.Imshow("Color Tracking", this._frame);
            CvInvoke.WaitKey(this._frameRate);
        }

        private void ShowVideo()
        {
            throw new NotImplementedException();
        }

        private void TrackCurrentColor(ScalarArray lower, ScalarArray upper, Mat rgb, MCvScalar recColor)
        {
            throw new NotImplementedException();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void StopPlaying()
        {
            if (this._capture != null)
            {
                this._capture.Dispose();
            }

            this._isPaused = false;
        }
    }
}