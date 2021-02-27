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

        internal static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
        internal static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }



        static internal byte[][] GetHashKeys(string key)
        {
            byte[][] result = new byte[2][];
            Encoding enc = Encoding.UTF8;

            SHA256 sha2 = new SHA256CryptoServiceProvider();

            byte[] rawKey = enc.GetBytes(key);
            byte[] rawIV = enc.GetBytes(key);

            byte[] hashKey = sha2.ComputeHash(rawKey);
            byte[] hashIV = sha2.ComputeHash(rawIV);

            Array.Resize(ref hashIV, 16);

            result[0] = hashKey;
            result[1] = hashIV;

            return result;
        }
    }
    

    /// <summary>
    /// A collection of all passwords
    /// </summary>
    public class PasswordBook
    {
        public bool modified;
        internal List<Credential> passwordData;
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
            modified = true;
            int id = GetNewId();
            passwordData.Add(new Credential(serviceName, email, password, note, id));
        }
        internal void LoadPasswordsFromCSV(string path)
        {
            modified = false;
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
        internal void ClearPasswords ()
        {
            modified = true;
            passwordData.Clear();
        }
        internal void SavePasswordsToCSV (string path)
        {
            using (StreamWriter streamWriter = new StreamWriter(path))
            {
                string del = Program.delimiters[0];
                streamWriter.WriteLine("id" + del + "service name" + del + "email" + del + "password" + del + "note");
                for (int i = 0; i < passwordData.Count; i++)
                {
                    string[] password = passwordData[i].ToStringArray();
                    string passwordFileEntry = "";
                    for (int j = 0; j < password.Length; j++)
                    {
                        if (password[j].Contains("\""))
                        {
                            password[j] = password[j].Replace("\"", "\"\"");
                        }
                        if (password[j].Contains(del))
                        {
                            password[j] = "\"" + password[j] + "\"";
                        }
                        
                        if (j == password.Length)
                        {
                            passwordFileEntry += password[j];
                        }
                        else
                        {
                            passwordFileEntry += password[j] + del;
                        }
                    }
                    streamWriter.WriteLine(passwordFileEntry);
                }




                string original = "Here is some data to encrypt!";

                // Create a new instance of the Aes
                // class.  This generates a new key and initialization
                // vector (IV).
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                using (Aes myAes = Aes.Create())
                {
                    
                    myAes.KeySize = 256;
                    string password = "qwerty";
                    
                    SHA256 



                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = Program.EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);

                    // Decrypt the bytes to a string.
                    string roundtrip = Program.DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    //Console.WriteLine("Round Trip: {0}", roundtrip);

                    Console.WriteLine("KeySize: " + myAes.KeySize);
                    Console.WriteLine("BlockSize: " + myAes.BlockSize);
                    Console.WriteLine("Key: " + myAes.Key);
                    Console.WriteLine("IV: " + myAes.IV);
                }

            }
            
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
