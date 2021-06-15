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

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
