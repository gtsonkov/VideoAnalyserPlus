﻿using Modules.Models;

namespace VT
{
    public partial class ColorSettings : Form
    {
        private MainForm mainForm;

        private FilterMaskRGB _color1;
        private FilterMaskRGB _color2;
        private bool sorceRedy;

        private Pen pen1Sample;
        private Pen pen2Sample;

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

            SetPropertysState();

            SetColorsView();

            DrawRectangeSampleColor1();
            DrawRectangeSampleColor2();
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

            this.objectSizeC1TrackBar.Value = this._color1.MinObjectSize;
            this.objectSizeC2TrackBar.Value = this._color2.MinObjectSize;

            this.pen1Sample = this.mainForm.GetPen_Color1();
            this.pen2Sample = this.mainForm.GetPen_Color2();
        }

        private void Color1SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C1.ShowDialog() == DialogResult.OK)
            {
                this._color1.BaseColor = colorDialog_C1.Color;

                SetColorRange(this._color1, this._color1.Radius);
                SetColorsView();
                ApllyColorsChanges_Color1();
            }
        }

        private void Color2SetBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog_C2.ShowDialog() == DialogResult.OK)
            {
                this._color2.BaseColor = colorDialog_C2.Color;

                SetColorRange(this._color2, this._color2.Radius);
                SetColorsView();
                ApllyColorsChanges_Color2();
            }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!sorceRedy)
            {
                MessageBox.Show("Bitte wählenn sie vorerst eine vido Quelle (camera oder video file)", "Warnung");
                return;
            }

            ApllyColorsChanges_Color1();
            ApllyColorsChanges_Color2();

            this.Close();
        }

        private void ApllyColorsChanges_Color1()
        {
            Task.Factory.StartNew(() =>
            {
                this.mainForm.SetFilterColor_A(this._color1);
            });
        }

        private void ApllyColorsChanges_Color2()
        {
            Task.Factory.StartNew(() =>
            {
                this.mainForm.SetFilterColor_B(this._color2);
            });
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

        private void objectSizeC1TrackBar_Scroll(object sender, EventArgs e)
        {
            SetObjectSizeC1();
        }

        private void objectSizeC2TrackBar_Scroll(object sender, EventArgs e)
        {
            SetObjectSizeC2();
        }

        private void SetObjectSizeC1()
        {
            this._color1.MinObjectSize = this.objectSizeC1TrackBar.Value;
        }

        private void SetObjectSizeC2()
        {
            this._color2.MinObjectSize = this.objectSizeC2TrackBar.Value;
        }

        private void DrawRectangeSampleColor1()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            Graphics graphic = Graphics.FromImage(bmp);

            //Test data
            graphic.DrawRectangle(pen1Sample, 11, 11, 30, 30);
            RectangleC1PicBox.Image = bmp;
        }

        private void DrawRectangeSampleColor2()
        {
            Bitmap bmp = new Bitmap(pictureBox2.Width, pictureBox2.Height);

            Graphics graphic = Graphics.FromImage(bmp);

            //Test data
            graphic.DrawRectangle(pen2Sample, 11, 11, 30, 30);

            RectangleC2PicBox.Image = bmp;
        }

        private void ColorRectangleColor1_Click(object sender, EventArgs e)
        {
            if (colorDialog_Rec1.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog_Rec1.Color;
                this.mainForm.SetPenForColor1(color);

                DrawRectangeSampleColor1();
            }
        }

        private void ColorRectangleColor2_Click(object sender, EventArgs e)
        {
            if (colorDialog_Rec2.ShowDialog() == DialogResult.OK)
            {
                var color = colorDialog_Rec2.Color;
                this.mainForm.SetPenForColor2(color);

                DrawRectangeSampleColor2();
            }
        }

        private void reck1BorderTrackBar_Scroll(object sender, EventArgs e)
        {
            this.mainForm.SetPenForColor1(this.reck1BorderTrackBar.Value);

            DrawRectangeSampleColor1();
        }

        private void reck2BorderTrackBar_Scroll(object sender, EventArgs e)
        {
            this.mainForm.SetPenForColor2(this.reck2BorderTrackBar.Value);

            DrawRectangeSampleColor2();
        }
    }
}