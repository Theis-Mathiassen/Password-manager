using System;
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
            //LoadPasswords();
            Setting
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
            using (ConfirmAction confirmAction = new ConfirmAction("Delete password!"))
            {
                if (confirmAction.ShowDialog() == DialogResult.OK)
                {
                    Credential selectedCredential = getSelectedCredential();
                    Program.passwordBook.RemoveCredential(selectedCredential);

                }
            }
            InsertDataToGridView(Program.passwordBook.GetCredentials(), dataGridView1);
        }
        private void setMasterPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.passwordBook.GetMasterPassword() == null)
            {
                SetMasterPassword();
            }
            else
            {
                using (DisplayMessageAndReturnInput inputForm = new DisplayMessageAndReturnInput("Input existing password"))
                {
                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        Console.WriteLine(inputForm.input);

                        byte[][] ExistingPassword = Program.passwordBook.GetMasterPassword();
                        byte[][] InputPassword = SecurityController.GetHashKeys(inputForm.input);
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
            if (Program.passwordBook.IsPathEmpty())
            {
                if (Program.passwordBook.GetMasterPassword() == null)
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
                            Program.passwordBook.SetPath(SaveFileDialog.FileName);
                            Program.passwordBook.SavePasswordsToFile();
                        }
                    }
                }
            }
            else
            {
                if (Program.passwordBook.IsModified())
                {
                    using (Form form = new ConfirmAction("Overwrite current save file."))
                    {
                        DialogResult ConfirmDialogResult = form.ShowDialog();
                        if (ConfirmDialogResult == DialogResult.OK)
                        {
                            Program.passwordBook.SavePasswordsToFile();
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
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadPasswords();
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
            if (selectedCellCount > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[dataGridView1.SelectedCells[selectedCellCount - 1].RowIndex];
                long CredentialID = Convert.ToInt64(selectedRow.Cells["ID"].Value);
                List<Credential> credentials = Program.passwordBook.GetCredentials();
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
                    Program.passwordBook.AddPassword(credential.ServiceName, credential.Email, credential.Password, credential.Pincode, credential.URL, credential.Note, credential.Expires, credential.ExpiryDate);
                }
            }
            Program.mainForm.InsertDataToGridView(Program.passwordBook.GetCredentials(), dataGridView1);
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
                InsertDataToGridView(Program.passwordBook.GetCredentials(), dataGridView1);
            }
        }
        private void LoadPasswords()
        {
            string passwordPath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = LastOpened ?? "c:\\";
                openFileDialog.Filter = "JSON files (*.JSON)|*.JSON";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    passwordPath = openFileDialog.FileName;
                }
            }

            if (File.Exists(passwordPath) && Path.GetExtension(passwordPath) == ".JSON")
            {
                LastOpened = passwordPath;
                string inputPassword = "";
                using (DisplayMessageAndReturnInput MessageInput = new DisplayMessageAndReturnInput("Enter password"))
                {
                    if (MessageInput.ShowDialog() == DialogResult.OK)
                    {
                        inputPassword = MessageInput.input;
                    }
                }
                string encryptedString = File.ReadAllText(passwordPath);
                string JSONString = SecurityController.Decrypt(SecurityController.GetHashKeys(inputPassword), encryptedString);
                if (JSONString != null)
                {
                    Program.passwordBook = new PasswordBook(passwordPath, SecurityController.GetHashKeys(inputPassword), Path.GetFileNameWithoutExtension(passwordPath));
                    Program.passwordBook.LoadPasswordsFromFile();
                    InsertDataToGridView(Program.passwordBook.GetCredentials(), dataGridView1);
                }
            }
        }
        private void InsertDataToGridView (List<Credential> data, DataGridView gridView)
        {
            if (data.Count > 0)
            {
                dataGridView1.Rows.Clear();
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
            using (ConfirmAction confirm = new ConfirmAction("When choosing a master password, it is very important to create a long yet memorable password. Select a long phrase that you will remember, but is not that easy to guess. Include at least one of each: upper case letters, lower case letters, numbers and special characters. Select a passphrase that is easy to type, especially on a cellphone keyboard since you will be typing this passphrase in many times throughout the day / week."))
            {
                if (confirm.ShowDialog() == DialogResult.OK)
                {
                    using (SetMasterPassword setMasterPassword = new SetMasterPassword())
                    {
                        if (setMasterPassword.ShowDialog() == DialogResult.OK)
                        {
                            Program.passwordBook.SetMasterPassword(SecurityController.GetHashKeys(setMasterPassword.password));
                        }
                    }
                }
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
