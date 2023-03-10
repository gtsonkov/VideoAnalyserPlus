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
            this.filePath = this.fileNameTxtBox.Text;

            var mainForm = (MainForm)Application.OpenForms["MainForm"];
            mainForm._file = this.filePath;

            //To Do: If video sorce selected, remove existing CaptureDevice in mainForm

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