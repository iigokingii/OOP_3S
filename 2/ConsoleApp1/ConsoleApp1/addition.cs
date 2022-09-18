using System;
using System.Collections.Generic;
using System.Text;

namespace labo2
{
    partial class Airline
    {
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
