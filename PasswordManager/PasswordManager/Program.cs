using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    static class Program
    {
        static internal PasswordBook passwordBook;
        static internal string passwordListPath;
        static internal string[] CommentTokens;
        static internal string[] delimiters;
        static internal Form1 mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            CommentTokens = new string[] { "#" };
            delimiters = new string[] { ";" };
            passwordBook = new PasswordBook();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form1();
            Application.Run(mainForm);
        }
    }

    /// <summary>
    /// A collection of all passwords
    /// </summary>
    public class PasswordBook
    {
        public List<Credential> passwordData;
        public PasswordBook ()
        {
            passwordData = new List<Credential>();
        }

        public int GetNewId ()
        {
            int tempID = passwordData.Count;
            bool foundID = false;
            while (foundID == false)
            {
                if (passwordData.Count > 0)
                {
                    for (int i = 0; i < passwordData.Count; i++)
                    {
                        if (passwordData[i].Id == tempID)
                        {
                            tempID++;
                        }
                        else
                        {
                            foundID = true;
                        }

                    }
                }
                else
                {
                    foundID = true;
                }
                
            }
            return tempID;
        }
        public void AddPassword (string serviceName, string email, string password, string note)
        {
            int id = GetNewId();
            passwordData.Add(new Credential(serviceName, email, password, note, id));
        }
        internal void LoadPasswordsFromCSV(string path)
        {
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = Program.CommentTokens;
                csvParser.SetDelimiters(Program.delimiters);
                csvParser.HasFieldsEnclosedInQuotes = true;
                //Read Headers
                csvParser.ReadFields();
                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    passwordData.Add(new Credential(fields[1], fields[2], fields[3], fields[4], int.Parse(fields[0])));
                }
            }
        }
        internal void clearPasswords ()
        {
            passwordData.Clear();
        }
    }
    /// <summary>
    /// All information about a single password is stored in this class.
    /// </summary>
    public class Credential
    {
        public int Id;
        public string ServiceName;
        public string Email;
        public string Password;
        public string Note;

        public Credential ()
        {

        }
        public Credential(string serviceName, string email, string password, string note, int id)
        {
            this.Id = id;
            this.ServiceName = serviceName;
            this.Email = email;
            this.Password = password;
            this.Note = note;
        }

        void SetRandomPassword (int length = 10)
        {
            Random rand = new Random();
            Password = "";
            for (int i = 0; i < length; i++)
            {
                Password = Password + (char)rand.Next(33, 122);
            }
        }

        internal string[] ToStringArray ()
        {
            string[] result = {
                Id.ToString(),
                ServiceName,
                Email,
                Password,
                Note
            };
            return result;
        }
    }
}
