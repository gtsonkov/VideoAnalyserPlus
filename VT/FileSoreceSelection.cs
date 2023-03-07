using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VT
{
    public partial class FileSoreceSelection : Form
    {
        private string filePath = string.Empty;
        public FileSoreceSelection()
        {
            InitializeComponent();
            this.OkBtn.Enabled = !String.IsNullOrEmpty(filePath);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            var mainForm = (MainForm)Application.OpenForms["MainForm"];
            mainForm._file = this.filePath;
            if (mainForm.deviceIndex > -1)
            {
                mainForm.SorceChange();
                mainForm.deviceIndex = -1;
            }

            this.Close();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog(Owner); // Show Explorer browser dialog.


            if (result == DialogResult.OK) // Get result after click OK
            {
                this.filePath = openFileDialog1.FileName;
                this.OkBtn.Enabled = !String.IsNullOrEmpty(filePath);
            }
        }
    }
}
