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
    public partial class Add_Password_Form : Form
    {
        public Credential credential = null;
        public String password {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                textBoxPassword.Text = value;
            }
        }
        private String _password;

        public Add_Password_Form()
        {
            InitializeComponent();
            dateTimePickerCreatedDate.Value = DateTime.Now;
        }
        public Add_Password_Form(Credential credential)
        {
            InitializeComponent();
            this.credential = credential;
            try
            {
                textBoxEmail.Text = credential.Email;
                textBoxNote.Text = credential.Note;
                textBoxPassword.Text = credential.Password;
                textBoxPincode.Text = credential.Pincode;
                textBoxURL.Text = credential.URL;
                textBoxService.Text = credential.ServiceName;
                dateTimePickerCreatedDate.Value = credential.DateCreated;
                CheckBoxExpire.Checked = credential.Expires;
                dateTimePickerExpiryDate.Value = credential.ExpiryDate;
            }
            catch (Exception e)
            {
                //Null reference
                Console.WriteLine(e);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (credential == null)
            {
                credential = new Credential(textBoxService.Text, textBoxEmail.Text, textBoxPassword.Text, textBoxPincode.Text, textBoxNote.Text, 0, textBoxURL.Text, CheckBoxExpire.Checked, dateTimePickerExpiryDate.Value);
            }
            else
            {
                credential.ServiceName = textBoxService.Text;
                credential.Email = textBoxEmail.Text;
                credential.Password = textBoxPassword.Text;
                credential.Pincode = textBoxPincode.Text;
                credential.URL = textBoxURL.Text;
                credential.DateCreated = dateTimePickerCreatedDate.Value;
                credential.Expires = CheckBoxExpire.Checked;
                credential.ExpiryDate = dateTimePickerExpiryDate.Value;
                credential.Note = textBoxNote.Text;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonShowHidePincode_Click(object sender, EventArgs e)
        {
            if (textBoxPincode.UseSystemPasswordChar)
            {
                buttonShowHidePincode.ImageIndex = 1;
                textBoxPincode.UseSystemPasswordChar = false;
            }
            else
            {
                buttonShowHidePincode.ImageIndex = 2;
                textBoxPincode.UseSystemPasswordChar = true;
            }
        }

        private void buttonCopyPincode_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, textBoxPincode.Text);
        }
    }
}
