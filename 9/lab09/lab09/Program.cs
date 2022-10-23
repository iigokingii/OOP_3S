using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Collections;
namespace lab09
{
    class Services : IOrderedDictionary,
    {
        ArrayList _people;
        Queue type;
        public void Add(object key, object value)
        {
            type.Enqueue(new DictionaryEntry(key, value));
        }
        public int Count
        {
            get
            {
                return type.Count;
            }
        }
        public bool IsSynchronized
        {
            get
            {
                return type.IsSynchronized;
            }
        }
        public object SyncRoot
        {
            get
            {
                return type.SyncRoot;
            }
        }
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
