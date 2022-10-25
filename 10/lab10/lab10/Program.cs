using System;
using System.Collections.Generic;
using System.Linq; 
namespace lab10
{
    class Airline
    {
        readonly string id = Guid.NewGuid().ToString();
        static int counter = 0;
        static string type;
        string pointOfDeparture;
        int number;
        const string time = "21:35";
        string day;
        public Airline()
        {
            pointOfDeparture = "Minsk";
            number = 222123;
            day = "wed";
            counter++;
        }
        public Airline(string point, int number, string day)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
            counter++;
        }
        public Airline(int number, string day)
        {
            this.pointOfDeparture = "vileyka";
            this.number = number;
            this.day = day;
            counter++;
        }
        static Airline()
        {
            type = "luxe";
        }
        private Airline(string point, int number, string day, string constructor)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
        }
        public override int GetHashCode()
        {
            int Hash;
            Hash = (this.number - 12) / 123;
            Console.WriteLine($"Hashcode:{Hash}");
            return Hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Airline m = obj as Airline;
            if (m as Airline == null)
                return false;
            return m.day == this.day && m.id == this.id && m.number == this.number && m.pointOfDeparture == this.pointOfDeparture;
        }

        public override string ToString()
        {
            return $"id:{id} type:{type} point of departure:{pointOfDeparture} number:{number} time:{time} day:{day} №{counter}";
        }
        public int Number
        {
            set
            {
                number = value;
            }
            get
            {
                return number;
            }
        }
        public string PointOfDeparture
        {
            set
            {
                pointOfDeparture = value;
            }
            get
            {
                return pointOfDeparture;
            }
        }
        public string Day
        {
            set
            {
                day = value;
            }
            get
            {
                return day;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }
        public string Time
        {

            get
            {
                return time;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public int Counter
        {
            get
            {
                return counter;
            }
        }
        public static void Print(Airline airline) => Console.WriteLine($"id:{airline.Id} type:{type} point of departure:{airline.pointOfDeparture} number:{airline.number} time:{time} day:{airline.day} №{counter}");
    }



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
