using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new[] { "Jeremy", "John", "Zed" };
            var foo = Array.Exists(names, element => element.StartsWith("J"));
            //var nameWithJ = Array.Find(names, element => element.StartsWith("J"));
            var nameWithJ = Array.FindLast(names, element => element.StartsWith("J"));
            var namesWithJ = Array.FindAll(names, element => element.StartsWith("J"));
            Array.ForEach(namesWithJ, name => Console.WriteLine(name));
            //foreach (var name in namesWithJ)
            //{
            //    Console.WriteLine(name);
            //}

            var indexWithJ = Array.FindIndex(names, element => element.StartsWith("J")); // 0
            var lastIndexWithJ = Array.FindLastIndex(names, element => element.StartsWith("J")); // 1

            var index = Array.IndexOf(names, "Zed"); // 2
            var lastIndex = Array.LastIndexOf(names, "John"); // 1

            Array.Reverse(names);
            Array.Sort(names);
            var chars = Array.ConvertAll(names, element => element[0]);
            Array.ForEach(chars, c => Console.WriteLine(c));
            Array.Clear(names, 0, names.Length);

            Console.ReadLine();
        }

        private static void CopyCode()
        {
            var numbers1 = new[] { 15, 10, 1 };
            var numbers2 = new int[numbers1.Length];

            //numbers1.CopyTo(numbers2, 0);
            Array.Copy(numbers1, numbers2, numbers1.Length);
            numbers2[0] = 90;

            Console.WriteLine(numbers1[0]);
            Console.WriteLine(numbers2[0]);
        }
    }
}
