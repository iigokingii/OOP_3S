using System;
using System.Collections.Generic;
using System.Text;

namespace lab04
{
    class DevException:Exception
    {
        public DevException(string message) : base(message) { }
        public DevException() : base() { }
    }
    class ArgumentDevException : ArgumentException
    {
        int value;
        int Value { get; }
        public ArgumentDevException(string message, int _value):base(message)
        {
            value = _value;
        }
    }
}
