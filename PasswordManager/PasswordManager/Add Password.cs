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
        public Add_Password_Form()
        {
            InitializeComponent();
        }

        void generatePassword ()
        {
            string tempPassword = Program.generatePassword(trackBar1.Value, trackBar3.Value, trackBar4.Value);
            textBoxPassword.Text = tempPassword;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = Program.passwordBook.GetNewId();
            Program.passwordBook.AddPassword(textBoxWebService.Text, textBoxEmail.Text, textBoxPassword.Text, textBoxNote.Text);
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
            PasswordTrackBarUpdate();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            PasswordTrackBarUpdate();
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            PasswordTrackBarUpdate();
        }
        private void PasswordTrackBarUpdate ()
        {
            trackBar3.Maximum = trackBar1.Value;
            trackBar4.Maximum = trackBar1.Value - trackBar3.Value;
            label6.Text = trackBar1.Value.ToString();
            label9.Text = trackBar3.Value.ToString();
            label10.Text = trackBar4.Value.ToString();
            generatePassword();
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
    }
}
