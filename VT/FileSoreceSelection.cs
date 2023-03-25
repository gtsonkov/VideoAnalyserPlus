using Emgu.CV;
using Modules;

namespace VT
{
    public partial class FileSoreceSelection : Form
    {
        private string filePath = string.Empty;
        private VideoCapture selectedDevice;

        public FileSoreceSelection()
        {
            InitializeComponent();
            this.OkBtn.Enabled = !String.IsNullOrEmpty(filePath);
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.filePath = this.fileNameTxtBox.Text;

            var mainForm = (MainForm)Application.OpenForms["MainForm"];
            mainForm._file = this.filePath;

            if (this.filePath != string.Empty)
            {

                this.selectedDevice = new VideoCapture(this.filePath);

                mainForm.DisposePreviosSorce();

                mainForm.SetPayerWithVideoFile(this.selectedDevice, mainForm);
            }

            this.Close();
        }

        private void BrowseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            DialogResult result = openFileDialog1.ShowDialog(Owner); // Show Explorer browser dialog.


            if (result == DialogResult.OK) // Get result after click OK
            {
                this.fileNameTxtBox.Text = openFileDialog1.FileName;

                this.OkBtn.Enabled = !String.IsNullOrEmpty(this.fileNameTxtBox.Text);
            }
        }
    }
}