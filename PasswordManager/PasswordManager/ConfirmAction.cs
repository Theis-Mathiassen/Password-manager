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
    public partial class ConfirmAction : Form
    {

        public bool Result { get; set; } = false;

        public ConfirmAction(string confirmText)
        {
            InitializeComponent();
            LabelMessage.Text = confirmText;
            LabelMessage.MaximumSize = new Size(Width - (4 * LabelMessage.Location.X), Height - (4 * LabelMessage.Location.Y));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Form_ResizeEnd(Object sender, EventArgs e)
        {
            LabelMessage.MaximumSize = new Size(Width - (4 * LabelMessage.Location.X), Height - (4 * LabelMessage.Location.Y));
        }
    }
}
