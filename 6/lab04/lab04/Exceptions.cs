using System;

namespace lab04
{
    class DevException : Exception
    {
        public DevException(string message) : base(message) { }
        public DevException() : base() { }
    }
    class ArgumentDevLessThanZeroException : ArgumentOutOfRangeException
    {
        int value { get; }
        public ArgumentDevLessThanZeroException(string message, int _value) : base(message)
        {
            value = _value;
        }
    }
    class DeException : Exception
    {
        public DeException(string message) : base(message) { }
    }



}
