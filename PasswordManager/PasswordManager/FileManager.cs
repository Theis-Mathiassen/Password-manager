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
    static class FileManager
    {
        public static string JSONFileFromFileExplorer (string InitialDir = null)
        {
            string passwordPath = "";
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = InitialDir ?? "c:\\";
                openFileDialog.Filter = "JSON files (*.JSON)|*.JSON";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    passwordPath = openFileDialog.FileName;
                }
            }
            return passwordPath;
        }

        

    }
}
