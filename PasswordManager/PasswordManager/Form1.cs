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

        public Form1()
        {
            InitializeComponent();
            Program.passwordListPath = @"C:\test\data.csv";
            newPasswordForm = new Add_Password_Form ();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Console.WriteLine(dataGridView1.SelectedRows[0]);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.passwordBook.SavePasswordsToCSV(@"C:\test\data.csv");
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
            Program.passwordBook.ClearPasswords();
            Program.passwordBook.LoadPasswordsFromCSV(Program.passwordListPath);
            insertDataToGridView(Program.passwordBook.passwordData, dataGridView1);
            updatePasswordsView();
        }

        

        public void updatePasswordsView ()
        {
            dataGridView1.Rows.Clear();
            if (Program.passwordBook.passwordData.Count > 0)
            {
                CheckMatchingHeaders(Program.passwordBook.passwordData[0].ToStringArray(), dataGridView1);
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
                CheckMatchingHeaders(data[0].ToStringArray(), gridView);
                for (int i = 1; i < data.Count; i++)
                {
                    gridView.Rows.Add(data[i].ToStringArray());
                }
            }
        }
        private bool CheckMatchingHeaders (string[] FileHeaders, DataGridView dataGridView)
        {
            bool result = true;
            if (FileHeaders.Length == dataGridView.Columns.GetColumnCount(DataGridViewElementStates.None))
            {
                for (int i = 0; i < FileHeaders.Length; i++)
                {
                    if (false == (FileHeaders[i] == dataGridView.Columns[i].Name))
                    {
                        result = false;
                    }
                }
            }
            else
            {
                result = false;
            }
            
            return result;
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
            newPasswordForm.Show();
            
        }

        
    }
}
