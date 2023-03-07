namespace VT
{
    partial class FileSoreceSelection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSoreceSelection));
            OkBtn = new Button();
            textBox1 = new TextBox();
            BrowseBtn = new Button();
            SuspendLayout();
            // 
            // OkBtn
            // 
            OkBtn.Location = new Point(289, 101);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(75, 23);
            OkBtn.TabIndex = 0;
            OkBtn.Text = "Ok";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(296, 23);
            textBox1.TabIndex = 1;
            // 
            // BrowseBtn
            // 
            BrowseBtn.Location = new Point(314, 72);
            BrowseBtn.Name = "BrowseBtn";
            BrowseBtn.Size = new Size(75, 23);
            BrowseBtn.TabIndex = 2;
            BrowseBtn.Text = "Suchen";
            BrowseBtn.UseVisualStyleBackColor = true;
            BrowseBtn.Click += BrowseBtn_Click;
            // 
            // FileSoreceSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(425, 304);
            Controls.Add(BrowseBtn);
            Controls.Add(textBox1);
            Controls.Add(OkBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FileSoreceSelection";
            Text = "Dateisuchen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkBtn;
        private TextBox textBox1;
        private Button BrowseBtn;
    }
}