using System;
using System.IO;

namespace People.iOS
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libPath = Path.Combine(path, "..", "Library");

            if (!Directory.Exists(libPath))
            {
                Directory.CreateDirectory(libPath);
            }

            return Path.Combine(libPath, filename);
        }
    }
}
