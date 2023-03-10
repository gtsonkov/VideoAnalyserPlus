﻿using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Modules.Interfaces;
using System.Drawing;

namespace Modules
{
    public class Player : IPlayer
    {
        private VideoCapture _capture;

        private IStreamable _streamFrame;

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

        public Player(CaptureDevice currCaptureDevice, IStreamable stream)
        {
            if (currCaptureDevice == null)
            {
                throw new ArgumentNullException("Capture device can not be null.");
            }

            this.currCaptureDevice = currCaptureDevice;
            this._streamFrame = stream;

            this._capture = currCaptureDevice.VideoSorce;
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

        public async void Play()
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

        public async void ProcessFrameEventHandler(object sender, EventArgs e)
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

            //_capture.Retrieve(this._frame);

            //CvInvoke.Imshow("Color Tracking", this._frame);
            //CvInvoke.WaitKey(this._frameRate);
            this._streamFrame.DisplayFrame(BitmapExtension.ToBitmap(this._frame));
        }

        private void TrackCurrentColor(IInputArray lower, IInputArray upper, Mat rgb, MCvScalar colorRec)
        {
            Mat mask = new Mat();

            CvInvoke.InRange(rgb, lower, upper, mask);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();
            CvInvoke.FindContours(mask, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Height > 1 && rect.Width > 1)
                {
                    CvInvoke.Rectangle(_frame, rect, colorRec, 2);
                }
            }
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            StopPlaying();
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