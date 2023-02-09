using System;
using System.Collections.Generic;
using System.Text;

namespace lab04
{
    class land : surface, IInformation
    {
       
        protected int square;
        public string TypeOfLand;
        public land() { }
        public land(int _square, string _typeOfLand)
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
        void  IInformation.DoClone()
        {
            Console.WriteLine("вызван метод интерфейса");
        }
        public virtual string ToString()
        {
            return $"type: land, square:{this.square}, type of land: {this.TypeOfLand}
        }

    }
}
