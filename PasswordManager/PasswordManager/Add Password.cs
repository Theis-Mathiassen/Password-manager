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
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Program.passwordBook.GetNewId();
            if (CheckBoxExpire.Checked)
            {
                Program.passwordBook.AddPassword(textBoxWebService.Text, textBoxEmail.Text, textBoxPassword.Text, textBoxPincode.Text, textBoxNote.Text, dateTimePickerExpiryDate.Value);
            }
            else
            {
                Program.passwordBook.AddPassword(textBoxWebService.Text, textBoxEmail.Text, textBoxPassword.Text, textBoxPincode.Text, textBoxNote.Text);
            }
            
            Program.mainForm.updatePasswordsView();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //PasswordTrackBarUpdate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //PasswordTrackBarUpdate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            //PasswordTrackBarUpdate();
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

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            CopyPasswordToClipboard.Text = "Copy";
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
