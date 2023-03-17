using Modules;
using Utilities;

namespace VT
{
    public partial class ColorSettings : Form
    {
        private MainForm mainForm;

        private FilterMaskRGB _color1;
        private FilterMaskRGB _color2;
        private bool sorceRedy;

        public ColorSettings()
        {
            InitializeComponent();

            this._color1 = new FilterMaskRGB();
            this._color2 = new FilterMaskRGB();

            SetPropertysState();
        }

        public ColorSettings(FilterMaskRGB color1, FilterMaskRGB color2)
        {
            InitializeComponent();

            this.mainForm = (MainForm)Application.OpenForms["MainForm"];

            this._color1 = color1;
            this._color2 = color2;

            SetColorsView();

            SetPropertysState();
        }

        private void SetPropertysState()
        {
            sorceRedy = this.mainForm.sorceRedy;

            this.stratTrackC1CheckBox.Checked = this.mainForm.trackColor1;
            this.stratTrackC2CheckBox.Checked = this.mainForm.trackColor2;

            this.stratTrackC1CheckBox.Enabled = sorceRedy;
            this.stratTrackC2CheckBox.Enabled = sorceRedy;

            this.radiusC1TrackBar.Value = this._color1.Radius;
            this.radiusC2TrackBar.Value = this._color2.Radius;

            this.MinWidthC1TxtBox.Text = this._color1.MinPixelSize.Width.ToString();
            this.MinHeightC1TxtBox.Text = this._color1.MinPixelSize.Height.ToString();
            this.MinWidthC2TxtBox.Text = this._color2.MinPixelSize.Width.ToString();
            this.MinHeightC2TxtBox.Text = this._color2.MinPixelSize.Height.ToString(); ;
        }

        private void Color1SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C1.ShowDialog() == DialogResult.OK)
            {
                this._color1.BaseColor = colorDialog_C1.Color;

                SetColorsView();
            }
        }

        private void Color2SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C2.ShowDialog() == DialogResult.OK)
            {
                this._color2.BaseColor = colorDialog_C2.Color;

                SetColorsView();
            }
        }

        private void radiusC1Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currMinPixelSizeW = int.Parse(this.MinWidthC1TxtBox.Text);
                int currMinPixelSizeH = int.Parse(this.MinHeightC1TxtBox.Text);

                if (currMinPixelSizeW < 1 || currMinPixelSizeH < 1)
                {
                    MessageBox.Show("Pixelzahl muss > 0 sein!", "Fehler");
                    return;
                }

                try
                {
                    this._color1.MinPixelSize.Width = currMinPixelSizeW;
                    this._color1.MinPixelSize.Height = currMinPixelSizeH;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
            catch
            {

                MessageBox.Show("Bitte geben Sie eine gültige Zahl für Minimum Pixelzahl an.", "Fehler"); ;
            }

            SetColorRange(this._color1, this._color1.Radius);

            SetColorsView();
        }

        private void radiusC2Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currMinPixelSizeW = int.Parse(this.MinWidthC2TxtBox.Text);
                int currMinPixelSizeH = int.Parse(this.MinHeightC2TxtBox.Text);

                if (currMinPixelSizeW < 1 || currMinPixelSizeH < 1)
                {
                    MessageBox.Show("Pixelzahl muss > 0 sein!", "Fehler");
                    return;
                }

                try
                {
                    this._color2.MinPixelSize.Width = currMinPixelSizeW;
                    this._color2.MinPixelSize.Height = currMinPixelSizeH;
                }
                catch (Exception ex)
                {

                    throw new ArgumentException(ex.Message);
                }
            }
            catch
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl für Minimum Pixelzahl an.", "Fehler"); ;
            }

            SetColorRange(this._color2, this._color2.Radius);
            SetColorsView();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!sorceRedy)
            {
                MessageBox.Show("Bitte wählenn sie vorerst eine vido Quelle (camera oder video file)", "Warnung");
                return;
            }

            ApllyColorsChanges();

            this.Close();
        }

        private void ApllyColorsChanges()
        {
            Task.Factory.StartNew(() =>
            {
                this.mainForm.SetFilterColors(this._color1, this._color2);
            });

            SetColorsView();
        }

        private void SetColorsView()
        {
            this.pictureBox1.BackColor = Color.FromArgb(this._color1.Red_Min, this._color1.Green_Min, this._color1.Blue_Min);
            this.pictureBox2.BackColor = _color1.BaseColor;
            this.pictureBox3.BackColor = Color.FromArgb(this._color1.Red_Max, this._color1.Green_Max, this._color1.Blue_Max);

            this.pictureBox4.BackColor = Color.FromArgb(this._color2.Red_Min, this._color2.Green_Min, this._color2.Blue_Min);
            this.pictureBox5.BackColor = _color2.BaseColor;
            this.pictureBox6.BackColor = Color.FromArgb(this._color2.Red_Max, this._color2.Green_Max, this._color2.Blue_Max);
        }

        private void SetColorRange(FilterMaskRGB color, int radius)
        {
            color.BaseColor = color.BaseColor;

            color.Red_Max = getMax(color.BaseColor.R, radius);
            color.Green_Max = getMax(color.BaseColor.G, radius);
            color.Blue_Max = getMax(color.BaseColor.B, radius);

            color.Red_Min = getMin(color.BaseColor.R, radius);
            color.Green_Min = getMin(color.BaseColor.G, radius);
            color.Blue_Min = getMin(color.BaseColor.B, radius);
        }

        private int getMax(byte color, int radius)
        {
            if (color + radius > 255)
            {
                return 255;
            }
            else
            {
                return color + radius;
            }
        }

        private int getMin(byte color, int radius)
        {
            if (color - radius <= 0)
            {
                return 0;
            }
            else
            {
                return color - radius;
            }
        }

        private void stratTrackC1CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.mainForm.SetTrackingControlColorA(this.stratTrackC1CheckBox.Checked);
            });

            SetColorsView();
        }

        private void stratTrackC2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                this.mainForm.SetTrackingControlColorB(this.stratTrackC2CheckBox.Checked);
            });

            SetColorsView();
        }

        private void CheckUserInput_KeyPressed(object sender, KeyPressEventArgs e)
        {
            TextBox currSender = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                || (currSender.Text.Count() == 1 && currSender.Text == "0" && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void radiusC1TrackBar_Scroll(object sender, EventArgs e)
        {
            this._color1.Radius = radiusC1TrackBar.Value;

            SetColorRange(this._color1, this._color1.Radius);

            SetColorsView();
        }

        private void radiusC2TrackBar_Scroll(object sender, EventArgs e)
        {
            this._color2.Radius = radiusC2TrackBar.Value;

            SetColorRange(this._color2, this._color2.Radius);

            SetColorsView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._color1 != null && this._color1.BaseColor != null)
            {
                var hsl = VpTool.RgbToScaledHls(this._color1.BaseColor);
            }
        }
    }
}