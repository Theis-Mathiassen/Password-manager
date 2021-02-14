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
        private string passwordListPath;
        private string[] CommentTokens;
        private string[] delimiters;
        private List<List<string>> passwordData;

        public Form1()
        {
            InitializeComponent();
            passwordListPath = @"C:\test\data.csv";
            CommentTokens = new string[] { "#" };
            delimiters = new string[] { ";" };
            passwordData = new List<List<string>>();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            passwordData.Clear();
            using (TextFieldParser csvParser = new TextFieldParser(passwordListPath))
            {
                csvParser.CommentTokens = CommentTokens;
                csvParser.SetDelimiters(delimiters);
                csvParser.HasFieldsEnclosedInQuotes = true;
                int i = 0;
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    passwordData.Add(fields.ToList());
                    i++;
                }
            }
            dataGridView1.Rows.Clear();
            insertDataToGridView(passwordData, dataGridView1);
        }

        private void insertDataToGridView (List<List<string>> data, DataGridView gridView)
        {
            if (data.Count > 0)
            {
                CheckMatchingHeaders(data[0], gridView);
                for (int i = 1; i < data.Count; i++)
                {
                    gridView.Rows.Add(data[i].ToArray());
                }
            }
            

            //data[0].Count;
            //gridView.Columns.re 
            
            


            //gridView.Rows[dataGridView1.Rows.GetRowCount(DataGridViewElementStates.None) - 1].Cells[0].Value = "Hej";
        }
        private bool CheckMatchingHeaders (List<string> FileHeaders, DataGridView dataGridView)
        {
            bool result = true;
            for (int i = 0; i < FileHeaders.Count; i++)
            {
                if (false == (FileHeaders[i] == dataGridView.Columns[i].Name))
                {
                    result = false;
                } 
            }
            return result;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
