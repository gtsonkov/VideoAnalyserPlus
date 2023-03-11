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
            Color2SetBtn = new Button();
            colorDialog_C1 = new ColorDialog();
            colorDialog_C2 = new ColorDialog();
            radiusC2TxtBox = new TextBox();
            label1 = new Label();
            radiusC2Btn = new Button();
            okBtn = new Button();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox6 = new PictureBox();
            stratTrackC2CheckBox = new CheckBox();
            label2 = new Label();
            MinWidthC2TxtBox = new TextBox();
            MinHeightC2TxtBox = new TextBox();
            Color1GroupBox = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            MinHeightC1TxtBox = new TextBox();
            MinWidthC1TxtBox = new TextBox();
            stratTrackC1CheckBox = new CheckBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            radiusC1Btn = new Button();
            radiusC1TxtBox = new TextBox();
            Color1SetBtn = new Button();
            Color2GroupBox = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            Color1GroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            Color2GroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // Color2SetBtn
            // 
            Color2SetBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Color2SetBtn.Location = new Point(45, 188);
            Color2SetBtn.Name = "Color2SetBtn";
            Color2SetBtn.Size = new Size(125, 52);
            Color2SetBtn.TabIndex = 1;
            Color2SetBtn.Text = "Farbe 2 Einstellen";
            Color2SetBtn.UseVisualStyleBackColor = true;
            Color2SetBtn.Click += Color2SetBtn_Click;
            // 
            // radiusC2TxtBox
            // 
            radiusC2TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radiusC2TxtBox.Location = new Point(45, 251);
            radiusC2TxtBox.Name = "radiusC2TxtBox";
            radiusC2TxtBox.Size = new Size(60, 23);
            radiusC2TxtBox.TabIndex = 3;
            radiusC2TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(235, 265);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 4;
            label1.Text = "Radius";
            // 
            // radiusC2Btn
            // 
            radiusC2Btn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            radiusC2Btn.Location = new Point(110, 269);
            radiusC2Btn.Name = "radiusC2Btn";
            radiusC2Btn.Size = new Size(60, 60);
            radiusC2Btn.TabIndex = 6;
            radiusC2Btn.Text = "Setzen";
            radiusC2Btn.UseVisualStyleBackColor = true;
            radiusC2Btn.Click += radiusC2Btn_Click;
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
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox4.Location = new Point(70, 20);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(100, 50);
            pictureBox4.TabIndex = 11;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Location = new Point(70, 76);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(100, 50);
            pictureBox5.TabIndex = 12;
            pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox6.Location = new Point(70, 132);
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
            stratTrackC2CheckBox.Location = new Point(73, 350);
            stratTrackC2CheckBox.Name = "stratTrackC2CheckBox";
            stratTrackC2CheckBox.Size = new Size(97, 19);
            stratTrackC2CheckBox.TabIndex = 15;
            stratTrackC2CheckBox.Text = "Strat Tracking";
            stratTrackC2CheckBox.UseVisualStyleBackColor = true;
            stratTrackC2CheckBox.CheckedChanged += stratTrackC2CheckBox_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(205, 321);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 18;
            label2.Text = "Min. Objektgrösse";
            // 
            // MinWidthC2TxtBox
            // 
            MinWidthC2TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            MinWidthC2TxtBox.Location = new Point(45, 288);
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
            MinHeightC2TxtBox.Location = new Point(45, 322);
            MinHeightC2TxtBox.Name = "MinHeightC2TxtBox";
            MinHeightC2TxtBox.PlaceholderText = "pix";
            MinHeightC2TxtBox.Size = new Size(60, 23);
            MinHeightC2TxtBox.TabIndex = 20;
            MinHeightC2TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 2";
            MinHeightC2TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // Color1GroupBox
            // 
            Color1GroupBox.Controls.Add(label4);
            Color1GroupBox.Controls.Add(label3);
            Color1GroupBox.Controls.Add(MinHeightC1TxtBox);
            Color1GroupBox.Controls.Add(MinWidthC1TxtBox);
            Color1GroupBox.Controls.Add(stratTrackC1CheckBox);
            Color1GroupBox.Controls.Add(pictureBox3);
            Color1GroupBox.Controls.Add(pictureBox2);
            Color1GroupBox.Controls.Add(pictureBox1);
            Color1GroupBox.Controls.Add(radiusC1Btn);
            Color1GroupBox.Controls.Add(radiusC1TxtBox);
            Color1GroupBox.Controls.Add(Color1SetBtn);
            Color1GroupBox.Location = new Point(9, 12);
            Color1GroupBox.Name = "Color1GroupBox";
            Color1GroupBox.Size = new Size(188, 378);
            Color1GroupBox.TabIndex = 21;
            Color1GroupBox.TabStop = false;
            Color1GroupBox.Text = "Farbe 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(148, 326);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 30;
            label4.Text = "Höhe";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 292);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 29;
            label3.Text = "Breite";
            // 
            // MinHeightC1TxtBox
            // 
            MinHeightC1TxtBox.Location = new Point(85, 322);
            MinHeightC1TxtBox.Name = "MinHeightC1TxtBox";
            MinHeightC1TxtBox.PlaceholderText = "pix";
            MinHeightC1TxtBox.Size = new Size(60, 23);
            MinHeightC1TxtBox.TabIndex = 28;
            MinHeightC1TxtBox.Tag = "Minimale Pixelzahl der gesuchte Objektbreite mit Farbe 1";
            MinHeightC1TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // MinWidthC1TxtBox
            // 
            MinWidthC1TxtBox.Location = new Point(85, 288);
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
            stratTrackC1CheckBox.Location = new Point(20, 350);
            stratTrackC1CheckBox.Name = "stratTrackC1CheckBox";
            stratTrackC1CheckBox.Size = new Size(94, 19);
            stratTrackC1CheckBox.TabIndex = 26;
            stratTrackC1CheckBox.Text = "StratTracking";
            stratTrackC1CheckBox.UseVisualStyleBackColor = true;
            stratTrackC1CheckBox.CheckedChanged += stratTrackC1CheckBox_CheckedChanged;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(20, 132);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(100, 50);
            pictureBox3.TabIndex = 25;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(20, 76);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 50);
            pictureBox2.TabIndex = 24;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.TabIndex = 23;
            pictureBox1.TabStop = false;
            // 
            // radiusC1Btn
            // 
            radiusC1Btn.Location = new Point(20, 269);
            radiusC1Btn.Name = "radiusC1Btn";
            radiusC1Btn.Size = new Size(59, 60);
            radiusC1Btn.TabIndex = 22;
            radiusC1Btn.Text = "Setzen";
            radiusC1Btn.UseVisualStyleBackColor = true;
            radiusC1Btn.Click += radiusC1Btn_Click;
            // 
            // radiusC1TxtBox
            // 
            radiusC1TxtBox.Location = new Point(85, 251);
            radiusC1TxtBox.Name = "radiusC1TxtBox";
            radiusC1TxtBox.Size = new Size(60, 23);
            radiusC1TxtBox.TabIndex = 21;
            radiusC1TxtBox.KeyPress += CheckUserInput_KeyPressed;
            // 
            // Color1SetBtn
            // 
            Color1SetBtn.Location = new Point(20, 188);
            Color1SetBtn.Name = "Color1SetBtn";
            Color1SetBtn.Size = new Size(125, 52);
            Color1SetBtn.TabIndex = 20;
            Color1SetBtn.Text = "Farbe 1 Einstellen";
            Color1SetBtn.UseVisualStyleBackColor = true;
            Color1SetBtn.Click += Color1SetBtn_Click;
            // 
            // Color2GroupBox
            // 
            Color2GroupBox.Controls.Add(label5);
            Color2GroupBox.Controls.Add(label6);
            Color2GroupBox.Controls.Add(MinHeightC2TxtBox);
            Color2GroupBox.Controls.Add(MinWidthC2TxtBox);
            Color2GroupBox.Controls.Add(stratTrackC2CheckBox);
            Color2GroupBox.Controls.Add(pictureBox6);
            Color2GroupBox.Controls.Add(pictureBox5);
            Color2GroupBox.Controls.Add(pictureBox4);
            Color2GroupBox.Controls.Add(radiusC2Btn);
            Color2GroupBox.Controls.Add(radiusC2TxtBox);
            Color2GroupBox.Controls.Add(Color2SetBtn);
            Color2GroupBox.Location = new Point(316, 12);
            Color2GroupBox.Name = "Color2GroupBox";
            Color2GroupBox.Size = new Size(188, 378);
            Color2GroupBox.TabIndex = 22;
            Color2GroupBox.TabStop = false;
            Color2GroupBox.Text = "Farbe 2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(5, 326);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 32;
            label5.Text = "Höhe";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 292);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 31;
            label6.Text = "Breite";
            // 
            // ColorSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(513, 422);
            Controls.Add(Color2GroupBox);
            Controls.Add(Color1GroupBox);
            Controls.Add(label2);
            Controls.Add(okBtn);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ColorSettings";
            Text = "ColorSettings";
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            Color1GroupBox.ResumeLayout(false);
            Color1GroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            Color2GroupBox.ResumeLayout(false);
            Color2GroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Color2SetBtn;
        private ColorDialog colorDialog_C1;
        private ColorDialog colorDialog_C2;
        private TextBox radiusC2TxtBox;
        private Label label1;
        private Button radiusC2Btn;
        private Button okBtn;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        private CheckBox stratTrackC2CheckBox;
        private Label label2;
        private TextBox MinWidthC2TxtBox;
        private TextBox MinHeightC2TxtBox;
        private GroupBox Color1GroupBox;
        private TextBox MinHeightC1TxtBox;
        private TextBox MinWidthC1TxtBox;
        private CheckBox stratTrackC1CheckBox;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button radiusC1Btn;
        private TextBox radiusC1TxtBox;
        private Button Color1SetBtn;
        private GroupBox Color2GroupBox;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
    }
}