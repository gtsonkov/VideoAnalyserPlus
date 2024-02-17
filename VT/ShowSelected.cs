using Modules.Interfaces;
using Modules.Models;

namespace VT
{
    public partial class ShowSelected : Form
    {
        Image _frame;
        IDetectionArea _frameBounds;

        public ShowSelected(Image frame, DetectionArea area)
        {
            InitializeComponent();
            this._frame = frame;
            this._frameBounds = area;
        }

        private void ShowSelected_Load(object sender, EventArgs e)
        {
            Bitmap currPic = new Bitmap(this._frame);

            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            //this.Width = _frameBounds.Width;
            //this.Height = _frameBounds.Height;

            this.pictureBox.Image = currPic.Clone(this._frameBounds.GetRectangle, currPic.PixelFormat);
            currPic.Dispose();
        }

        private void ShowSelected_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pictureBox.Image = null;
            this.pictureBox.Dispose();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}