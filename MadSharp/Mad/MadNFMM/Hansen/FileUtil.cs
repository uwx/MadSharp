using System;
using System.IO;

namespace Cum
{
    internal class FileUtil
    {
        public static void LoadFiles(string folder, string[] fileNames, Action<byte[], int> p3)
        {
            fileNames = fileNames.CloneArray();
            foreach (var file in Directory.GetFiles(folder))
            {
                var a = fileNames.IndexOf(Path.GetFileNameWithoutExtension(file));
                if (a != -1)
                {
                    p3.Invoke(System.IO.File.ReadAllBytes(file), a);
                }
            }
        }
    }
}