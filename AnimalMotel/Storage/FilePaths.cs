using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalMotel.Storage
{
    /// <summary>
    /// Class containing file paths that are used withinthe app.
    /// </summary>
    public class FilePaths
    {
        private static string DataStorageRootFolderPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(Directory.GetCurrentDirectory(), @"..\..\Storage\Data"));
            }
        }

        public static string AppSettingsFilePath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(DataStorageRootFolderPath, @".\Settings\AppSettings.xml"));
            }
        }

        public static string AnimalDataFolderPath
        {
            get
            {
                return Path.GetFullPath(
                    Path.Combine(DataStorageRootFolderPath, @".\AppData\Animals\"));
            }
        }

        
    }
}
