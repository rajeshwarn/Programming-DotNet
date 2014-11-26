using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ReadWriteStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathToMyDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = string.Format(@"{0}{1}file.txt", pathToMyDocs, Path.DirectorySeparatorChar);
            var pathToBinary = string.Format(@"{0}{1}file.bin", pathToMyDocs, Path.DirectorySeparatorChar);
            var task = WriteLineAsync(path);//ReadFirstLineAsync(path);

            task.ContinueWith(async w =>
            {
                await ReadFirstLineAsync(path).ContinueWith(t =>
                {
                    Console.WriteLine(t.Result);

                    Console.WriteLine(ReadBinary(pathToBinary));
                });
            });
                
            task.Wait();

            WriteBinary(pathToBinary);

            Console.ReadLine();
        }

        private async static Task<string> ReadFirstLineAsync(string path)
        {
            if (File.Exists(path))
            {
                //using (var reader = new StreamReader(path)
                using (var fs = File.Open(path, FileMode.Open))
                using (var reader = new StreamReader(fs))
                {
                    return await reader.ReadLineAsync();
                }
            }

            return null;
        }

        private async static Task WriteLineAsync(string path)
        {

            //using (var reader = new StreamReader(path)
            using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                await writer.WriteLineAsync("Hello async writer.");
            }
        }

        private static string ReadBinary(string path)
        {

            //using (var reader = new StreamReader(path)
            using (var fs = File.Open(path, FileMode.Open))
            using (var reader = new BinaryReader(fs))
            {
                return reader.ReadString();
            }
        }

        private static void WriteBinary(string path)
        {

            //using (var reader = new StreamReader(path)
            using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
            using (var writer = new BinaryWriter(fs))
            {
                writer.Write("Hello world");
            }
        }

        private async static Task FileCopyAsync(string source, string destination, bool overwrite = true)
        {
            if (!File.Exists(source))
            {
                throw new FileNotFoundException(source);
            }

            if (File.Exists(destination) && !overwrite)
            {
                return;
            }

            using (var sourceStream = File.Open(source, FileMode.Open, FileAccess.Read))
            using (var destStream = File.Create(destination))
            {
                await sourceStream.CopyToAsync(destStream);
            }
        }
    }
}
