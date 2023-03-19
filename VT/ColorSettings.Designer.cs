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
            Color1GroupBox = new GroupBox();
            label2 = new Label();
            objectSizeC1TrackBar = new TrackBar();
            label7 = new Label();
            radiusC1TrackBar = new TrackBar();
            stratTrackC1CheckBox = new CheckBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            Color1SetBtn = new Button();
            label8 = new Label();
            Color2SetBtn = new Button();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            stratTrackC2CheckBox = new CheckBox();
            label9 = new Label();
            radiusC2TrackBar = new TrackBar();
            Color2GroupBox = new GroupBox();
            label3 = new Label();
            objectSizeC2TrackBar = new TrackBar();
            label10 = new Label();
            label11 = new Label();
            Color1GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)objectSizeC1TrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radiusC1TrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)radiusC2TrackBar).BeginInit();
            Color2GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)objectSizeC2TrackBar).BeginInit();
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
            // Color1GroupBox
            // 
            Color1GroupBox.Controls.Add(label2);
            Color1GroupBox.Controls.Add(objectSizeC1TrackBar);
            Color1GroupBox.Controls.Add(label7);
            Color1GroupBox.Controls.Add(radiusC1TrackBar);
            Color1GroupBox.Controls.Add(label1);
            Color1GroupBox.Controls.Add(stratTrackC1CheckBox);
            Color1GroupBox.Controls.Add(pictureBox3);
            Color1GroupBox.Controls.Add(pictureBox2);
            Color1GroupBox.Controls.Add(pictureBox1);
            Color1GroupBox.Controls.Add(Color1SetBtn);
            Color1GroupBox.Location = new Point(9, 12);
            Color1GroupBox.Name = "Color1GroupBox";
            Color1GroupBox.Size = new Size(188, 398);
            Color1GroupBox.TabIndex = 21;
            Color1GroupBox.TabStop = false;
            Color1GroupBox.Text = "Farbe 1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 276);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 33;
            label2.Text = "Min. Objekt Grösse";
            // 
            // objectSizeC1TrackBar
            // 
            objectSizeC1TrackBar.Location = new Point(6, 297);
            objectSizeC1TrackBar.Maximum = 50;
            objectSizeC1TrackBar.Minimum = 1;
            objectSizeC1TrackBar.Name = "objectSizeC1TrackBar";
            objectSizeC1TrackBar.Size = new Size(176, 45);
            objectSizeC1TrackBar.TabIndex = 32;
            objectSizeC1TrackBar.Value = 1;
            objectSizeC1TrackBar.Scroll += objectSizeC1TrackBar_Scroll;
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
            Color2GroupBox.Controls.Add(label3);
            Color2GroupBox.Controls.Add(objectSizeC2TrackBar);
            Color2GroupBox.Controls.Add(pictureBox6);
            Color2GroupBox.Controls.Add(pictureBox5);
            Color2GroupBox.Controls.Add(pictureBox4);
            Color2GroupBox.Controls.Add(label10);
            Color2GroupBox.Controls.Add(label11);
            Color2GroupBox.Controls.Add(radiusC2TrackBar);
            Color2GroupBox.Controls.Add(label9);
            Color2GroupBox.Controls.Add(stratTrackC2CheckBox);
            Color2GroupBox.Controls.Add(Color2SetBtn);
            Color2GroupBox.Location = new Point(316, 12);
            Color2GroupBox.Name = "Color2GroupBox";
            Color2GroupBox.RightToLeft = RightToLeft.Yes;
            Color2GroupBox.Size = new Size(188, 398);
            Color2GroupBox.TabIndex = 22;
            Color2GroupBox.TabStop = false;
            Color2GroupBox.Text = "Farbe 2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 276);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 34;
            label3.Text = "Min. Objekt Grösse";
            // 
            // objectSizeC2TrackBar
            // 
            objectSizeC2TrackBar.Location = new Point(6, 297);
            objectSizeC2TrackBar.Maximum = 50;
            objectSizeC2TrackBar.Minimum = 1;
            objectSizeC2TrackBar.Name = "objectSizeC2TrackBar";
            objectSizeC2TrackBar.RightToLeft = RightToLeft.No;
            objectSizeC2TrackBar.Size = new Size(176, 45);
            objectSizeC2TrackBar.TabIndex = 33;
            objectSizeC2TrackBar.Value = 1;
            objectSizeC2TrackBar.Scroll += objectSizeC2TrackBar_Scroll;
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
            Controls.Add(okBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ColorSettings";
            Text = "ColorSettings";
            Color1GroupBox.ResumeLayout(false);
            Color1GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)objectSizeC1TrackBar).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)objectSizeC2TrackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColorDialog colorDialog_C1;
        private ColorDialog colorDialog_C2;
        private Label label1;
        private Button okBtn;
        private GroupBox Color1GroupBox;
        private CheckBox stratTrackC1CheckBox;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button Color1SetBtn;
        private Label label7;
        private TrackBar radiusC1TrackBar;
        private Label label8;
        private Button Color2SetBtn;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private CheckBox stratTrackC2CheckBox;
        private Label label9;
        private TrackBar radiusC2TrackBar;
        private GroupBox Color2GroupBox;
        private Label label10;
        private Label label11;
        private Label label2;
        private TrackBar objectSizeC1TrackBar;
        private Label label3;
        private TrackBar objectSizeC2TrackBar;
    }
}