namespace VT
{
    partial class SelectCaptureDevice
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
            comboBox1 = new ComboBox();
            refreshBtn = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(105, 58);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(393, 23);
            comboBox1.TabIndex = 0;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(529, 60);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(75, 23);
            refreshBtn.TabIndex = 1;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // SelectCaptureDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(refreshBtn);
            Controls.Add(comboBox1);
            Name = "SelectCaptureDevice";
            Text = "Aufnahmegerät konfigurieren";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBox1;
        private Button refreshBtn;
    }
}