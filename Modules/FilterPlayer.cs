using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Modules.Interfaces;
using Modules.Models;
using System.Drawing.Imaging;
using YoloDotNet;

namespace Modules
{
    public class FilterPlayer : IPlayable
    {
        private VideoCapture _capture;
        private IStreamable _streamFrame;
        private ICaptureDevice currCaptureDevice;
        private VideoCapture currVideoCapture;
        private Mat _frame;

        private FilterMaskRGB color1;
        private FilterMaskRGB color2;

        private bool trackColor1;
        private bool trackColor2;

        private bool _isPaused;

        public FilterPlayer(ICaptureDevice currCaptureDevice, IStreamable stream)
        {
            if (currCaptureDevice == null)
            {
                throw new ArgumentNullException("Capture device can not be null.");
            }

            this.currCaptureDevice = currCaptureDevice;
            this._streamFrame = stream;

            this._capture = currCaptureDevice.VideoSorce;
        }

        public FilterPlayer(VideoCapture currCaptureDevice, IStreamable stream)
        {
            if (currCaptureDevice == null)
            {
                throw new ArgumentNullException("Capture device can not be null.");
            }

            this.currVideoCapture = currCaptureDevice;
            this._streamFrame = stream;

            this._capture = currVideoCapture;
        }

        public void Pause()
        {
            this._capture.Pause();
            this._isPaused = true;
        }

        public IStreamable SetStream
        {
            set
            {
                this._streamFrame = value;
            }
        }

        //Return resolution from curren capture
        public IResolution Resolution
        {
            get
            {
                if (currCaptureDevice != null)
                {
                    return this.currCaptureDevice.Resolution;
                }
                else
                {
                    int w = currVideoCapture.Width;
                    int h = currVideoCapture.Height;
                    var res = new Resolution(w, h);
                    return res;
                }
            }
        }

        public bool EnableTrackColor_A
        {
            get
            {
                return this.trackColor1;
            }
            set
            {
                this.trackColor1 = value;
            }
        }

        public bool EnableTrackColor_B
        {
            get
            {
                return this.trackColor2;
            }
            set
            {
                this.trackColor2 = value;
            }
        }

        //Strat playing
        public async void Play()
        {
            if (this._isPaused)
            {
                this._capture.Start();
                this._isPaused = false;
                return;
            }

            if (this.currCaptureDevice == null && this.currVideoCapture == null)
            {
                throw new ArgumentNullException("Bitte eine Quelle festliegen (Kamera oder Videodatei.)", "Warnung");
            }

            this._frame = new Mat();

            this._capture.ImageGrabbed -= ProcessFrameEventHandler;
            this._capture.ImageGrabbed += ProcessFrameEventHandler;
            this._capture.Start();
        }

        public FilterMaskRGB FilterColor_A
        {
            get
            {
                return this.color1;
            }
            set
            {
                this.color1 = value;
            }
        }

        public FilterMaskRGB FilterColor_B
        {
            get
            {
                return this.color2;
            }
            set
            {
                this.color2 = value;
            }
        }

        public void Stop()
        {
            StopPlaying();
            this._isPaused = false;
        }

        public async void ProcessFrameEventHandler(object sender, EventArgs e)
        {
            this._capture.Read(this._frame);

            if (_frame.IsEmpty)
            {
                return;
            }

            Mat filteredFrame = this._frame.Clone();

            //Mat hslImage = new Mat();
            //CvInvoke.CvtColor(filteredFrame, hslImage, ColorConversion.Bgr2Hls);

            List<IDetectionArea> color1Objects = new List<IDetectionArea>();

            if (this.trackColor1 && this.color1 != null)
            {
                var lower = new ScalarArray(new MCvScalar(color1.Blue_Min, color1.Green_Min, color1.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color1.Blue_Max, color1.Green_Max, color1.Red_Max, 255));

               //color1Objects = TrackCurrentColor(lower, upper, filteredFrame, this.color1.MinObjectSize).ToList();
            }

            //HLS filter test! 
            //if (this.trackColor1 && this.color1 != null)
            //{
            //    var lower = new ScalarArray(new MCvScalar(140, 50,200));
            //    var upper = new ScalarArray(new MCvScalar(180, 220,255));
            //
            //    color1Objects = TrackCurrentColor(lower, upper, hslImage, this.color1.MinObjectSize);
            //}

            List<IDetectionArea> color2Objects = new List<IDetectionArea>();

            if (this.trackColor2 && this.color2 != null)
            {
                var lower = new ScalarArray(new MCvScalar(color2.Blue_Min, color2.Green_Min, color2.Red_Min, 255));
                var upper = new ScalarArray(new MCvScalar(color2.Blue_Max, color2.Green_Max, color2.Red_Max, 255));

                //color2Objects = TrackCurrentColor(lower, upper, filteredFrame, this.color2.MinObjectSize).ToList();
            }

            //YOLO dot Net Test
            
            using var yolo = new Yolo(@"./RAW_Data/yolov8s.onnx", false);
            var bitmap = this._frame.ToBitmap();
            using MemoryStream memoryStream = new MemoryStream();
            bitmap.Save(memoryStream,ImageFormat.Png);
            
            memoryStream.Position = 0;
            using var image = SixLabors.ImageSharp.Image.Load(memoryStream);
            
            var results = yolo.RunObjectDetection(image);

            color1Objects = new List<IDetectionArea>();

            foreach ( var detection in results ) 
            {
                var currentObject = new DetectionArea(detection.BoundingBox.Location.X
                                                                 , detection.BoundingBox.Location.Y
                                                                 , detection.BoundingBox.Width
                                                                 , detection.BoundingBox.Height
                                                                 , new Label(detection.Label.Name, detection.Label.Color));
                color1Objects.Add(currentObject);
            }

            List<IDetectionArea>[] objectsFoundet = new List<IDetectionArea>[] { color1Objects, color2Objects };

            this._streamFrame.DisplayFrame(bitmap, objectsFoundet);
        }

        public void Dispose()
        {
            this.Stop();
            this.currCaptureDevice = null;
            this._capture.Dispose();

            if (this._frame != null)
            {
                this._frame.Dispose();
                this._frame = null;
            }
        }

        private IEnumerable<System.Drawing.Rectangle> TrackCurrentColor(IInputArray lower, IInputArray upper, Mat rgb, int minObjectSize)
        {
            Mat mask = new Mat();

            CvInvoke.InRange(rgb, lower, upper, mask);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            Mat hierarchy = new Mat();

            CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            return BoundingRectangles(contours, minObjectSize);
        }

        private IEnumerable<System.Drawing.Rectangle> BoundingRectangles(VectorOfVectorOfPoint vectors, int minObjectSize)
        {
            HashSet<System.Drawing.Rectangle> rects = new HashSet<System.Drawing.Rectangle>();

            for (int i = 0; i < vectors.Size; i++)
            {
                System.Drawing.Rectangle rect = CvInvoke.BoundingRectangle(vectors[i]);

                if ((rect.Width * rect.Height) >= minObjectSize)
                {
                    rects.Add(rect);
                }
            }

            return rects;
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