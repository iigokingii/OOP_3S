using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace lab11
{
    static class Reflector
    {
        static bool Flag=false;
        static public void WriteInit(IEnumerable<string> stroke,string rootNode,string name,string secondNode,string thirdNode)
        {
            XDocument xdoc = new XDocument();
            XElement type = new XElement($"{name}");

            XElement xElement = new XElement($"{secondNode}");
            foreach (string tmp in stroke)
            {
                xElement.Add(new XElement($"{thirdNode}", tmp));
            }
            XElement reflector = new XElement($"{rootNode}");
            type.Add(xElement);
            reflector.Add(type);
            xdoc.Add(reflector);
            xdoc.Save("Reflector.xml");
        }
        static public void Write(IEnumerable<string> stroke,string name,string secondNode,string thirdNode)//класс (xmlnode)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("Reflector.xml");

            XmlElement? root = (XmlElement)xdoc.SelectSingleNode($"Reflector/{name}");
            XmlElement xmlElement = xdoc.CreateElement($"{secondNode}");    //новый элемент(3-ий)
            foreach(string tmp in stroke)
            {
                XmlElement element = xdoc.CreateElement($"{thirdNode}");
                XmlText text = xdoc.CreateTextNode($"{tmp}");
                element.AppendChild(text);
                xmlElement.AppendChild(element);
            }
            root?.AppendChild(xmlElement);
            xdoc.Save("Reflector.xml");
        }
        static public void WriteN(IEnumerable<string> stroke, string name, string secondNode, string thirdNode)//класс (xmlnode)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xdoc.SelectSingleNode($"Reflector");
            XmlElement Element = xdoc.CreateElement($"{name}");
            XmlElement xmlElement = xdoc.CreateElement($"{secondNode}");
            foreach (string tmp in stroke)
            {
                XmlElement element = xdoc.CreateElement($"{thirdNode}");
                XmlText text = xdoc.CreateTextNode($"{tmp}");
                element.AppendChild(text);
                xmlElement.AppendChild(element);
            }
            Element.AppendChild(xmlElement);
            root?.AppendChild(Element);
            xdoc.Save("Reflector.xml");
        }



        static public IEnumerable<string> Interfaces(Type obj)
        {
            Console.WriteLine("\nInterfaces of {0}",obj.Name);
          
            IEnumerable<string> stroke = obj.GetInterfaces()
                                            .Where(n => n is Type)
                                            .Select(n => ((Type)n).Name);
            foreach(string str in stroke)
            {
                Console.WriteLine(str);  
            }
            if (!Flag)
            {
                WriteInit(stroke, "Reflector", $"{obj.Name}", "Interfaces", "Interface");
                Flag = true;
            }               
            else
                WriteN(stroke,$"{obj.Name}","Interfaces", "Interface");
            return stroke;
        }

        static public IEnumerable<string> Methods(Type obj)
        {
            Console.WriteLine("\n methods of {0}",obj.Name);
            IEnumerable<string> stroke =(IEnumerable<string>)obj.GetMethods(BindingFlags.Public|BindingFlags.Instance)
                                            .Where(n => n is MethodInfo)
                                            .Select(n => ((MethodInfo)n).Name);
            foreach (string str in stroke)
            {
                Console.WriteLine(str);
            }
            Write(stroke,$"{ obj.Name}", "Methods", "Method");
            return stroke;
        }

        static public IEnumerable<string> PropertiesAndFields(Type obj)
        {
            Console.WriteLine("\nProperties and fields of {0}", obj.Name);
            IEnumerable<string> stroke1 = (IEnumerable<string>)obj .GetProperties()
                                                                  .Where(n => n is PropertyInfo)
                                                                  .Select(n => ((PropertyInfo)n).Name);      //протестить
            IEnumerable<string> stroke2 = (IEnumerable<string>)obj.GetFields()
                                                                  .Where(n => n is FieldInfo)
                                                                  .Select(n => ((FieldInfo)n).Name);
            IEnumerable<string> stroke = stroke1.Concat(stroke2);
            foreach(string tmp in stroke)
            {
                Console.WriteLine(tmp);
            }
            Write(stroke1, $"{ obj.Name}", "Properties", "Property");
            Write(stroke2, $"{ obj.Name}", "Fields", "Field");
            return stroke;
        }
        static public void Assembly(Assembly assembly, Type obj)
        {
            Console.WriteLine("Name of Assembly,classes: ");
            string tmp="";
            Console.WriteLine(assembly.FullName);
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.FullyQualifiedName);
                tmp = module.FullyQualifiedName;
                foreach (Type type in module.GetTypes())
                {
                    Console.WriteLine(type.FullName);
                }
            }
            XmlDocument xml = new XmlDocument();
            xml.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xml.SelectSingleNode($"Reflector/{obj.Name}");
            XmlElement ass = xml.CreateElement("Assembly");
            XmlText text = xml.CreateTextNode($"{tmp}");
            ass.AppendChild(text);
            root?.AppendChild(ass);
            xml.Save("Reflector.xml");

        }
        static public bool ConstructorInfo(Type obj)    //доп тесты
        {
            bool flag=false;
            foreach(ConstructorInfo constructor in obj.GetConstructors())
            {
                if (constructor.IsPublic)
                {
                    flag = true;
                    break;
                }     
            }
            XmlDocument xml = new XmlDocument();
            xml.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xml.SelectSingleNode($"Reflector/{obj.Name}");
            XmlElement element = xml.CreateElement("Constructors");
            XmlText text;
            if (flag)
                text = xml.CreateTextNode("Есть публичные конструкторы");
            else
                text = xml.CreateTextNode("Нет публичных конструкторов");
            element.AppendChild(text);
            root?.AppendChild(element);
            xml.Save("Reflector.xml");
            return flag;
        }

        static public void MethodsWithParm(Type obj,string param)
        {
            Console.WriteLine("\nMethods of class {0},that contain \"{1}\":",obj.Name,param);
            XmlDocument xml = new XmlDocument();
            xml.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xml.SelectSingleNode($"Reflector/{obj.Name}");
            XmlElement MethodWithParm = xml.CreateElement("MethodsWithParm");
            foreach (MethodInfo MI in obj.GetMethods())
            {
                ParameterInfo[]PI= MI.GetParameters();
                for (int i = 0; i < PI.Length; i++)
                {
                    if (PI[i].ParameterType.Name ==param)
                    {
                        XmlElement Meth = xml.CreateElement("Method");
                        XmlText text = xml.CreateTextNode($"{MI.ReturnType.Name} {MI.Name} ({PI[i].ParameterType.Name} {PI[i].Name})");
                        Meth.AppendChild(text);
                        MethodWithParm.AppendChild(Meth);
                        Console.WriteLine($"{MI.ReturnType.Name} {MI.Name} ({PI[i].ParameterType.Name} {PI[i].Name})");
                    }
                }
            }
            root?.AppendChild(MethodWithParm);
            xml.Save("Reflector.xml");
        }
    }

    class Airline
    {
        readonly string id = Guid.NewGuid().ToString();
        static int counter = 0;
        static string type;
        string pointOfDeparture;
        int number;
        const string time = "21:35";
        string day;
        public Airline()
        {
            pointOfDeparture = "Minsk";
            number = 222123;
            day = "wed";
            counter++;
        }
        public Airline(string point, int number, string day)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
            counter++;
        }
        public Airline(int number, string day)
        {
            this.pointOfDeparture = "vileyka";
            this.number = number;
            this.day = day;
            counter++;
        }
        static Airline()
        {
            type = "luxe";
        }
        private Airline(string point, int number, string day, string constructor)
        {
            this.pointOfDeparture = point;
            this.number = number;
            this.day = day;
        }
        public override int GetHashCode()
        {
            int Hash;
            Hash = (this.number - 12) / 123;
            Console.WriteLine($"Hashcode:{Hash}");
            return Hash;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Airline m = obj as Airline;
            if (m as Airline == null)
                return false;
            return m.day == this.day && m.id == this.id && m.number == this.number && m.pointOfDeparture == this.pointOfDeparture;
        }

        public override string ToString()
        {
            return $"id:{id} type:{type} point of departure:{pointOfDeparture} number:{number} time:{time} day:{day} №{counter}";
        }
        public int Number
        {
            set
            {
                number = value;
            }
            get
            {
                return number;
            }
        }
        public string PointOfDeparture
        {
            set
            {
                pointOfDeparture = value;
            }
            get
            {
                return pointOfDeparture;
            }
        }
        public string Day
        {
            set
            {
                day = value;
            }
            get
            {
                return day;
            }
        }

        public string Id
        {
            get
            {
                return id;
            }
        }
        public string Time
        {

            get
            {
                return time;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
        }
        public int Counter
        {
            get
            {
                return counter;
            }
        }
        public static void Print(Airline airline) => Console.WriteLine($"id:{airline.Id} type:{type} point of departure:{airline.pointOfDeparture} number:{airline.number} time:{time} day:{airline.day} №{counter}");
    }




    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type t = typeof(Int32);

            Reflector.Interfaces(t);

            Reflector.Methods(t);

            Reflector.PropertiesAndFields(t);

            Reflector.MethodsWithParm(t, "Int32");

            if (Reflector.ConstructorInfo(t))
                Console.WriteLine("Содержит публичный конструктор");
            else
                Console.WriteLine("Не содержит публичный конструктор");
            Reflector.Assembly(assembly, t);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCледующий класс\n") ;
            Console.ResetColor();
            

            Airline airline = new Airline();
            Type type = typeof(Airline);
            Reflector.Interfaces(type);

            Reflector.Methods(type);

            Reflector.PropertiesAndFields(type);

            Reflector.MethodsWithParm(type, "Object");

            if (Reflector.ConstructorInfo(t))
                Console.WriteLine("Содержит публичный конструктор");
            else
                Console.WriteLine("Не содержит публичный конструктор");

            Console.WriteLine();
            Reflector.Assembly(assembly, type);


        }
    }
}
