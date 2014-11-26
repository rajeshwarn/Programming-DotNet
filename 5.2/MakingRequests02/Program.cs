using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MakingRequests02
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = PostRequest("http://www.wdonline.com");

            task.ContinueWith(t => Console.WriteLine(t.Result));

            task.Wait();

            Console.ReadLine();
        }

        private async static Task<string> GetRequest(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "my own code");
                return await client.DownloadStringTaskAsync(url);
            }
        }

        private async static Task<string> PostRequest(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "my own code");
                client.Headers.Add("content-type", "x-www-form-urlencoded");
                return await client.UploadStringTaskAsync(url, "test=value");
            }
        }

        private async static Task GetRequestFile(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "my own code");
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                await client.DownloadFileTaskAsync(url, @"asdf");
            }
        }

        static void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            //e.
        }

        private async static Task<byte[]> PostRequestFile(string url)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "my own code");
                client.Headers.Add("content-type", "x-www-form-urlencoded");
                client.UploadProgressChanged += client_UploadProgressChanged;
                return await client.UploadFileTaskAsync(url, "asdf");
            }
        }

        static void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            //e.
        }

        static async Task WriteStreamAsync(string url)
        {
            using (var client = new WebClient())
            using (var writer = new StreamWriter(await client.OpenWriteTaskAsync(url)))
            {
                await writer.WriteAsync("test=value");
            }
        }

        static async Task<string> ReadStreamAsync(string url)
        {
            using (var client = new WebClient())
            using (var reader = new StreamReader(await client.OpenReadTaskAsync(url)))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
