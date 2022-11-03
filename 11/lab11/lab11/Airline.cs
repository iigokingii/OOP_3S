using System;
using System.Collections.Generic;
using System.Text;

namespace lab11
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

        public void showelem(string elem)
        {
            Console.WriteLine(elem);
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

}
