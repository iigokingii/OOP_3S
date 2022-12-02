using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
namespace lab13
{
    interface IInformation
    {
        void DoClone();
    }
    [Serializable]
    abstract class surface
    {
        public void Surface()
        {
            Console.WriteLine("Вы находитесь на поверхности Земли");
        }
        public abstract void DoClone();
    }
    [Serializable]
    class Land : surface, IInformation
    {

        protected int square;
        public string TypeOfLand;
        public Land() { }
        public Land(int _square, string _typeOfLand)
        {
            Square = _square;
            TypeOfLand = _typeOfLand;
        }
        public virtual int Square
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
        public override void DoClone()
        {
            Console.WriteLine("вызван переопределенный метод из абстрактного класса");
        }
        void IInformation.DoClone()
        {
            Console.WriteLine("вызван метод интерфейса");
        }
        public virtual string ToString()
        {
            return $"type: land, square:{this.square}, type of land: {this.TypeOfLand}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Land land = new Land(50505,"Coal");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("land.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, land);
            }
            using (FileStream fs = new FileStream("land.dat", FileMode.OpenOrCreate))
            {
                Land newland = (Land)formatter.Deserialize(fs);
                Console.WriteLine(newland.ToString());
            }

        }
    }
}
