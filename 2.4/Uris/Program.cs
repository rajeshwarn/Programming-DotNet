using System;

namespace Uris
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new Uri("http://www.mywebsite.com/path/to/resource/?key=value&key2=value2#fragment");

            var httpScheme = http.Scheme; // http
            var httpHost = http.Host; // www.mywebsite.com
            var httpPort = http.Port; // 80
            var httpAuthority = http.Authority; // www.mywebsite.com
            var httpPath = http.AbsolutePath; // /path/to/resource/
            var httpQuery = http.Query; // ?key=value&key2=value2 
            var httpPathQuery = http.PathAndQuery; // /path/to/resource/?key=value&key2=value2
            var httpFragment = http.Fragment; // #fragment
            var httpAbsoluteUri = http.AbsoluteUri; // http://www.mywebsite.com/path/to/resource/?key=value&key2=value2#fragment

            var unc = new Uri(@"\\servername\path\to\share\file.txt");
            // file://servername/path/to/share/file.txt

            var uncScheme = unc.Scheme; // file
            var uncHost = unc.Host; // servername
            var uncPort = unc.Port; // -1
            var uncAuthority = unc.Authority; // servername
            var uncPath = unc.AbsolutePath; // /path/to/share/file.txt
            var uncQuery = unc.Query; // string.Empty
            var uncPathQuery = unc.PathAndQuery; // /path/to/share/file.txt
            var uncFragment = unc.Fragment; // string.Empty
            var uncAbsoluteUri = unc.AbsoluteUri; // file://servername/path/to/share/file.txt

            var escapedUri = Uri.EscapeUriString("http://www.mywebsite.com");
            var escapedStuff = Uri.EscapeDataString("string to escape");

            Uri.UnescapeDataString(escapedStuff);

        }
    }
}
