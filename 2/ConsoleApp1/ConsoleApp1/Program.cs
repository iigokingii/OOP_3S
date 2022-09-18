using System;
namespace labo2
{
    partial class Airline
    {

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
           



        }
    }
}
