﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PasswordManager
{
    static class Program
    {
        //internal const string MasterPassword = "Master";
        static internal PasswordBook passwordBook;
        //static internal string passwordListPath;
        static internal Form1 mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            passwordBook = new PasswordBook(null, null, "Empty");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form1();
            mainForm.Text = passwordBook.GetName();
            Application.Run(mainForm);
            
        }

        internal static string generatePassword(int length, int numberCount, int symbolCount)
        {
            string result = "";
            try
            {
                Random rand = new Random();
                char[] password = new char[length];
                List<int> remainingIndex = new List<int>();
                for (int i = 0; i < length; i++)
                {
                    remainingIndex.Add(i);
                }
                for (int i = 0; i < numberCount; i++)
                {
                    int var = rand.Next(48, 58);
                    int index = rand.Next(0, remainingIndex.Count);
                    password[remainingIndex[index]] = (char)var;
                    remainingIndex.RemoveAt(index);
                }
                for (int i = 0; i < symbolCount; i++)
                {
                    int var = rand.Next(33, 65);
                    if (var >= 48 && var <= 57) { var += 10; }
                    if (var >= 65 && var <= 90) { var += 26; }
                    if (var >= 97 && var <= 101) { var += 26; }
                    int index = rand.Next(0, remainingIndex.Count);
                    password[remainingIndex[index]] = (char)var;
                    remainingIndex.RemoveAt(index);
                }
                while (remainingIndex.Count > 0)
                {
                    int var = rand.Next(65, 117);
                    if (var >= 91 && var <= 96) { var += 6; }
                    int index = rand.Next(0, remainingIndex.Count);
                    password[remainingIndex[index]] = (char)var;
                    remainingIndex.RemoveAt(index);
                }
                for (int i = 0; i < password.Length; i++)
                {
                    result += password[i];
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error to many symbols");
                Console.WriteLine(ex.ToString());
            }
            
            return result;
        }
        
    }
    

    /// <summary>
    /// A collection of all passwords
    /// </summary>
    public class PasswordBook
    {
        //Name of the passwordbook
        private string BookName;
        //Indicates wether or not the Password book has been modified.
        private bool modified;
        //The list of the passwords and attached information.
        private List<Credential> passwordData;
        //The hashed password key used to decrypt passwords.
        private byte[][] keys;
        //The path of the file storing the passwords.
        private string path;

        public bool IsPathEmpty ()
        {
            if (path == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SetPath (string path)
        {
            this.path = path;
        }
        public void SetMasterPassword (byte[][] keys)
        {
            this.keys = keys;
        }
        public PasswordBook (string path, byte[][] keys, string BookName)
        {
            passwordData = new List<Credential>();
            this.path = path;
            this.keys = keys;
            this.BookName = BookName;
        }
        public string GetName ()
        {
            return BookName;
        }
        public bool IsModified ()
        {
            return modified;
        }
        public List<Credential> GetCredentials ()
        {
            return passwordData;
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
        internal void AddPassword(string serviceName, string email, string password, string pincode, string note)
        {
            modified = true;
            int id = GetNewId();
            passwordData.Add(new Credential(serviceName, email, password, pincode, note, id));
        }
        internal void AddPassword (string serviceName, string email, string password, string pincode, string note, DateTime ExpiryDate)
        {
            modified = true;
            int id = GetNewId();
            passwordData.Add(new Credential(serviceName, email, password, pincode, note, id, ExpiryDate));
        }
        
        
        internal void ClearPasswords ()
        {
            modified = true;
            passwordData.Clear();
        }
        internal string SavePasswordsToJSON()
        {
            string result = JsonConvert.SerializeObject(passwordData);
            return result;
        }
        internal void LoadPasswordsFromJSON (string JSONString)
        {
            passwordData = JsonConvert.DeserializeObject<List<Credential>>(JSONString);
        }

        internal void SavePasswordsToFile()
        {
            BookName = Path.GetFileName(path);
            Program.mainForm.Text = BookName;
            string JSONText = SavePasswordsToJSON();
            string encryptedPasswords = SecurityController.Encrypt(keys, JSONText);
            File.WriteAllText(path, JSONText);
            File.WriteAllText(path, encryptedPasswords);

        }
        internal bool LoadPasswordsFromFile()
        {
            BookName = Path.GetFileName(path);
            Program.mainForm.Text = BookName;
            bool result = true;
            ClearPasswords();
            modified = false;
            string encryptedString = File.ReadAllText(path);
            string JSONString = SecurityController.Decrypt(keys, encryptedString);
            if (JSONString != null)
            {
                LoadPasswordsFromJSON(JSONString);
            }
            else
            {
                //Incorrect try again.
                result = false;
            }
            return result;
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
        public string Pincode;
        public string Note;
        public DateTime DateCreated;
        public bool Expires;
        public DateTime ExpiryDate;

        public Credential ()
        {

        }
        public Credential(string serviceName, string email, string password, string pincode, string note, int id)
        {
            this.Id = id;
            this.ServiceName = serviceName;
            this.Email = email;
            this.Password = password;
            this.Pincode = pincode;
            this.Note = note;
            DateCreated = DateTime.Now;
            Expires = false;
            ExpiryDate = DateTime.Now;
        }
        public Credential(string serviceName, string email, string password, string pincode, string note, int id, DateTime ExpiryDate)
        {
            this.Id = id;
            this.ServiceName = serviceName;
            this.Email = email;
            this.Password = password;
            this.Pincode = pincode;
            this.Note = note;
            DateCreated = DateTime.Now;
            Expires = true;
            this.ExpiryDate = ExpiryDate;
        }
        internal string[] ToStringArray ()
        {
            string[] result = new string[8];
            result[0] = Id.ToString();
            result[1] = ServiceName;
            result[2] = Email;
            result[3] = Password;
            result[4] = Pincode;
            result[5] = Note;
            result[6] = DateCreated.ToLongDateString();
            if (Expires)
            {
                result[7] = ExpiryDate.ToLongDateString();
            }
            else
            {
                result[7] = "";
            }

            return result;
        }
    }
}
