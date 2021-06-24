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
    public partial class DisplayMessageAndReturnInput : Form
    {
        public string input;
        public DisplayMessageAndReturnInput(string MessageText)
        {
            InitializeComponent();
            labelMessage.Text = MessageText;
            labelMessage.MaximumSize = new Size(Width - (4 * labelMessage.Location.X), Height - (4 * labelMessage.Location.Y));
        }
        private void Form_ResizeEnd(Object sender, EventArgs e)
        {
            labelMessage.MaximumSize = new Size(Width - (4 * labelMessage.Location.X), Height - (4 * labelMessage.Location.Y));
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            input = textBoxInput.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
