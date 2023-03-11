using Modules;

namespace VT
{
    public partial class ColorSettings : Form
    {
        private FilterMask _color1;
        private FilterMask _color2;
        private bool sorceRedy;

        public ColorSettings()
        {
            InitializeComponent();

            this._color1 = new FilterMask();
            this._color2 = new FilterMask();

            SetPropertysState();
        }

        public ColorSettings(FilterMask color1, FilterMask color2)
        {
            InitializeComponent();

            this._color1 = color1;
            this._color2 = color2;

            SetColorsView();

            SetPropertysState();
        }

        private void SetPropertysState()
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            sorceRedy = mainForm.sorceRedy;

            this.stratTrackC1CheckBox.Checked = mainForm.trackColor1;
            this.stratTrackC2CheckBox.Checked = mainForm.trackColor2;

            this.stratTrackC1CheckBox.Enabled = sorceRedy;
            this.stratTrackC2CheckBox.Enabled = sorceRedy;

            this.radiusC1TxtBox.Text = this._color1.Radius.ToString();
            this.radiusC2TxtBox.Text = this._color2.Radius.ToString();

            this.MinPixelCountC1TxtBox.Text = this._color1.MinPixelSize.ToString();
            this.MinPixelCountC2TxtBox.Text = this._color2.MinPixelSize.ToString();
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

                MessageBox.Show("Bitte geben Sie eine gültige Zahl für Radius an.", "Fehler");
            }

            try
            {
                int currMinPixelSize = int.Parse(this.MinPixelCountC1TxtBox.Text);

                if (currMinPixelSize < 1)
                {
                    MessageBox.Show("Pixelzahl muss > 0 sein!", "Fehler");
                    return;
                }

                this._color1.MinPixelSize = currMinPixelSize;
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

            try
            {
                int currMinPixelSize = int.Parse(this.MinPixelCountC2TxtBox.Text);

                if (currMinPixelSize < 1)
                {
                    MessageBox.Show("Pixelzahl muss > 0 sein!","Fehler");
                    return;
                }

                this._color2.MinPixelSize = currMinPixelSize;
            }
            catch
            {
                MessageBox.Show("Bitte geben Sie eine gültige Zahl für Minimum Pixelzahl an.", "Fehler");
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

            ApllayColorsChanges();
        }

        private void ApllayColorsChanges()
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            mainForm.SetFilterColors(this._color1, this._color2);

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

        private void SetColorRange(FilterMask color, int radius)
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
            SetTrackingControl();
        }

        private void stratTrackC2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SetTrackingControl();
        }

        private void SetTrackingControl()
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            mainForm.SetTrackingControl(this.stratTrackC1CheckBox.Checked, this.stratTrackC2CheckBox.Checked);
        }

        private void radiusC1TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckUserInput(sender, e);
        }

        private void radiusC2TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckUserInput(sender, e);
        }

        private void MinPixelCountC1TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckUserInput(sender, e);
        }

        private void MinPixelCountC2TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckUserInput(sender, e);
        }

        private void CheckUserInput(object sender, KeyPressEventArgs e)
        {
            TextBox currSender = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                || (currSender.Text.Count() == 1 && currSender.Text == "0" && !char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}