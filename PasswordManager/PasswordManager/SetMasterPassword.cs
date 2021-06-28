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
    public partial class SetMasterPassword : Form
    {
        public string password;
        public SetMasterPassword()
        {
            InitializeComponent();
        }

        private void SetMasterPassword_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonShowHidePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
            {
                buttonShowHidePassword.ImageIndex = 1;
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                buttonShowHidePassword.ImageIndex = 2;
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, textBoxPassword.Text);
        }

        private void buttonShowHideConfirmPassword_Click(object sender, EventArgs e)
        {
            if (textBoxConfirmPassword.UseSystemPasswordChar)
            {
                buttonShowHidePassword.ImageIndex = 1;
                textBoxConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                buttonShowHidePassword.ImageIndex = 2;
                textBoxConfirmPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonCopyConfirmPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, textBoxConfirmPassword.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            ComparePasswords();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == textBoxConfirmPassword.Text)
            {
                password = textBoxConfirmPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxConfirmPassword.Text != null)
            {
                ComparePasswords();
            }
            else
            {
                label3.Visible = false;
            }
        }

        private void ComparePasswords ()
        {
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
        }
    }
}
