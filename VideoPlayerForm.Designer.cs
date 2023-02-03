﻿namespace VT
{
    partial class VideoPlayerForm
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
            this.components = new System.ComponentModel.Container();
            this.screenBox1 = new System.Windows.Forms.PictureBox();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.PauseBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.screenBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // screenBox1
            // 
            this.screenBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.screenBox1.Location = new System.Drawing.Point(1, 1);
            this.screenBox1.Name = "screenBox1";
            this.screenBox1.Size = new System.Drawing.Size(794, 479);
            this.screenBox1.TabIndex = 0;
            this.screenBox1.TabStop = false;
            // 
            // PlayBtn
            // 
            this.PlayBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PlayBtn.Location = new System.Drawing.Point(274, 495);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(75, 23);
            this.PlayBtn.TabIndex = 1;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // PauseBtn
            // 
            this.PauseBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PauseBtn.Location = new System.Drawing.Point(365, 495);
            this.PauseBtn.Name = "PauseBtn";
            this.PauseBtn.Size = new System.Drawing.Size(75, 23);
            this.PauseBtn.TabIndex = 2;
            this.PauseBtn.Text = "Pause";
            this.PauseBtn.UseVisualStyleBackColor = true;
            this.PauseBtn.Click += new System.EventHandler(this.PauseBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.StopBtn.Location = new System.Drawing.Point(456, 495);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(75, 23);
            this.StopBtn.TabIndex = 3;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // playTimer
            // 
            this.playTimer.Interval = 24;
            this.playTimer.Tick += new System.EventHandler(this.playTimer_Tick);
            // 
            // VideoPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 536);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.PauseBtn);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.screenBox1);
            this.Name = "VideoPlayerForm";
            this.Text = "VideoPlayerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VideoPlayerForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.screenBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox screenBox1;
        private Button PlayBtn;
        private Button PauseBtn;
        private Button StopBtn;
        private System.Windows.Forms.Timer playTimer;
    }
}