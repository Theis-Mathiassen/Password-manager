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
    public partial class PasswordConfigoration : Form
    {
        public string Password
        {
            get { return textBoxPassword.Text; }
        }
        public PasswordConfigoration(string password)
        {
            InitializeComponent();
            textBoxPassword.Text = password;
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            PasswordTrackBarUpdate();
        }
        private void PasswordTrackBarUpdate()
        {
            trackBar3.Maximum = trackBar1.Value;
            trackBar4.Maximum = trackBar1.Value - trackBar3.Value;
            label6.Text = trackBar1.Value.ToString();
            label9.Text = trackBar3.Value.ToString();
            label10.Text = trackBar4.Value.ToString();
            generatePassword();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            PasswordTrackBarUpdate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            PasswordTrackBarUpdate();
        }

        void generatePassword()
        {
            string tempPassword = Program.generatePassword(trackBar1.Value, trackBar3.Value, trackBar4.Value);
            textBoxPassword.Text = tempPassword;
        }

        private void buttonSendPassword_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonShowHidePassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.UseSystemPasswordChar)
            {
                buttonShowHidePassword.ImageIndex = 1;
                //ShowPasswordButton.Text = "Hide";
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                buttonShowHidePassword.ImageIndex = 2;
                //ShowPasswordButton.Text = "Show";
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void buttonCopyPassword_Click(object sender, EventArgs e)
        {
            Clipboard.SetData(DataFormats.Text, (Object)textBoxPassword.Text);
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
