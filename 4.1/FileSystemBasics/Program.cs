using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToMyDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            var path = string.Format(@"{0}{1}file.txt", pathToMyDocs, Path.DirectorySeparatorChar);

            

            if (File.Exists(path))
            {
                //File.Delete(path);
                var lines = File.ReadAllLines(path);
                var content = File.ReadAllText(path);

                var file = new FileInfo(path);

            }
            else
            {
                File.AppendAllLines(path, new[] { "line 1", "line 2" });
                File.AppendAllText(path, "append this");
                File.AppendAllText(path, "append this");

                File.WriteAllLines(path, new[] { "line 3", "line 4" });
                File.WriteAllText(path, "new content");

            }

            var files = Directory.GetFiles(pathToMyDocs);

            //Directory.Move(pathToMyDocs, )

            if (!Directory.Exists(pathToMyDocs))
            {
                var dir = Directory.CreateDirectory(pathToMyDocs);

                
            }
        }
    }
}
