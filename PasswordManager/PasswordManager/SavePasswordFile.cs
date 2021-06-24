using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class SavePasswordFile : Form
    {
        public string FilePath;
        public SavePasswordFile()
        {
            InitializeComponent();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            FilePath = textBoxFilePath.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
        private void textBoxFilePath_FocusEnter(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
            {
                SaveFileDialog.InitialDirectory = "c:\\";
                SaveFileDialog.Filter = "JSON files (*.JSON)|*.JSON";
                SaveFileDialog.FilterIndex = 2;
                SaveFileDialog.RestoreDirectory = true;

                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    textBoxFilePath.Text = SaveFileDialog.FileName;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
