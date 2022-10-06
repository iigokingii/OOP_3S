using System;
using System.Collections.Generic;
using System.Text;

namespace lab04
{
    class sea : water
    {
        string name;
        public sea() { }
        public sea(int _volume, string _name)
        {
            name = _name;
            volumeOfAllWater = _volume;
        }
        public override string ToString()
        {
            return $"type:sea, name:{name}, volume of all water: {volumeOfAllWater}";
        }
    }

}
