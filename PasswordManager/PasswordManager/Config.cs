using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordManager
{
    public class SaveFileData
    {
        public SaveFileData ()
        {

        }
        public SaveFileData(string Path)
        {
            this.Path = Path;
            this.Date = DateTime.Now;
        }
        public SaveFileData(string Path, DateTime dateTime)
        {
            this.Path = Path;
            this.Date = dateTime;
        }

        public string Path { get; set; }
        public DateTime Date { get; set; }
    }
    public class Activity
    {
        public DateTime usageTime;
    }

    public class ConfigObject
    {
        public List<SaveFileData> PreviousPaths = new List<SaveFileData>();
        public SaveFileData LastPath;
        public List<Activity> activities;
    }

    public static class Config
    {
        static ConfigObject CObject = new ConfigObject();

        public static void SetLastPath(string Path)
        {
            CObject.LastPath = new SaveFileData(Path);
        }

        public static string GetLastPath()
        {
            string result = "";
            if (CObject.LastPath == null)
            {
                result = null;
            } else
            {
                result = CObject.LastPath.Path;
            }
            return result;
        }

        public static string GetPreviousPath (string path)
        {
            return CObject.PreviousPaths.Find(item => item.Path == path).Path;
        }
        public static List<string> GetPreviousPath (int count)
        {
            List<string> listString = new List<string>();
            List<SaveFileData> listSaveData;
            if (count == -1)
            {
                listSaveData = CObject.PreviousPaths;
            }
            else
            {
                listSaveData = CObject.PreviousPaths.GetRange(Math.Max(CObject.PreviousPaths.Count - (count + 1), 0), Math.Min(CObject.PreviousPaths.Count, count));
            }
            
            
            for (int i = 0; i < listSaveData.Count; i++)
            {
                listString.Add(listSaveData[i].Path);
            }
            return listString;
        }

        public static void AddPreviousPath(Form1 mainForm, string path)
        {
            
            SaveFileData fileData = CObject.PreviousPaths.Find(item => item.Path == path);
            if (fileData == null)
            {
                CObject.PreviousPaths.Add(new SaveFileData(path));
            }
            else
            {
                RemovePath(path);
                CObject.PreviousPaths.Add(new SaveFileData(path));
            }
            mainForm.RecentToolStripMenuItemUpdateValues();
        }
        public static void RemovePath(string path)
        {
            CObject.PreviousPaths.RemoveAll(item => item.Path == path);
        }

        public static void SaveToFile()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"PasswordManager\Configoration.JSON");
                string JSONString = JsonConvert.SerializeObject(CObject);
                Console.WriteLine("Path: {0}, JSON: {1}", path, JSONString);
                //Create dir if does not exist.
                if (Directory.Exists(path))
                {
                    File.WriteAllText(path, JSONString);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                    File.WriteAllText(path, JSONString);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not write to settings file, try again.");
                Console.WriteLine(e.HelpLink);
            }
        }
        public static void LoadFromFile()
        {
            try
            {
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"PasswordManager\Configoration.JSON");
                string JSONString = File.ReadAllText(path);
                CObject = JsonConvert.DeserializeObject<ConfigObject>(JSONString);
                CObject.PreviousPaths.RemoveAll(item => item.Path == null);
            }
            catch (IOException)
            {
                CObject = new ConfigObject();
            }
            
        }
    }
}
