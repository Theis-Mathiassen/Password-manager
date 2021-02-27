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
    }
}
