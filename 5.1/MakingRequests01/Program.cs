using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MakingRequests01
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
            var request = WebRequest.CreateHttp(url);
            request.UserAgent = "my own code";

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async static Task<string> PostRequest(string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.UserAgent = "my own code";
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers["foo"] = "bar";
            using (var writer = new StreamWriter(await request.GetRequestStreamAsync()))
            {
                await writer.WriteAsync("test=value");
            }

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var value = response.Headers["foo"];
                return await reader.ReadToEndAsync();
            }
        }

        private async static Task PostRequestBinary(string url)
        {
            var request = WebRequest.CreateHttp(url);
            request.UserAgent = "my own code";
            request.Method = "POST";
            
            using (var stream = await request.GetRequestStreamAsync())
            using (var fs = File.Open("asdf", FileMode.Open, FileAccess.Read))
            {
                await fs.CopyToAsync(stream);
            }

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var fs = File.Create("asdf"))
            {
                await stream.CopyToAsync(fs);
            }
        }
    }
}
