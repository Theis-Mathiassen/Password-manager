﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public partial class Form1 : Form
    {
        private string LastOpened;
        //private PasswordShow passwordShowForm;



        public Form1()
        {
            InitializeComponent();
            RecentToolStripMenuItemUpdateValues();
            
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            // Determine if text has changed in the textbox by comparing to original text.
            
            // Display a MsgBox asking the user to save changes or abort.
            if (MessageBox.Show("Are you sure you want to close the application?", "My Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                // Cancel the Closing event from closing the form.
                e.Cancel = true;
                // Call method to save file...
            }
            
        }

        public void RecentToolStripMenuItemUpdateValues ()
        {
            List<string> pathData = Config.GetPreviousPath(-1);
            for (int i = 0; i < pathData.Count; i++)
            {
                recentToolStripMenuItem.Items.Add(pathData[i]);
            }
        }
        private void RecentToolStripMenu_DropdownClosed (object sender, EventArgs e)
        {
            LoadPasswords(recentToolStripMenuItem.Text);
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == dataGridView1.Columns["CopyPassword"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = 16;
                var h = 16;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.CopyPasswordIcon, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == 3 || e.ColumnIndex == 5) && e.Value != null)
            {
                dataGridView1.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.Rows.Count - 1)
            {
                AddPassword();
            }

        }
        private void dataGridView1_CellDoubleClick (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= dataGridView1.Rows.Count - 2)
            {
                EditSelectedPassword();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["CopyPassword"].Index)
            {
                string result = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Password"].Value);
                Clipboard.SetData(DataFormats.Text, result);
            }

        }
        private void removePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this password?", "Delete password", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Console.WriteLine("Hello");
                Credential selectedCredential = getSelectedCredential();
                PasswordBook.RemoveCredential(selectedCredential);
            }
            InsertDataToGridView(PasswordBook.GetCredentials(), dataGridView1);
        }
        private void setMasterPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PasswordBook.GetMasterPassword() == null)
            {
                SetMasterPassword();
            }
            else
            {
                using (DisplayMessageAndReturnInput MessageInput = new DisplayMessageAndReturnInput("Input existing password"))
                {
                    MessageInput.textBoxInput.UseSystemPasswordChar = true;
                    if (MessageInput.ShowDialog() == DialogResult.OK)
                    {
                        Console.WriteLine(MessageInput.input);

                        byte[][] ExistingPassword = PasswordBook.GetMasterPassword();
                        byte[][] InputPassword = SecurityController.GetHashKeys(MessageInput.input);
                        bool result = true;
                        for (int i = 0; i < ExistingPassword.Length; i++)
                        {
                            if (!ExistingPassword[i].SequenceEqual(InputPassword[i]))
                            {
                                result = false;
                            }
                        }
                        if (result)
                        {
                            SetMasterPassword();
                        }
                        else
                        {
                            MessageBox.Show("Wrong password, try again");
                        }
                    }
                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void newPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPassword();
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PasswordBook.IsPathEmpty())
            {
                if (PasswordBook.GetMasterPassword() == null)
                {
                    MessageBox.Show("No password, setup a master password in: \"Vault\" -> \"Set master password\"");
                }
                else
                {
                    using (SaveFileDialog SaveFileDialog = new SaveFileDialog())
                    {
                        SaveFileDialog.InitialDirectory = "c:\\";
                        SaveFileDialog.Filter = "JSON files (*.JSON)|*.JSON";
                        SaveFileDialog.FilterIndex = 2;
                        SaveFileDialog.RestoreDirectory = true;

                        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            PasswordBook.SetPath(SaveFileDialog.FileName);
                            PasswordBook.SavePasswordsToFile();
                        }
                    }
                }
            }
            else
            {
                if (PasswordBook.IsModified())
                {
                    DialogResult ConfirmDialogResult = MessageBox.Show("Are you sure you want to overwrite the current save file?", "Confirm save", MessageBoxButtons.YesNo);
                    if (ConfirmDialogResult == DialogResult.Yes)
                    {
                        PasswordBook.SavePasswordsToFile();
                    }
                    else if (ConfirmDialogResult == DialogResult.No)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {
                    PasswordBook.SavePasswordsToFile();
                }
            }
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = FileManager.JSONFileFromFileExplorer();
            LoadPasswords(path);
        }
        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Open a selected password, and show it to the user and save changes.
        private void editPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditSelectedPassword();
        }

        private Credential getSelectedCredential()
        {
            Credential result = null;
            Int32 selectedCellCount = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 1)
            {
                MessageBox.Show("Too many passwords selected.");
            }
            else if (selectedCellCount == 1)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[selectedCellCount - 1].RowIndex];
                long CredentialID = Convert.ToInt64(selectedRow.Cells["ID"].Value);
                List<Credential> credentials = PasswordBook.GetCredentials();
                foreach (Credential credential in credentials)
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
        private void AddPassword ()
        {
            using (Add_Password_Form passwordForm = new Add_Password_Form())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    Credential credential = passwordForm.credential;
                    PasswordBook.AddPassword(credential.ServiceName, credential.Email, credential.Password, credential.Pincode, credential.URL, credential.Note, credential.Expires, credential.ExpiryDate);
                }
            }
            InsertDataToGridView(PasswordBook.GetCredentials(), dataGridView1);
        }
        private void EditSelectedPassword ()
        {
            Credential selectedCredential = getSelectedCredential();
            if (selectedCredential != null)
            {
                using (Add_Password_Form passwordForm = new Add_Password_Form(selectedCredential))
                {
                    if (passwordForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedCredential = passwordForm.credential;
                    }
                }
                InsertDataToGridView(PasswordBook.GetCredentials(), dataGridView1);
            }
        }
        public void LoadPasswords(string passwordPath = "")
        {
                        

            if (File.Exists(passwordPath) && Path.GetExtension(passwordPath) == ".JSON")
            {
                LastOpened = passwordPath;
                string inputPassword = "";
                using (DisplayMessageAndReturnInput MessageInput = new DisplayMessageAndReturnInput("Loading: " + passwordPath + Environment.NewLine + Environment.NewLine + "Enter password below:"))
                {
                    MessageInput.textBoxInput.UseSystemPasswordChar = true;
                    MessageInput.Name = Path.GetFileNameWithoutExtension(passwordPath);
                    if (MessageInput.ShowDialog() == DialogResult.OK)
                    {
                        inputPassword = MessageInput.input;
                        string encryptedString = File.ReadAllText(passwordPath);
                        string JSONString = SecurityController.Decrypt(SecurityController.GetHashKeys(inputPassword), encryptedString);
                        if (JSONString != null)
                        {
                            PasswordBook.Setup(this, passwordPath, SecurityController.GetHashKeys(inputPassword), Path.GetFileNameWithoutExtension(passwordPath));
                            //PasswordBook = new PasswordBook(passwordPath, SecurityController.GetHashKeys(inputPassword), Path.GetFileNameWithoutExtension(passwordPath));
                            PasswordBook.LoadPasswordsFromFile();
                            InsertDataToGridView(PasswordBook.GetCredentials(), dataGridView1);
                        }
                    }
                }
            } else {
                //Alert user path not existing.
            }
        }


        private void InsertDataToGridView (List<Credential> data, DataGridView gridView)
        {
            dataGridView1.Rows.Clear();
            if (data.Count > 0)
            {
                int columnsCount = gridView.Columns.GetColumnCount(DataGridViewElementStates.None);
                string[] propertyArray = new string[columnsCount];
                for (int i = 0; i < columnsCount; i++)
                {
                    DataGridViewColumn column = gridView.Columns[i];
                    propertyArray[i] = column.Name;
                }
                
                for (int i = 0; i < data.Count; i++)
                {
                    
                    gridView.Rows.Add(data[i].ToStringArray(propertyArray));
                }
            }
        }
        private void SetMasterPassword ()
        {
            if (MessageBox.Show("When choosing a master password, it is very important to create a long yet memorable password." +
                " Select a long phrase that you will remember, but is not that easy to guess. " +
                "Include at least one of each: upper case letters, lower case letters, numbers and special characters. " +
                "Select a passphrase that is easy to type, especially on a cellphone keyboard since you will be typing" +
                " this passphrase in many times throughout the day / week.",
                "Confirm setting master password",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SetMasterPassword setMasterPassword = new SetMasterPassword())
                {
                    if (setMasterPassword.ShowDialog() == DialogResult.OK)
                    {
                        PasswordBook.SetMasterPassword(SecurityController.GetHashKeys(setMasterPassword.password));
                    }
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void recentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
