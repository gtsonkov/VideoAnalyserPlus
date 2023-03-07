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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCaptureDevice));
            deviceList = new ComboBox();
            refreshBtn = new Button();
            OkBtn = new Button();
            SuspendLayout();
            // 
            // deviceList
            // 
            deviceList.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceList.FormattingEnabled = true;
            deviceList.Location = new Point(12, 23);
            deviceList.Name = "deviceList";
            deviceList.Size = new Size(393, 23);
            deviceList.TabIndex = 0;
            deviceList.SelectedIndexChanged += deviceList_SelectedIndexChanged;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(12, 56);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(89, 31);
            refreshBtn.TabIndex = 1;
            refreshBtn.Text = "Aktualisieren";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // OkBtn
            // 
            OkBtn.Location = new Point(424, 18);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(73, 32);
            OkBtn.TabIndex = 2;
            OkBtn.Text = "Ok";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // SelectCaptureDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 245);
            Controls.Add(OkBtn);
            Controls.Add(refreshBtn);
            Controls.Add(deviceList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectCaptureDevice";
            Text = "Aufnahmegerät konfigurieren";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox deviceList;
        private Button refreshBtn;
        private Button OkBtn;
    }
}