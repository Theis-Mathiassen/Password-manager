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
    public partial class Form1 : Form
    {
        
        
        

        private Add_Password_Form newPasswordForm;
        private PasswordShow passwordShowForm;

        public Form1()
        {
            InitializeComponent();
            Program.passwordListPath = @"C:\test\data.JSON";
            
        }

        private Credential getSelectedCredential ()
        {
            Credential result = null;
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[selectedCellCount - 1].RowIndex];
                long CredentialID = Convert.ToInt64(selectedRow.Cells["ID"].Value);
                foreach (Credential credential in Program.passwordBook.passwordData)
                {
                    if (credential.Id == CredentialID)
                    {
                        result = credential;
                    }
                }
            }
            else
            {
                result = null;
            }
            return result;
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 4) && e.Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.passwordBook.modified)
            {
                using (Form form = new ConfirmAction("Overwrite current save file."))
                {
                    DialogResult ConfirmDialogResult = form.ShowDialog();
                    if (ConfirmDialogResult == DialogResult.OK)
                    {
                        Program.passwordBook.SavePasswordsToFile(Program.passwordListPath);
                    }
                    else if (ConfirmDialogResult == DialogResult.Cancel)
                    {

                    }
                    else
                    {

                    }
                }
            }
            
            
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Program.passwordBook.ClearPasswords();
            Program.passwordBook.LoadPasswordsFromFile(Program.passwordListPath);
            insertDataToGridView(Program.passwordBook.passwordData, dataGridView1);
            updatePasswordsView();
        }

        

        public void updatePasswordsView ()
        {
            dataGridView1.Rows.Clear();
            if (Program.passwordBook.passwordData.Count > 0)
            {
                for (int i = 0; i < Program.passwordBook.passwordData.Count; i++)
                {
                    dataGridView1.Rows.Add(Program.passwordBook.passwordData[i].ToStringArray());
                }
            }
        }

        private void insertDataToGridView (List<Credential> data, DataGridView gridView)
        {
            if (data.Count > 0)
            {
                for (int i = 1; i < data.Count; i++)
                {
                    gridView.Rows.Add(data[i].ToStringArray());
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newPasswordForm = new Add_Password_Form();
            newPasswordForm.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void editPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Credential selectedCredential = getSelectedCredential();
            if (selectedCredential != null)
            {
                passwordShowForm = new PasswordShow(selectedCredential);
                passwordShowForm.Show();
            }
        }

        private void removePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
