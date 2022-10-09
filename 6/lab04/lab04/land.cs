using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace lab04
{
    partial class land : surface, IInformation
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
                if (square == 100000)
                {
                    throw new DeException("Площадь ровно 100000");
                }
            }
        }
       
    }
}
