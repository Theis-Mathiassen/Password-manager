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
    public partial class PasswordShow : Form
    {
        Credential credential;
        public PasswordShow(Credential credential)
        {
            InitializeComponent();
            this.credential = credential;
            if (credential.Email != null)
            {
                textBoxEmail.Text = credential.Email;
            }
            if (credential.Note != null)
            {
                textBoxNote.Text = credential.Note;
            }
            if (credential.Password != null)
            {
                textBoxPassword.Text = credential.Password;
            }
            if (credential.Pincode != null)
            {
                textBoxPincode.Text = credential.Pincode;
            }
            if (credential.ServiceName != null)
            {
                textBoxWebService.Text = credential.ServiceName;
            }
            if (credential.DateCreated != null)
            {
                dateTimePicker1.Value = credential.DateCreated;
            }
            if (credential.ExpiryDate != null)
            {
                dateTimePickerExpiryDate.Value = credential.ExpiryDate;
            }

            
        }

        private void CheckBoxExpire_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxExpire.Checked)
            {
                dateTimePickerExpiryDate.Enabled = true;
            }
            else
            {
                dateTimePickerExpiryDate.Enabled = false;
            }
        }

        private void buttonConfigurePassword_Click(object sender, EventArgs e)
        {
            using (PasswordConfigoration passwordConfigoration = new PasswordConfigoration(textBoxPassword.Text))
            {
                if (passwordConfigoration.ShowDialog() == DialogResult.OK)
                {
                    textBoxPassword.Text = passwordConfigoration.Password;
                }
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CopyPasswordToClipboard.Text = "Copy";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void ShowPasswordButton_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
            {
                ShowPasswordButton.Text = "Hide";
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                ShowPasswordButton.Text = "Show";
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void CopyPasswordToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBoxPassword.Text);
            CopyPasswordToClipboard.Text = "Copied";
        }

        private void textBoxPincode_TextChanged(object sender, EventArgs e)
        {
            CopyPasswordToClipboard.Text = "Copy";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (textBoxPincode.UseSystemPasswordChar)
            {
                ShowPincodeButton.Text = "Hide";
                textBoxPincode.UseSystemPasswordChar = false;
            }
            else
            {
                ShowPincodeButton.Text = "Show";
                textBoxPincode.UseSystemPasswordChar = true;
            }
        }

        private void CopyPincodeToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBoxPincode.Text);
            CopyPasswordToClipboard.Text = "Copied";
        }
    }
}
