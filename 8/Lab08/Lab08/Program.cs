using System;
using System.Collections.Generic;
namespace Lab08
{
    enum operation
    {
        addOperation,
        addProperty
    }
    class Programmer
    {
        string name;
        string course;
        string speciality;
        public delegate void method(string tmp);
        public event method? rename;
        public event method? newProperty;
        public void Rename(string _name) => rename?.Invoke(_name);
        public void newproperty(string _property) => newProperty?.Invoke(_property);
        public void newVersion(string _version) => rename?.Invoke(_version);
        public Programmer(string _name, string _course,string _speciality)
        {
            name = _name;
            course = _course;
            speciality = _speciality;
        }

    }

    class Language
    {
        string name;
        List<string> properties = new List<string>();
        string version;
        List<string> operations = new List<string>();
        
        public Language(string _name, string _property, string _version, string _operation)
        {
            name = _name;
            properties.Add(_property);
            version = _version;
            operations.Add(_operation);
        }


        public void Rename(string _name)
        {
            Console.WriteLine("Метод rename");
            name = _name;
        }
        public void NewVersion(string _version)
        {
            Console.WriteLine("Метод newversion");
            version = _version;
        }

        public void addProperty(string _property)
        {
            Console.WriteLine("Метод addProperty");
            properties.Add(_property);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer1 = new Programmer("Ваня","3","ИСиТ");
            Language lang1 = new Language("c#", "Полиморфизм", "11", "+");

            programmer1.rename += lang1.Rename;
            programmer1.Rename("java");
            programmer1.rename -= lang1.Rename;

            programmer1.newProperty += lang1.addProperty;         
            programmer1.newproperty("Абстракция");

            programmer1.rename += lang1.NewVersion;
            programmer1.newVersion("10"); 

            Language lang2 = new Language("java", "Объектно-ориентированный", "16", "-");
            programmer1.newProperty += lang2.addProperty;
            programmer1.newproperty("Инкапсуляция");

            Language lang3 = new Language("с++", "Статически типизированный", "16.7", "/");






        }
    }
}
