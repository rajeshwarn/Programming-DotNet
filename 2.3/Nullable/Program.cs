using System;

namespace Nullable
{
    class Program
    {
        static void Main(string[] args)
        {
            int? foo = null;

            if (foo.HasValue)
            {
                var sum = 10 + foo;
            }

            DateTime? bar = null;

            bar = DateTime.Now;
        }
    }
}
