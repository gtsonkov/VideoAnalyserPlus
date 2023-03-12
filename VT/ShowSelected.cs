namespace VT
{
    public partial class ShowSelected : Form
    {
        Image _frame;
        Rectangle _frameBounds;

        public ShowSelected(Image frame, Rectangle area)
        {
            InitializeComponent();
            this._frame = frame;
            this._frameBounds = area;
        }

        private void ShowSelected_Load(object sender, EventArgs e)
        {
            Bitmap currPic = new Bitmap(this._frame);

            this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Width = currPic.Width;
            this.Height = currPic.Height;

            this.pictureBox.Image = currPic.Clone(this._frameBounds, currPic.PixelFormat);
            currPic.Dispose();
        }

        private void ShowSelected_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.pictureBox.Image = null;
        }
    }
}