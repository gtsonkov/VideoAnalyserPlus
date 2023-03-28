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
            label1 = new Label();
            label2 = new Label();
            resolutionsComboBox = new ComboBox();
            SuspendLayout();
            // 
            // deviceList
            // 
            deviceList.DropDownStyle = ComboBoxStyle.DropDownList;
            deviceList.FormattingEnabled = true;
            deviceList.Location = new Point(98, 23);
            deviceList.Name = "deviceList";
            deviceList.Size = new Size(393, 23);
            deviceList.TabIndex = 0;
            deviceList.SelectedIndexChanged += deviceList_SelectedIndexChanged;
            // 
            // refreshBtn
            // 
            refreshBtn.Location = new Point(394, 255);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(89, 31);
            refreshBtn.TabIndex = 1;
            refreshBtn.Text = "Aktualisieren";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += RefreshBtn_Click;
            // 
            // OkBtn
            // 
            OkBtn.Location = new Point(495, 255);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(89, 31);
            OkBtn.TabIndex = 2;
            OkBtn.Text = "Ok";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 27);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 4;
            label1.Text = "Gerät";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 63);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 5;
            label2.Text = "Auflösung";
            // 
            // resolutionsComboBox
            // 
            resolutionsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            resolutionsComboBox.FormattingEnabled = true;
            resolutionsComboBox.Location = new Point(98, 59);
            resolutionsComboBox.Name = "resolutionsComboBox";
            resolutionsComboBox.Size = new Size(153, 23);
            resolutionsComboBox.TabIndex = 6;
            resolutionsComboBox.SelectedIndexChanged += resolutionsComboBox_SelectedIndexChanged;
            // 
            // SelectCaptureDevice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(596, 298);
            Controls.Add(resolutionsComboBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OkBtn);
            Controls.Add(refreshBtn);
            Controls.Add(deviceList);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SelectCaptureDevice";
            Text = "Aufnahmegerät konfigurieren";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox deviceList;
        private Button refreshBtn;
        private Button OkBtn;
        private Label label1;
        private Label label2;
        private ComboBox resolutionsComboBox;
    }
}