using System;
using System.Collections.Generic;
using System.Linq; 
namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string[] SummerOrWinter = { "January", "February", "June", "July", "August", "December" };

            int N = 4;
            IEnumerable<string> lengthMonth = months
                .Where(n => n.Length == N)
                .Select(n => n);

            IEnumerable<string> SummerAndWinterMonths = months
                .Intersect(SummerOrWinter);

            IEnumerable<string> AlphabetOrder = months
                .OrderBy(n => n.First())
                .Select(n => n);
            Console.WriteLine("Вывод месяцев в алфавитном порядке: ");
            foreach(string tmp in AlphabetOrder)
            {
                Console.WriteLine(tmp);
            }

            IEnumerable<string> IncudeU = months
                .Where(n => n.Length > 4 && n.Contains('u'))
                .Select(n =>n);

            Console.WriteLine() ;





            
        }
    }
}
