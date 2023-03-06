namespace VT
{
    partial class MainForm
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
            screenBox1 = new PictureBox();
            PlayBtn = new Button();
            PauseBtn = new Button();
            StopBtn = new Button();
            menuStrip1 = new MenuStrip();
            sorceToolStripMenuItem = new ToolStripMenuItem();
            kameraToolStripMenuItem = new ToolStripMenuItem();
            videodateiToolStripMenuItem = new ToolStripMenuItem();
            prozesseinstellungenToolStripMenuItem = new ToolStripMenuItem();
            hilfeToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)screenBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // screenBox1
            // 
            screenBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            screenBox1.Location = new Point(1, 26);
            screenBox1.Name = "screenBox1";
            screenBox1.Size = new Size(794, 454);
            screenBox1.TabIndex = 0;
            screenBox1.TabStop = false;
            // 
            // PlayBtn
            // 
            PlayBtn.Anchor = AnchorStyles.Bottom;
            PlayBtn.Location = new Point(274, 495);
            PlayBtn.Name = "PlayBtn";
            PlayBtn.Size = new Size(75, 23);
            PlayBtn.TabIndex = 1;
            PlayBtn.Text = "Play";
            PlayBtn.UseVisualStyleBackColor = true;
            PlayBtn.Click += PlayBtn_Click;
            // 
            // PauseBtn
            // 
            PauseBtn.Anchor = AnchorStyles.Bottom;
            PauseBtn.Location = new Point(365, 495);
            PauseBtn.Name = "PauseBtn";
            PauseBtn.Size = new Size(75, 23);
            PauseBtn.TabIndex = 2;
            PauseBtn.Text = "Pause";
            PauseBtn.UseVisualStyleBackColor = true;
            PauseBtn.Click += PauseBtn_Click;
            // 
            // StopBtn
            // 
            StopBtn.Anchor = AnchorStyles.Bottom;
            StopBtn.Location = new Point(456, 495);
            StopBtn.Name = "StopBtn";
            StopBtn.Size = new Size(75, 23);
            StopBtn.TabIndex = 3;
            StopBtn.Text = "Stop";
            StopBtn.UseVisualStyleBackColor = true;
            StopBtn.Click += StopBtn_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { sorceToolStripMenuItem, prozesseinstellungenToolStripMenuItem, hilfeToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(796, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // sorceToolStripMenuItem
            // 
            sorceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kameraToolStripMenuItem, videodateiToolStripMenuItem });
            sorceToolStripMenuItem.Name = "sorceToolStripMenuItem";
            sorceToolStripMenuItem.Size = new Size(48, 20);
            sorceToolStripMenuItem.Text = "Sorce";
            // 
            // kameraToolStripMenuItem
            // 
            kameraToolStripMenuItem.Name = "kameraToolStripMenuItem";
            kameraToolStripMenuItem.Size = new Size(180, 22);
            kameraToolStripMenuItem.Text = "Kamera";
            kameraToolStripMenuItem.Click += kameraToolStripMenuItem_Click;
            // 
            // videodateiToolStripMenuItem
            // 
            videodateiToolStripMenuItem.Name = "videodateiToolStripMenuItem";
            videodateiToolStripMenuItem.Size = new Size(180, 22);
            videodateiToolStripMenuItem.Text = "Videodatei";
            // 
            // prozesseinstellungenToolStripMenuItem
            // 
            prozesseinstellungenToolStripMenuItem.Name = "prozesseinstellungenToolStripMenuItem";
            prozesseinstellungenToolStripMenuItem.Size = new Size(129, 20);
            prozesseinstellungenToolStripMenuItem.Text = "Prozesseinstellungen";
            // 
            // hilfeToolStripMenuItem
            // 
            hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            hilfeToolStripMenuItem.Size = new Size(44, 20);
            hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // VideoPlayerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(796, 536);
            Controls.Add(StopBtn);
            Controls.Add(PauseBtn);
            Controls.Add(PlayBtn);
            Controls.Add(screenBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "VideoPlayerForm";
            FormClosing += VideoPlayerForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)screenBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox screenBox1;
        private Button PlayBtn;
        private Button PauseBtn;
        private Button StopBtn;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem sorceToolStripMenuItem;
        private ToolStripMenuItem kameraToolStripMenuItem;
        private ToolStripMenuItem videodateiToolStripMenuItem;
        private ToolStripMenuItem prozesseinstellungenToolStripMenuItem;
        private ToolStripMenuItem hilfeToolStripMenuItem;
    }
}