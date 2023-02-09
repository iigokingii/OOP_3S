using System;

namespace lab04
{
    partial class land
    {
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
}
