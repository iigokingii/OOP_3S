using System;
using System.Collections.Generic;
using System.Linq; 
namespace lab10
{
    class Airline
    {
        readonly string id = Guid.NewGuid().ToString();
        static int counter = 0;
        string type;
        string pointOfDeparture;
        int number;
        double time = 21.35;
        string day;
        public Airline()
        {
            pointOfDeparture = "Minsk";
            number = 222123;
            day = "Wednesday";
            counter++;
        }
        public Airline(string point, int number, string day,double _time)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
            time = _time;
            counter++;
        }
        public Airline(int number, string day, double _time)
        {
            this.pointOfDeparture = "Vileyka";
            this.number = number;
            this.day = day;
            time = _time;
            counter++;
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
        public double Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public int Counter
        {
            get
            {
                return counter;
            }
        }

        public static void Print(Airline airline) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tFlight");
            Console.ResetColor();
            Console.WriteLine($" id:{airline.Id};\n type:{airline.type};\n point of departure:{airline.pointOfDeparture};\n number:{airline.number};\n time:{airline.time};\n day:{airline.day};\n"); 
        }
    }



    class Program
    { 
        static void Main(string[] args)
        {
            string change(string type)
            {
                return type.Substring(0, 1).ToUpper() + type.Substring(1, type.Length - 1).ToLower();
            }
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
            List<Airline> airlines = new List<Airline>();

            Airline flight1 = new Airline();
            flight1.Day = "Friday";
            flight1.Time = 13.52;
            flight1.Number = 554;
            flight1.Type = "First class";
            Airline.Print(flight1);

            Airline flight2 = new Airline();
            flight2.Type = "Second class";
            Airline.Print(flight2);

            Airline flight3 = new Airline("LA", 2221111, "Tuesday",4.21);
            flight3.Type = "Luxe";
            Airline.Print(flight3);

            Airline flight4 = new Airline(666777, "sunday",6.57);
            flight4.Type = "Second Class";
            Airline.Print(flight4);

            Airline flight5 = new Airline();
            flight5.Number = 1177;
            flight5.PointOfDeparture = "Brest";
            flight5.Day = "Sunday";
            flight5.Time = 19.45;
            flight5.Type = "Business";
            Airline.Print(flight5);

            Airline flight6 = new Airline("Minsk",4432, "Thursday", 11.11);
            flight6.Type = "Luxe";
            Airline.Print(flight6);

            Airline flight7 = new Airline("Klimovichi", 22, "Sunday", 14.50);
            flight7.Type = "Second class";
            Airline.Print(flight7);

            Airline flight8 = new Airline("Hoyniki", 34, "Monday", 12.24);
            flight8.Type = "Luxe";
            Airline.Print(flight8);

            Airline flight9 = new Airline("Vileyka", 656, "Tuesday", 7.21);
            flight9.Type = "Business";  
            Airline.Print(flight9);

            Airline flight10 = new Airline("Ivye", 434, "Wednesday", 6.36);
            flight10.Type = "First class";                  
            Airline.Print(flight10);

            airlines.Add(flight1);
            airlines.Add(flight2);
            airlines.Add(flight3);
            airlines.Add(flight4);
            airlines.Add(flight5);
            airlines.Add(flight6);
            airlines.Add(flight7);
            airlines.Add(flight8);
            airlines.Add(flight9);
            airlines.Add(flight10);

            Console.WriteLine("Введите куда нужно прилететь?");
            string temp=Console.ReadLine();
            temp = change(temp);

            IEnumerable<Airline> ListOfFlights = airlines.Where(n => n.PointOfDeparture == temp)
                                                         .Select(n => n);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nРейсы до {0}",temp) ;
            Console.ResetColor();
            foreach(Airline obj in ListOfFlights)
            {
                Airline.Print(obj);
            }


            Console.WriteLine("Введите день недели, на который нужно искать билеты:");
            temp=Console.ReadLine();
            temp = change(temp);
            IEnumerable<Airline> ListForDay = airlines
                                                    .Where(n => n.Day == temp)
                                                    .Select(n => n);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nРейсы на {0}", temp);
            Console.ResetColor();
            foreach (Airline obj in ListForDay)
            {
                Airline.Print(obj);
            }

            IEnumerable<Airline> MaxDay = airlines.Where(n => n.Day == airlines.Max(n=>n.Day))
                                                  .Select(n =>n);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nМаксимальны по дню недели рейс:");
            Console.ResetColor();
            foreach (Airline obj in MaxDay)
            {
                Airline.Print(obj);
            }


            Console.WriteLine("Введите день недели, на который нужно искать билет:");
            temp = Console.ReadLine();


            double t = airlines.Max(a => a.Time);
            IEnumerable<Airline> LastFlightInDay = airlines.Where(n => n.Day == temp || n.Time == airlines.Max(a => a.Time))
                                                           .Select(n => n);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Все рейсы на {0} и самый поздний рейс в неделю",temp);
            Console.ResetColor();
            foreach(Airline obj in LastFlightInDay)
            {
                Airline.Print(obj);
            }
            IEnumerable<Airline> OrderedByDayAndTime = airlines.OrderBy(n => n.Day).ThenBy(n=>n.Time);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Упорядоченные по дню недели и времени :");
            Console.ResetColor();
            foreach(Airline obj in OrderedByDayAndTime)
            {
                Airline.Print(obj);
            }

            Console.WriteLine("Какой тип искать? ");
            string type = Console.ReadLine();
            type = change(type);
            int count = airlines.Count(n => n.Type == type);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0} самолетов типа {1}",count,type);
            Console.ResetColor();



        }
    }
}
