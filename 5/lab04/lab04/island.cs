using System;
using System.Collections.Generic;
using System.Text;

namespace lab04
{
    class island : land
    {
        public string Name;
        public island() { }
        public island(int _square,string _typeOfLand,string _name)
        {
            Square = _square;
            TypeOfLand = _typeOfLand;
            Name = _name;
        }
        public override string ToString()
        {
            return $"type: island, square: {Square}, Name: {Name}, type of land: {TypeOfLand}";
        }
    }
}
