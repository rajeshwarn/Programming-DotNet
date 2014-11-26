using System;
using System.Collections.Generic;

namespace ListOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> {
                "Jeremy",
                "Jason",
                "Zed"
            };

            //names[3] = "Jessica";
            names.Add("Caleb"); // 5
            names.AddRange(new[] { "Phillip", "Patrick" }); // 6, 7
            names.Insert(0, "Kim");
            names.Add("Jeremy");
            //names.InsertRange(0, new[] { });

            var index = names.IndexOf("Jeremy"); // 1
            //names.LastIndexOf();
            var contains = names.Contains("Jeffrey"); // false
            var nameWithJ = names.Find(s => s.StartsWith("J")); // Jeremy
            var namesWithJ = names.FindAll(s => s.StartsWith("J")); // all j names
            // names.FindIndex()
            // names.FindLast()
            // names.FindLastIndex()

            var chars = names.ConvertAll(s => s[0]);

            names.Remove("Jeremy");
            names.RemoveAll(s => s == "Jeremy");
            names.RemoveAt(0);
            names.RemoveRange(0, names.Count);
            names.Clear();

            var people = new People();

            var names2 = new List<string>(people.Names);

            names2.Remove("Jeremy");
            Console.ReadLine();
        }
    }

    public class People
    {
        private readonly List<string> _names = new List<string>();

        public People()
        {
            _names.AddRange(new[] {
                "Jeremy",
                "Jason",
                "Zed"
            });
        }

        public IEnumerable<string> Names
        {
            get { return _names.ToArray(); }
        }
    }
}
