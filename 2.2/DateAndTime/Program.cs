using System;

namespace DateAndTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var usaDate1 = "02-12-2014";
            var usaDate2 = "02/13/2014";
            var dateString = "201402";

            var date1 = DateTime.ParseExact(usaDate1, "MM-dd-yyyy", null);
            var date2 = DateTime.ParseExact(usaDate2, "MM/dd/yyyy", null);
            DateTime date3;
            var areSame = date1 == date2; // false

            var foo = date2 > date1; // true

            // hh:mm:ss

            if (DateTime.TryParseExact(dateString, "yyyyMM", null, 
                System.Globalization.DateTimeStyles.None, out date3))
            {
                // do something with the date3
                // or something else
            }

            var difference = date2 - date1; // TimeSpan
            var isSpanOfDay = difference > TimeSpan.FromHours(23); // true
        }
    }
}
