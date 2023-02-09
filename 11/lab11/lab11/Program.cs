using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace lab11
{
    static class Reflector<T>
    {
        static public void WriteInit(IEnumerable<string> stroke, string rootNode, string name, string secondNode, string thirdNode)
        {
            XDocument xdoc = new XDocument();
            XElement reflector = new XElement($"{rootNode}");
            XElement type = new XElement($"{name}");
            XElement xElement = new XElement($"{secondNode}");
            foreach (string tmp in stroke)
            {
                xElement.Add(new XElement($"{thirdNode}", tmp));
            }
            
            type.Add(xElement);
            reflector.Add(type);
            xdoc.Add(reflector);
            xdoc.Save("Reflector.xml");
        }
        static public void Write(IEnumerable<string> stroke, string name, string secondNode, string thirdNode)//класс (xmlnode)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xdoc.SelectSingleNode($"Reflector/{name}");
            XmlElement xmlElement = xdoc.CreateElement($"{secondNode}");    //новый элемент(3-ий)
            foreach (string tmp in stroke)
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



        static public IEnumerable<string> Interfaces(Type obj,bool Flag)
        {
            Console.WriteLine("Interfaces of {0}", obj.Name);

            IEnumerable<string> stroke = obj.GetInterfaces()
                                            .Where(n => n is Type)
                                            .Select(n => ((Type)n).Name);
            foreach (string str in stroke)
            {
                Console.WriteLine(str);
            }
            if (!Flag)
            {
                WriteInit(stroke, "Reflector", $"{obj.Name}", "Interfaces", "Interface");
                Flag = true;
            }
            else
                WriteN(stroke, $"{obj.Name}", "Interfaces", "Interface");
            return stroke;
        }

        static public IEnumerable<string> Methods(Type obj)
        {
            Console.WriteLine("\n methods of {0}", obj.Name);
            IEnumerable<string> stroke = (IEnumerable<string>)obj.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                                            .Where(n => n is MethodInfo)
                                            .Select(n => ((MethodInfo)n).Name);
            foreach (string str in stroke)
            {
                Console.WriteLine(str);
            }
            Write(stroke, $"{ obj.Name}", "Methods", "Method");
            return stroke;
        }

        static public IEnumerable<string> PropertiesAndFields(Type obj)
        {
            Console.WriteLine("\nProperties and fields of {0}", obj.Name);
            IEnumerable<string> stroke1 = (IEnumerable<string>)obj.GetProperties()
                                                                  .Where(n => n is PropertyInfo)
                                                                  .Select(n => ((PropertyInfo)n).Name);      //протестить
            IEnumerable<string> stroke2 = (IEnumerable<string>)obj.GetFields()
                                                                  .Where(n => n is FieldInfo)
                                                                  .Select(n => ((FieldInfo)n).Name);
            IEnumerable<string> stroke = stroke1.Concat(stroke2);
            foreach (string tmp in stroke)
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
            string tmp = "";
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
        static public bool ConstructorInfo(Type obj)   
        {
            bool flag = false;
            foreach (ConstructorInfo constructor in obj.GetConstructors())
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

        static public void MethodsWithParm(Type obj, string param)
        {
            Console.WriteLine("\nMethods of class {0},that contain \"{1}\":", obj.Name, param);
            XmlDocument xml = new XmlDocument();
            xml.Load("Reflector.xml");
            XmlElement? root = (XmlElement)xml.SelectSingleNode($"Reflector/{obj.Name}");
            XmlElement MethodWithParm = xml.CreateElement("MethodsWithParm");
            foreach (MethodInfo MI in obj.GetMethods())
            {
                ParameterInfo[] PI = MI.GetParameters();
                for (int i = 0; i < PI.Length; i++)
                {
                    if (PI[i].ParameterType.Name == param)
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
        static public void Invoke(Airline ob,string name)
        {
            Console.WriteLine("\nMethod Invoke:");
            var Equal = typeof(Airline).GetMethod($"{name}");
            StreamReader reader = new StreamReader("ReadMe.txt");
            List<string> args = new List<string>();
            args.Add(reader.ReadToEnd());
            foreach(string str in args)
            Equal.Invoke(ob, new object[]{str});
        }


        static public T Create(T typ)
        {
            T result;
            Type ty = typeof(T);
            var tmp = ty.GetConstructors();
            var constructor = tmp.OrderBy(n => n.GetParameters().Length).FirstOrDefault();
            if (constructor != null)
                constructor.Invoke(typ, parameters: null);
            else
                return typ;
            result = typ;
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type t = typeof(Int32);

            Reflector<Int32>.Interfaces(t,false);

            Reflector<Int32>.Methods(t);

            Reflector<Int32>.PropertiesAndFields(t);

            Reflector<Int32>.MethodsWithParm(t, "Int32");

            if (Reflector<Int32>.ConstructorInfo(t))
                Console.WriteLine("Содержит публичный конструктор");
            else
                Console.WriteLine("Не содержит публичный конструктор");
            Reflector<Int32>.Assembly(assembly, t);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nCледующий класс\n") ;
            Console.ResetColor();
            

            Airline airline1 = new Airline();
            Airline airline2 = new Airline();
            Type type = typeof(Airline);
            Reflector<Airline>.Interfaces(type,true);

            Reflector<Airline>.Methods(type);

            Reflector<Airline>.PropertiesAndFields(type);

            Reflector<Airline>.MethodsWithParm(type, "Object");

            if (Reflector<Airline>.ConstructorInfo(t))
                Console.WriteLine("Содержит публичный конструктор");
            else
                Console.WriteLine("Не содержит публичный конструктор");

            Console.WriteLine();
            Reflector<Airline>.Assembly(assembly, type);

            Airline airline= new Airline();
            Type type1 = typeof(Airline);
            Airline air=Reflector<Airline>.Create(airline);
            Reflector<Airline>.Invoke(air, "showelem");
        }
    }
}

