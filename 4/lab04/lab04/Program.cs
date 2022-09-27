using System;

namespace lab04
{
    interface IInformation
    {
        void print();
    }
    abstract class surface
    {
        public void Surface()
        {
            Console.WriteLine("Вы находитесь на поверхности земли");
        }
    }
    class land:surface
    {
        int square;
        public int Square
        {
            get
            {
                return this.square;
            }
            set
            {
                this.square = value;
            }
        }
        

    }
   sealed class continent : land
    {
        string name;
        public string Name(string name)
        {
            return this.name = name;
        }
        public class state:land
        {
            string StateName;
            public string name
            {
                get
                {
                    return this.StateName;
                }
                set
                {
                    this.StateName = value;
                }
            }
        }
        public override string ToString()
        {
            return $"name:{name}, square:{Square}";
        }
        public override int GetHashCode()
        {
            int hash = (Square / 3) * 4;
            return hash;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var otherObj = (continent)obj;
            return (otherObj.Square == this.Square)&&(otherObj.name==this.name);
        }
    }
    class island : land
    {
        public string Name ;
    }

    class water
    {
        int volumeOfAllWater;
        public water() {
            volumeOfAllWater = 1400000000;           
        }
        public water(int volume)
        {
            volumeOfAllWater = volume;
        }
    }
    class sea : water
    {
        string name="Atlantic ocean";
        public string Name(string Name)
        {
            return this.name = Name;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            land obj = new land();
            obj.Square= 123999;
            obj.Surface();
            continent obj2 = new continent();
            obj2.Name("Евразия");
            obj2.Square=14430;
            string stroke=obj2.ToString();
            Console.WriteLine(stroke);

            continent.state obj3 = new continent.state();
            obj3.name = "Belarus";



            island obj4 = new island();
            obj4.Name = ("Hawaiian Islands");
            obj4.Square= 28311;
            sea obj5 = new sea();
            obj5.Name("Pacific ocean");

        }
    }
}
