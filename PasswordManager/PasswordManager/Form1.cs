using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        
        private string[] CommentTokens;
        private string[] delimiters;
        

        private Add_Password newPasswordForm;

        public Form1()
        {
            InitializeComponent();
            Program.passwordListPath = @"C:\test\data.csv";
            CommentTokens = new string[] { "#" };
            delimiters = new string[] { ";" };
            newPasswordForm = new Add_Password ();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine(dataGridView1.SelectedRows[0]);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.passwordBook.passwordData.Clear();
            dataGridView1.Rows.Clear();

            Program.passwordBook.passwordData = getPasswordsFromCSV(Program.passwordListPath);
            insertDataToGridView(Program.passwordBook.passwordData, dataGridView1);
            updatePasswordsView();
        }

        private List<Credential> getPasswordsFromCSV (string path)
        {
            List<Credential> passwords = new List<Credential>();
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = CommentTokens;
                csvParser.SetDelimiters(delimiters);
                csvParser.HasFieldsEnclosedInQuotes = true;
                bool matchingHeaders = CheckMatchingHeaders(csvParser.ReadFields(), dataGridView1);
                int i = 0;
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    passwords.Add(new Credential(fields[1], fields[2], fields[3], fields[4], int.Parse(fields[0])));
                    i++;
                }
            }
            return passwords;
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
