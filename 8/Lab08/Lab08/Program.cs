using System;
using System.Collections.Generic;
namespace Lab08
{
    class Programmer
    {
        public delegate void method(string _property);
        public event method rename;
        public event method newProperty;
        string name;
        List<string> properties = new List<string>();
        float version;
        List<string> operations = new List<string>();
        int counter = 0;
        public Programmer(string _name, string _property, float _version, string _operation)
        {
            name = _name;
            properties.Add(_property);
            version = _version;
            operations.Add(_operation);
            counter++;
        }

        public void Rename(string _name)
        {
            rename(_name);
        }
        public void newName(string _name)
        {
            Console.WriteLine("Метод rename");
            name = _name;
        }
        public void newproperty(string _property)
        {
            newProperty(_property);   
        }
        public void NewProperty(string _property)
        {
            Console.WriteLine("метод NewProperty");
            properties.Add(_property);
            counter++;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {
            Programmer lang1 = new Programmer("c#", "Полиморфизм", 123, "+");
            lang1.rename += lang1.newName;
            lang1.newProperty += lang1.NewProperty;
            lang1.Rename("c++");
            lang1.newproperty("Абстракция");



        }
    }
}
