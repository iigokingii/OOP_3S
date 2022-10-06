using System;
namespace labo2
{
    partial class Airline
    {
        readonly string id=Guid.NewGuid().ToString();
        static int counter = 0;
        static string type;
        string pointOfDeparture;
        int number;
        const string time="21:35";
        string day;
        public Airline()
        {
            pointOfDeparture = "Minsk";
            number = 222123;
            day = "wed";
            counter++;
        }
        public Airline(string point,int number,string day)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
            counter++;
        }
        public Airline(int number,string day)
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
    }
    class Class1
    {
        static void Main(string[] args)
        {
            Airline obj = new Airline();
            Airline.Print(obj);
            Airline obj1 = new Airline("vileyka", 2221111,"tue");
            Airline.Print(obj1);
            Airline obj2 = new Airline(666777, "sunday");
            Airline.Print(obj2);
            //Airline obj3 = new Airline("vitebsk", 222331, "23:00", "monday", "private");
            Airline obj4 = new Airline();
            obj4.Number = 222123;
            obj4.PointOfDeparture = "Brest";
            obj4.Day = "sunday";
            Console.WriteLine($"id:{obj4.Id} type:{obj4.Type} point of departure:{obj4.PointOfDeparture} number:{obj4.Number} time:{obj4.Time} day:{obj4.Day} №{obj4.Counter}");

            Airline[] arr = { obj, obj1, obj2, obj4 };
            Console.WriteLine("Какой пункт необходимо искать?");
            string destination;
            destination=Console.ReadLine();
            for(int j = 0; j < arr.Length; j++)
            {
                if(arr[j].PointOfDeparture==destination)
                {
                    Console.WriteLine($"id:{arr[j].Id} type:{arr[j].Type} point of departure:{arr[j].PointOfDeparture} number:{arr[j].Number} time:{arr[j].Time} day:{arr[j].Day} ");
                }
            }
            Console.WriteLine("На какой день недели нужно искать?");
            string dayOfWeek;
            dayOfWeek = Console.ReadLine();
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i].Day==dayOfWeek)
                {
                    Console.WriteLine($"id:{arr[i].Id} type:{arr[i].Type} point of departure:{arr[i].PointOfDeparture} number:{arr[i].Number} time:{arr[i].Time} day:{arr[i].Day} ");
                }
            }
            string hash = obj.GetHashCode().ToString();
            if (obj.Equals(obj2))
                Console.WriteLine("равны");
            else
                Console.WriteLine("не равны");

            void difference(ref int a,ref int b,out int result)
            {
                int temp = a;
                a = b;
                b = temp;
                result = b - a;
            }

            int aValue = 12;
            int bValue = 10;
            int resultValue;
            difference(ref aValue, ref bValue,out resultValue);
            Console.WriteLine($"aValue after method:{aValue},\t\tbValue:{bValue},\t\tresult:{resultValue}");

            var airline = new { number = 312312, type = "First class", pointOfDeparture = "grodno", time = "22:11", day = "wednesday", id = Guid.NewGuid().ToString() };
            Console.WriteLine($"Анонимный тип:\nid:{airline.id} type:{airline.type} point of departure:{airline.pointOfDeparture} number:{airline.number} time:{airline.time} day:{airline.day} ");

        }
    }
}
