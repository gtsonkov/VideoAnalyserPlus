namespace VideoAnalyserPlus
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BrowseBtn = new Button();
            StartBtn = new Button();
            StopBtn = new Button();
            screenBox = new PictureBox();
            userCameraBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)screenBox).BeginInit();
            SuspendLayout();
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new Point(7, 63);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(125, 23);
            BrowseBtn.TabIndex = 0;
            BrowseBtn.Text = "Browse File";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // StartBtn
            // 
            StartBtn.Location = new Point(32, 101);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(75, 23);
            StartBtn.TabIndex = 1;
            StartBtn.Text = "Start";
            StartBtn.UseVisualStyleBackColor = true;
            StartBtn.Click += StartBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.Location = new Point(32, 139);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(75, 23);
            StopBtn.TabIndex = 2;
            StopBtn.Text = "Stop";
            StopBtn.UseVisualStyleBackColor = true;
            StopBtn.Click += StopBtn_Click;
            // 
            // screenBox
            // 
            screenBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            screenBox.Location = new Point(141, 2);
            screenBox.Name = "screenBox";
            screenBox.Size = new Size(512, 399);
            screenBox.TabIndex = 3;
            screenBox.TabStop = false;
            screenBox.Click += screenBox_Click;
            // 
            // userCameraBtn
            // 
            userCameraBtn.Location = new Point(7, 34);
            userCameraBtn.Name = "userCameraBtn";
            userCameraBtn.Size = new Size(125, 23);
            userCameraBtn.TabIndex = 4;
            userCameraBtn.Text = "Camera";
            userCameraBtn.UseVisualStyleBackColor = true;
            userCameraBtn.Click += userCameraBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(656, 403);
            Controls.Add(userCameraBtn);
            Controls.Add(screenBox);
            Controls.Add(StopBtn);
            Controls.Add(StartBtn);
            Controls.Add(BrowseBtn);
            MinimumSize = new Size(672, 442);
            Name = "MainForm";
            Text = "Video Analyser";
            ((System.ComponentModel.ISupportInitialize)screenBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BrowseBtn;
        private Button StartBtn;
        private Button StopBtn;
        private PictureBox screenBox;
        private Button userCameraBtn;
    }
}