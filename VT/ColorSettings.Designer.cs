namespace VT
{
    partial class ColorSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorSettings));
            colorDialog_C1 = new ColorDialog();
            colorDialog_C2 = new ColorDialog();
            label1 = new Label();
            okBtn = new Button();
            label2 = new Label();
            Color1GroupBox = new GroupBox();
            label7 = new Label();
            radiusC1TrackBar = new TrackBar();
            label4 = new Label();
            label3 = new Label();
            MinHeightC1TxtBox = new TextBox();
            MinWidthC1TxtBox = new TextBox();
            stratTrackC1CheckBox = new CheckBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            radiusC1Btn = new Button();
            Color1SetBtn = new Button();
            label8 = new Label();
            Color2SetBtn = new Button();
            radiusC2Btn = new Button();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            stratTrackC2CheckBox = new CheckBox();
            MinWidthC2TxtBox = new TextBox();
            MinHeightC2TxtBox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            radiusC2TrackBar = new TrackBar();
            Color2GroupBox = new GroupBox();
            label10 = new Label();
            label11 = new Label();
            Color1GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)radiusC1TrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radiusC2TrackBar).BeginInit();
            Color2GroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(129, 13);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Radius";
            // 
            // okBtn
            // 
            okBtn.Location = new Point(204, 366);
            okBtn.Name = "okBtn";
            okBtn.Size = new Size(104, 45);
            okBtn.TabIndex = 7;
            okBtn.Text = "OK";
            okBtn.UseVisualStyleBackColor = true;
            okBtn.Click += okBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 331);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 18;
            label2.Text = "Min. Objektgrösse";
            // 
            // Color1GroupBox
            // 
            Color1GroupBox.Controls.Add(label7);
            Color1GroupBox.Controls.Add(radiusC1TrackBar);
            Color1GroupBox.Controls.Add(label4);
            Color1GroupBox.Controls.Add(label3);
            Color1GroupBox.Controls.Add(MinHeightC1TxtBox);
            Color1GroupBox.Controls.Add(label1);
            Color1GroupBox.Controls.Add(MinWidthC1TxtBox);
            Color1GroupBox.Controls.Add(stratTrackC1CheckBox);
            Color1GroupBox.Controls.Add(pictureBox3);
            Color1GroupBox.Controls.Add(pictureBox2);
            Color1GroupBox.Controls.Add(pictureBox1);
            Color1GroupBox.Controls.Add(radiusC1Btn);
            Color1GroupBox.Controls.Add(Color1SetBtn);
            Color1GroupBox.Location = new Point(9, 12);
            Color1GroupBox.Name = "Color1GroupBox";
            Color1GroupBox.Size = new Size(188, 398);
            Color1GroupBox.TabIndex = 21;
            Color1GroupBox.TabStop = false;
            Color1GroupBox.Text = "Farbe 1";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(157, 31);
            label7.Name = "label7";
            label7.Size = new Size(25, 15);
            label7.TabIndex = 31;
            label7.Text = "255";
            // 
            // radiusC1TrackBar
            // 
            radiusC1TrackBar.Location = new Point(126, 31);
            radiusC1TrackBar.Maximum = 255;
            radiusC1TrackBar.Name = "radiusC1TrackBar";
            radiusC1TrackBar.Orientation = Orientation.Vertical;
            radiusC1TrackBar.Size = new Size(45, 160);
            radiusC1TrackBar.TabIndex = 10;
            radiusC1TrackBar.TickFrequency = 10;
            radiusC1TrackBar.Scroll += radiusC1TrackBar_Scroll;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 335);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 30;
            label4.Text = "Höhe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 301);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 29;
            label3.Text = "Breite";
            // 
            // MinHeightC1TxtBox
            // 
            MinHeightC1TxtBox.Location = new Point(85, 331);
            MinHeightC1TxtBox.Name = "MinHeightC1TxtBox";
            MinHeightC1TxtBox.PlaceholderText = "pix";
            MinHeightC1TxtBox.Size = new Size(60, 23);
            MinHeightC1TxtBox.TabIndex = 28;
            MinHeightC1TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 1";
            MinHeightC1TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // MinWidthC1TxtBox
            // 
            MinWidthC1TxtBox.Location = new Point(85, 297);
            MinWidthC1TxtBox.Name = "MinWidthC1TxtBox";
            MinWidthC1TxtBox.PlaceholderText = "pix";
            MinWidthC1TxtBox.Size = new Size(60, 23);
            MinWidthC1TxtBox.TabIndex = 27;
            MinWidthC1TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 1";
            MinWidthC1TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // stratTrackC1CheckBox
            // 
            stratTrackC1CheckBox.AutoSize = true;
            stratTrackC1CheckBox.Location = new Point(20, 359);
            stratTrackC1CheckBox.Name = "stratTrackC1CheckBox";
            stratTrackC1CheckBox.Size = new Size(94, 19);
            stratTrackC1CheckBox.TabIndex = 26;
            stratTrackC1CheckBox.Text = "StratTracking";
            stratTrackC1CheckBox.UseVisualStyleBackColor = true;
            stratTrackC1CheckBox.CheckedChanged += stratTrackC1CheckBox_CheckedChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(20, 141);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 50);
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(20, 85);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 50);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // radiusC1Btn
            // 
            radiusC1Btn.Location = new Point(20, 278);
            radiusC1Btn.Name = "radiusC1Btn";
            radiusC1Btn.Size = new Size(59, 60);
            radiusC1Btn.TabIndex = 22;
            radiusC1Btn.Text = "Setzen";
            radiusC1Btn.UseVisualStyleBackColor = true;
            radiusC1Btn.Click += radiusC1Btn_Click;
            // 
            // Color1SetBtn
            // 
            Color1SetBtn.Location = new Point(20, 197);
            Color1SetBtn.Name = "Color1SetBtn";
            Color1SetBtn.Size = new Size(125, 52);
            Color1SetBtn.TabIndex = 20;
            Color1SetBtn.Text = "Farbe 1 Einstellen";
            Color1SetBtn.UseVisualStyleBackColor = true;
            Color1SetBtn.Click += Color1SetBtn_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(169, 182);
            label8.Name = "label8";
            label8.Size = new Size(13, 15);
            label8.TabIndex = 32;
            label8.Text = "0";
            // 
            // Color2SetBtn
            // 
            Color2SetBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Color2SetBtn.Location = new Point(45, 197);
            Color2SetBtn.Name = "Color2SetBtn";
            Color2SetBtn.Size = new Size(125, 52);
            Color2SetBtn.TabIndex = 1;
            Color2SetBtn.Text = "Farbe 2 Einstellen";
            Color2SetBtn.UseVisualStyleBackColor = true;
            Color2SetBtn.Click += Color2SetBtn_Click;
            // 
            // radiusC2Btn
            // 
            radiusC2Btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radiusC2Btn.Location = new Point(110, 278);
            radiusC2Btn.Name = "radiusC2Btn";
            radiusC2Btn.Size = new Size(60, 60);
            radiusC2Btn.TabIndex = 6;
            radiusC2Btn.Text = "Setzen";
            radiusC2Btn.UseVisualStyleBackColor = true;
            radiusC2Btn.Click += radiusC2Btn_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox4.Location = new Point(70, 29);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 50);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Location = new Point(70, 85);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(100, 50);
            pictureBox5.TabIndex = 12;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox6.Location = new Point(70, 141);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(100, 50);
            pictureBox6.TabIndex = 13;
            pictureBox6.TabStop = false;
            // 
            // stratTrackC2CheckBox
            // 
            stratTrackC2CheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            stratTrackC2CheckBox.AutoSize = true;
            stratTrackC2CheckBox.CheckAlign = ContentAlignment.MiddleRight;
            stratTrackC2CheckBox.Location = new Point(73, 359);
            stratTrackC2CheckBox.Name = "stratTrackC2CheckBox";
            stratTrackC2CheckBox.Size = new Size(97, 19);
            stratTrackC2CheckBox.TabIndex = 15;
            stratTrackC2CheckBox.Text = "Strat Tracking";
            stratTrackC2CheckBox.UseVisualStyleBackColor = true;
            stratTrackC2CheckBox.CheckedChanged += stratTrackC2CheckBox_CheckedChanged;
            // 
            // MinWidthC2TxtBox
            // 
            MinWidthC2TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinWidthC2TxtBox.Location = new Point(45, 297);
            MinWidthC2TxtBox.Name = "MinWidthC2TxtBox";
            MinWidthC2TxtBox.PlaceholderText = "pix";
            MinWidthC2TxtBox.Size = new Size(60, 23);
            MinWidthC2TxtBox.TabIndex = 17;
            MinWidthC2TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 2";
            MinWidthC2TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // MinHeightC2TxtBox
            // 
            MinHeightC2TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinHeightC2TxtBox.Location = new Point(45, 331);
            MinHeightC2TxtBox.Name = "MinHeightC2TxtBox";
            MinHeightC2TxtBox.PlaceholderText = "pix";
            MinHeightC2TxtBox.Size = new Size(60, 23);
            MinHeightC2TxtBox.TabIndex = 20;
            MinHeightC2TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 2";
            MinHeightC2TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 301);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 31;
            label6.Text = "Breite";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 335);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 32;
            label5.Text = "Höhe";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 13);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 32;
            label9.Text = "Radius";
            // 
            // radiusC2TrackBar
            // 
            radiusC2TrackBar.Location = new Point(33, 31);
            radiusC2TrackBar.Maximum = 255;
            radiusC2TrackBar.Name = "radiusC2TrackBar";
            radiusC2TrackBar.Orientation = Orientation.Vertical;
            radiusC2TrackBar.Size = new Size(45, 160);
            radiusC2TrackBar.TabIndex = 33;
            radiusC2TrackBar.TickFrequency = 10;
            radiusC2TrackBar.TickStyle = TickStyle.TopLeft;
            radiusC2TrackBar.Scroll += radiusC2TrackBar_Scroll;
            // 
            // Color2GroupBox
            // 
            Color2GroupBox.Controls.Add(pictureBox6);
            Color2GroupBox.Controls.Add(pictureBox5);
            Color2GroupBox.Controls.Add(pictureBox4);
            Color2GroupBox.Controls.Add(label10);
            Color2GroupBox.Controls.Add(label11);
            Color2GroupBox.Controls.Add(radiusC2TrackBar);
            Color2GroupBox.Controls.Add(label9);
            Color2GroupBox.Controls.Add(label5);
            Color2GroupBox.Controls.Add(label6);
            Color2GroupBox.Controls.Add(MinHeightC2TxtBox);
            Color2GroupBox.Controls.Add(MinWidthC2TxtBox);
            Color2GroupBox.Controls.Add(stratTrackC2CheckBox);
            Color2GroupBox.Controls.Add(radiusC2Btn);
            Color2GroupBox.Controls.Add(Color2SetBtn);
            Color2GroupBox.Location = new Point(316, 12);
            Color2GroupBox.Name = "Color2GroupBox";
            Color2GroupBox.RightToLeft = RightToLeft.Yes;
            Color2GroupBox.Size = new Size(188, 398);
            Color2GroupBox.TabIndex = 22;
            Color2GroupBox.TabStop = false;
            Color2GroupBox.Text = "Farbe 2";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(14, 170);
            label10.Name = "label10";
            label10.Size = new Size(13, 15);
            label10.TabIndex = 34;
            label10.Text = "0";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(10, 31);
            label11.Name = "label11";
            label11.Size = new Size(25, 15);
            label11.TabIndex = 33;
            label11.Text = "255";
            // 
            // ColorSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 422);
            Controls.Add(label8);
            Controls.Add(Color2GroupBox);
            Controls.Add(Color1GroupBox);
            Controls.Add(label2);
            Controls.Add(okBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ColorSettings";
            Text = "ColorSettings";
            Color1GroupBox.ResumeLayout(false);
            Color1GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)radiusC1TrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)radiusC2TrackBar).EndInit();
            Color2GroupBox.ResumeLayout(false);
            Color2GroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColorDialog colorDialog_C1;
        private ColorDialog colorDialog_C2;
        private Label label1;
        private Button okBtn;
        private Label label2;
        private GroupBox Color1GroupBox;
        private TextBox MinHeightC1TxtBox;
        private TextBox MinWidthC1TxtBox;
        private CheckBox stratTrackC1CheckBox;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button radiusC1Btn;
        private Button Color1SetBtn;
        private Label label4;
        private Label label3;
        private Label label7;
        private TrackBar radiusC1TrackBar;
        private Label label8;
        private Button Color2SetBtn;
        private Button radiusC2Btn;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private CheckBox stratTrackC2CheckBox;
        private TextBox MinWidthC2TxtBox;
        private TextBox MinHeightC2TxtBox;
        private Label label6;
        private Label label5;
        private Label label9;
        private TrackBar radiusC2TrackBar;
        private GroupBox Color2GroupBox;
        private Label label10;
        private Label label11;
    }
}