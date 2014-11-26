using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesAndAges = new Dictionary<string, int>/*(StringComparer.CurrentCultureIgnoreCase)*/
            {
                {"Jeremy", 35}
            };

            namesAndAges.Add("Josh", 25);
            namesAndAges["Kristin"] = 39;
            //namesAndAges.Add("Jeremy", 30); // an exception
            namesAndAges["Jeremy"] = 30;
            if (namesAndAges.ContainsKey("Caleb"))
            {
                var foo = namesAndAges["Caleb"]; //
            }

            foreach (var kvp in namesAndAges)
            {
                //kvp.Key
                //kvp.Value
            }

            foreach (var key in namesAndAges.Keys)
            {

            }

            foreach (var value in namesAndAges.Values)
            {

            }

            var count = namesAndAges.Count;

            if (namesAndAges.ContainsKey("Josh"))
            {
                namesAndAges.Remove("Josh");
            }

            namesAndAges.Clear();



            Console.ReadLine();
        }
    }
}
