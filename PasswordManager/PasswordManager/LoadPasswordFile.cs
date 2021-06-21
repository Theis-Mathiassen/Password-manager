using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class LoadPasswordFile : Form
    {
        private byte[][] PasswordHash;
        private string filePath;
        public LoadPasswordFile()
        {
            InitializeComponent();
        }

        public byte[][] getPassWordHash ()
        {
            return PasswordHash;
        }
        public string getFilePath ()
        {
            return filePath;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFilePath_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxFilePath_FocusEnter(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "JSON files (*.JSON)|*.JSON";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            filePath = textBoxFilePath.Text;
            PasswordHash = SecurityController.GetHashKeys(textBoxPassword.Text);
            if (File.Exists(filePath) && Path.GetExtension(filePath) == ".JSON")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                textBoxFilePath.Text = "Incorrect";
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
