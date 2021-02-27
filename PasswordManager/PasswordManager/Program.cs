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

        static internal Form1 mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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
