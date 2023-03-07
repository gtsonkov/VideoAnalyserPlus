using Models;
using System.Security.Cryptography.X509Certificates;

namespace VT
{
    public partial class ColorSettings : Form
    {
        private Color _color1;
        private int radiusColor1 = 0;

        private Color _color2;
        private int radiusColor2 = 0;

        public ColorSettings()
        {
            InitializeComponent();
        }

        private void Color1SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C1.ShowDialog() == DialogResult.OK)
            {
                this._color1 = colorDialog_C1.Color;
            }
        }

        private void Color2SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C2.ShowDialog() == DialogResult.OK)
            {
                this._color2 = colorDialog_C2.Color;
            }
        }

        private void radiusC1Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currRadius = int.Parse(radiusC1TxtBox.Text);

                if (radiusColor1 > 255 || radiusColor1 < 0)
                {
                    MessageBox.Show("Radius auserhalb die grenzen 0 bis 255.", "Fehler");
                    return;
                }

                radiusColor1 = currRadius;
            }
            catch
            {

                MessageBox.Show("Bitte geben Sie eine gültige Zahl an.", "Fehler");
            }
        }

        private void radiusC2Btn_Click(object sender, EventArgs e)
        {
            try
            {
                int currRadius = int.Parse(radiusC2TxtBox.Text);

                if (radiusColor2 > 255 || radiusColor2 < 0)
                {
                    MessageBox.Show("Radius auserhalb die grenzen 0 bis 255.", "Fehler");
                    return;
                }

                radiusColor2 = currRadius;
            }
            catch
            {

                MessageBox.Show("Bitte geben Sie eine gültige Zahl an.", "Fehler");
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];

            mainForm.color1 = SetColorRange(this._color1, this.radiusColor1);
            mainForm.color2 = SetColorRange(this._color2, this.radiusColor2);

            SetColorsView(mainForm.color1, mainForm.color2);
        }

        private void SetColorsView(ColorMask c1, ColorMask c2)
        {
            this.pictureBox1.BackColor = Color.FromArgb(c1.Red_Min, c1.Green_Min, c1.Blue_Min);
            this.pictureBox2.BackColor = _color1;
            this.pictureBox3.BackColor = Color.FromArgb(c1.Red_Max, c1.Green_Max, c1.Blue_Max);

            this.label2.Text = (_color1.R.ToString() + _color1.G.ToString() + _color1.B.ToString());

            this.pictureBox4.BackColor = Color.FromArgb(c2.Red_Min, c2.Green_Min, c2.Blue_Min);
            this.pictureBox5.BackColor = _color2;
            this.pictureBox6.BackColor = Color.FromArgb(c2.Red_Max, c2.Green_Max, c2.Blue_Max);

            this.label3.Text = (_color2.R.ToString() + _color2.G.ToString() + _color2.B.ToString());
        }

        private ColorMask SetColorRange(Color color, int radius)
        {
            ColorMask currColor = new ColorMask();

            currColor.Red_Max = getMax(color.R, radius);
            currColor.Green_Max = getMax(color.G, radius);
            currColor.Blue_Max = getMax(color.B, radius);

            currColor.Red_Min = getMin(color.R, radius);
            currColor.Green_Min = getMin(color.G, radius);
            currColor.Blue_Min = getMin(color.B, radius);

            return currColor;
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
    }
}