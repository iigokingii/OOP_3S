using System;
using System.Collections.Generic;
namespace Lab08
{
    class Programmer
    {
        string statement;
        string name;
        public int course;
        string speciality;
        public delegate void method(string tmp);
        public event method? rename;
        public event method? newProperty;
        public void Rename(string _name) => rename?.Invoke(_name);
        public void newproperty(string _property) => newProperty?.Invoke(_property);
        public void newVersion(string _version) => rename?.Invoke(_version);
        public Programmer(string _name, int _course, string _speciality)
        {
            name = _name;
            course = _course;
            speciality = _speciality;
        }
        public string Statement
        {
            get
            {
                return statement;
            }
            set
            {
                statement = value;
            }
        }
        public void deleteT(Action <string> action)
        {
            for (int i = 0; i < statement.Length; i++)
            {
                if (statement[i] == '\t')
                {
                    statement = statement.Remove(i, 1);
                    i++;
                }
            }
           action(statement);
        }
        public void ShowText(string text)=> Console.WriteLine($"text: {text}");
        public void Upper(Action<string> action)
        {
            statement = statement[0].ToString().ToUpper() + statement.Substring(1);
            action(statement);
        }
        public bool isfour(int value, Predicate<int> predicate) => predicate(value);

        public void add(Func <string,string> func)
        {
            string add = "Gotovko ";
            int temp = statement.IndexOf("Vova");
            statement = statement.Insert(temp, add);
            statement=func(statement);

        }

        public string deleteSign(string _statement)
        {
            for (int i = 0; i < _statement.Length; i++)
            {
                if (_statement[i] == '?')
                {
                    _statement = _statement.Remove(i, 1);
                    i++;
                }
            }
            return _statement;
        }
        public void deleteDot(Action<string> action)
        {
            for (int i = 0; i < statement.Length; i++)
            {
                if (statement[i] == '.')
                {
                    statement = statement.Remove(i, 1);
                    i++;
                }
            }
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
            Programmer programmer = new Programmer("Ваня",3,"ИСиТ");
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
            programmer.newProperty -= lang1.NewVersion;
            programmer.newProperty -= lang2.addProperty;
            programmer.newProperty -= lang3.addProperty;


            programmer.Statement = "\thello! My\t na.me .is. Vo\tva.\t?";

            //Action
            programmer.deleteT(programmer.ShowText);
            programmer.Upper(programmer.ShowText);
            programmer.deleteDot(programmer.ShowText);

            //Predicate
            Console.WriteLine(programmer.isfour(programmer.course, delegate (int x) { return x == 4; })) ;

            //Func
            programmer.add(programmer.deleteSign) ;           
        }
    }
}
