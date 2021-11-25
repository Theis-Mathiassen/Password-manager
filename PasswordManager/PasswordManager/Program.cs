using Microsoft.VisualBasic.FileIO;
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
        
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //static internal string passwordListPath;
            Form1 mainForm;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new Form1();

            Config.LoadFromFile();
            PasswordBook.Setup(mainForm, null, null, "Empty");
            
            
            mainForm.Text = PasswordBook.GetName();
            Application.Run(mainForm);

            Config.SaveToFile();

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
    public static class PasswordBook
    {
        //The form the passwordBook exists within
        static Form1 mainForm;
        //Name of the passwordbook
        static private string BookName;
        //Indicates wether or not the Password book has been modified.
        static private bool modified;
        //The list of the passwords and attached information.
        static private List<Credential> passwordData;
        //The hashed password key used to decrypt passwords.
        static private byte[][] keys;
        //The path of the file storing the passwords.
        static private string path;

        
        public static void Setup(Form1 form, string newPath, byte[][] newKeys, string newBookName)
        {
            mainForm = form;
            passwordData = new List<Credential>();
            path = newPath;
            keys = newKeys;
            BookName = newBookName;
        }

        public static void RemoveCredential (Credential credential)
        {
            passwordData.Remove(credential);
        }

        public static bool IsPathEmpty ()
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
        public static void SetPath (string newPath)
        {
            path = newPath;
        }
        public static byte[][] GetMasterPassword ()
        {
            return keys;
        }
        public static void SetMasterPassword (byte[][] newKeys)
        {
            keys = newKeys;
        }

        public static string GetName ()
        {
            return BookName;
        }
        public static bool IsModified ()
        {
            return modified;
        }
        public static List<Credential> GetCredentials ()
        {
            return passwordData;
        }
        public static int GetNewId ()
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
        internal static void AddPassword (string serviceName, string email, string password, string pincode, string URL, string note, bool expires, DateTime ExpiryDate)
        {
            modified = true;
            int id = GetNewId();
            passwordData.Add(new Credential(serviceName, email, password, pincode, note, id, URL, expires, ExpiryDate));
        }


        internal static void ClearPasswords ()
        {
            modified = true;
            passwordData.Clear();
        }
        internal static string SavePasswordsToJSON()
        {
            string result = JsonConvert.SerializeObject(passwordData);
            return result;
        }
        internal static void LoadPasswordsFromJSON (string JSONString)
        {
            passwordData = JsonConvert.DeserializeObject<List<Credential>>(JSONString);
        }

        internal static void SavePasswordsToFile()
        {

            
            Config.SetLastPath(path);
            Config.AddPreviousPath(mainForm, path);
            BookName = Path.GetFileNameWithoutExtension(path);
            mainForm.Text = BookName;
            string JSONText = SavePasswordsToJSON();
            string encryptedPasswords = SecurityController.Encrypt(keys, JSONText);
            //File.WriteAllText(path, JSONText);
            File.WriteAllText(path, encryptedPasswords);

        }
        /* tries to load passwords from internal path, return true if success */
        internal static bool LoadPasswordsFromFile()
        {
            BookName = Path.GetFileNameWithoutExtension(path);
            mainForm.Text = BookName;
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
        public string URL;
        public string Note;
        public DateTime DateCreated;
        public bool Expires;
        public DateTime ExpiryDate;

        public Credential ()
        {

        }
        public Credential(string serviceName, string email, string password, string pincode, string note, string URL, bool expires, DateTime ExpiryDate)
        {
            this.Id = 0;
            this.ServiceName = serviceName;
            this.Email = email;
            this.Password = password;
            this.Pincode = pincode;
            this.URL = URL;
            this.Note = note;
            DateCreated = DateTime.Now;
            Expires = expires;
            this.ExpiryDate = ExpiryDate;
        }
        public Credential(string serviceName, string email, string password, string pincode, string note, int id, string URL, bool expires, DateTime ExpiryDate)
        {
            this.Id = id;
            this.ServiceName = serviceName;
            this.Email = email;
            this.Password = password;
            this.Pincode = pincode;
            this.URL = URL;
            this.Note = note;
            DateCreated = DateTime.Now;
            Expires = expires;
            this.ExpiryDate = ExpiryDate;
        }

        internal string[] ToStringArray (string[] columnHeader)
        {
            string[] result = new string[columnHeader.Count()];
            for (int i = 0; i < result.Length; i++)
            {
                switch (columnHeader[i])
                {
                    case "ID":
                        result[i] = Id.ToString();
                        break;
                    case "Service":
                        result[i] = ServiceName;
                        break;
                    case "Email":
                        result[i] = Email;
                        break;
                    case "Password":
                        result[i] = Password;
                        break;
                    case "CopyPassword":
                        result[i] = "";
                        break;
                    case "Pincode":
                        result[i] = Pincode;
                        break;
                    case "URL":
                        result[i] = URL;
                        break;
                    case "Note":
                        result[i] = Note;
                        break;
                    case "DateCreated":
                        result[i] = DateCreated.ToLongDateString();
                        break;
                    case "ExpiryDate":
                        if (Expires)
                        {
                            result[i] = ExpiryDate.ToLongDateString();
                        }
                        else
                        {
                            result[i] = "";
                        }
                        break;
                    default:
                        result[i] = "Error";
                        break;
                }
            }
            return result;
        }
    }
}
