using Modules;

namespace VT
{
    public partial class ColorSettings : Form
    {
        private ColorMask _color1;
        private ColorMask _color2;

        public ColorSettings()
        {
            InitializeComponent();
            this._color1 = new ColorMask();
            this._color2 = new ColorMask();

            SetPropertysState();
        }

        private void SetPropertysState()
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            this.stratTrackC1CheckBox.Checked = mainForm.trackColor1;
            this.stratTrackC2CheckBox.Checked = mainForm.trackColor2;

            this.radiusC1TxtBox.Text = this._color1.Radius.ToString();
            this.radiusC2TxtBox.Text = this._color2.Radius.ToString();
        }

        public ColorSettings(ColorMask color1, ColorMask color2)
        {
            InitializeComponent();
            this._color1 = color1;
            this._color2 = color2;

            SetColorsView();

            SetPropertysState();
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
                int currRadius = int.Parse(radiusC1TxtBox.Text);

                if (currRadius > 255 || currRadius < 0)
                {
                    MessageBox.Show("Radius auserhalb die grenzen 0 bis 255.", "Fehler");
                    return;
                }

                this._color1.Radius = currRadius;
            }
            catch
            {

                MessageBox.Show("Bitte geben Sie eine gültige Zahl an.", "Fehler");
            }

            SetColorRange(this._color1, this._color1.Radius);

            SetColorsView();
        }

        private void radiusC2Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currRadius = int.Parse(radiusC2TxtBox.Text);

                if (currRadius > 255 || currRadius < 0)
                {
                    MessageBox.Show("Radius auserhalb die grenzen 0 bis 255.", "Fehler");
                    return;
                }

                this._color2.Radius = currRadius;
            }
            catch
            {

                MessageBox.Show("Bitte geben Sie eine gültige Zahl an.", "Fehler");
            }

            SetColorRange(this._color2, this._color2.Radius);
            SetColorsView();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            ApllayColorsChanges();
        }

        private void ApllayColorsChanges()
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            mainForm.color1 = this._color1;
            mainForm.color2 = this._color2;

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

        private void SetColorRange(ColorMask color, int radius)
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
            var mainForm = (MainForm)Application.OpenForms["MainForm"];
            mainForm.trackColor1 = this.stratTrackC1CheckBox.Checked;
        }

        private void stratTrackC2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];
            mainForm.trackColor2 = this.stratTrackC2CheckBox.Checked;
        }
    }
}