using System;
using System.Collections.Generic;
using System.Text;

namespace lab04
{
    sealed class continent : land
    {
        string name;
        public continent() { }
        public continent(string _name,int _square,string _typeOfLand)
        {
            name = _name;
            Square = _square;
            TypeOfLand = _typeOfLand;
        }
        public class state
        {
            public state() { }
            public state(string _stateName)
            {
                StateName = _stateName;
            }
            string StateName;
            public override string ToString()
            {
                return $"Type: state, name: {StateName}";
            }
        }
        public override int Square
        {
            get
            {
                return this.square;
            }
            set
            {
                if (value > 100000)
                {
                    square = 99999;
                }
                else
                    square = value;
            }
        }
        public override string ToString()
        {
            return $"type: continent, name:{name}, square:{Square}, type of land: {TypeOfLand}";
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
            return (otherObj.Square == this.Square) && (otherObj.name == this.name);
        }
    }
}
