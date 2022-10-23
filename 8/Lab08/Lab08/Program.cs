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
            Console.WriteLine($"Метод rename in {name}");
            name = _name;
        }
        public void NewVersion(string _version)
        {
            Console.WriteLine($"Метод newversion in {name}");
            version = _version;
        }

        public void addProperty(string _property)
        {
            Console.WriteLine($"Метод addProperty in {name}");
            properties.Add(_property);
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Programmer programmer = new Programmer("Ваня","3","ИСиТ");
            Language lang1 = new Language("c#", "Полиморфизм", "11", "+");

            programmer.rename += lang1.Rename;
            programmer.Rename("java");
            programmer.rename -= lang1.Rename;

            programmer.newProperty += lang1.addProperty;         
            programmer.newproperty("Абстракция");

            programmer.rename += lang1.NewVersion;
            programmer.newVersion("10"); 

            Language lang2 = new Language("java", "Объектно-ориентированный", "16", "-");
            
            programmer.newProperty += lang2.addProperty;
            programmer.newproperty("Инкапсуляция");
            programmer.newProperty -= lang1.addProperty;

            programmer.rename += lang2.Rename;
            programmer.Rename("assembly");
            programmer.rename -= lang1.Rename;
            programmer.rename -= lang2.Rename;

            Language lang3 = new Language("с++", "Статически типизированный", "16.7", "/");

            programmer.newProperty += lang3.addProperty;
            programmer.newproperty("Компилируемый");
            






        }
    }
}
