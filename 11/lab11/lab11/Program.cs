using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace lab11
{
    static class Reflector
    {
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
            return stroke;
        }
        static public void Assembly(Assembly assembly)
        {
            Console.WriteLine("Name of Assembly,classes: ");
            Console.WriteLine(assembly.FullName);
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.FullyQualifiedName);
                foreach (Type type in module.GetTypes())
                {
                    Console.WriteLine(type.FullName);
                }
            }
        }
        static public bool ConstructorInfo(Type obj)    //доп тесты
        {
            foreach(ConstructorInfo constructor in obj.GetConstructors())
            {
                if (constructor.IsPublic)
                    return true;
            }
            return false;
        }

        static public void Methods(Type obj,string param)   //протестить
        {
            Console.WriteLine("\nMethods of class {0},that contain \"{1}\":",obj.Name,param);
            foreach(MethodInfo MI in obj.GetMethods())
            {
                ParameterInfo[]PI= MI.GetParameters();
                for (int i = 0; i < PI.Length; i++)
                {
                    if (PI[i].ParameterType.Name ==param)
                    {
                        Console.WriteLine($"{MI.ReturnType.Name} {MI.Name} ({PI[i].ParameterType.Name} {PI[i].Name})");
                    }
                }
            }
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Reflector.Assembly(assembly);

            Type t = typeof(Int32);

            Reflector.Interfaces(t);

            Reflector.Methods(t);

            Reflector.PropertiesAndFields(t);

            Reflector.Methods(t, "Object");

            if (Reflector.ConstructorInfo(t))
                Console.WriteLine("Содержит публичный конструктор");
            else
                Console.WriteLine("Не содержит публичный конструктор");

            Console.WriteLine() ;
            
        }
    }
}
