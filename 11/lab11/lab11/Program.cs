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
            /*Console.WriteLine("Full name : " + obj.FullName);
            Console.WriteLine("Full name : " + obj.Name);
            Console.WriteLine("Base type : "+ obj.BaseType);
            Console.WriteLine("Is sealed : "+ obj.IsSealed);
            Console.WriteLine("Is class : "+ obj.IsClass);*/
            Console.WriteLine("Interfaces of {0}",obj.Name);
            List<string> arr = new List<string>();
            foreach (Type iType in obj.GetInterfaces())
            {
                Console.WriteLine(iType.Name);
                arr.Add(iType.Name);
            }
            IEnumerable<string> str = arr;
            return str;
        }

        static public IEnumerable<string> Methods(Type obj)
        {
            Console.WriteLine("\n methods of {0}",obj.Name);
            List<string> arr = new List<string>();
            foreach (MethodInfo method in obj.GetMethods())
            {
                Console.WriteLine($"{method.ReturnType.Name} {method.Name}");
                arr.Add(method.Name);
            }
            IEnumerable<string> str = arr;
            return str;
        }

        static public void PropertiesAndFields(Type obj)
        {
            Console.WriteLine("\nProperties and fields of {0}",obj.Name);
            foreach(PropertyInfo property in obj.GetProperties())
            {
                Console.WriteLine($"{property.PropertyType} {property.Name}");
            }
            foreach(FieldInfo field in obj.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }

        }



    }

    class Program
    {
        static void Main(string[] args)
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(assembly.FullName);
            foreach (Module module in assembly.GetModules())
            {
                Console.WriteLine(module.FullyQualifiedName);
                foreach (Type type in module.GetTypes())
                {
                    Console.WriteLine(type.FullName);
                }
            }
            Type t = typeof(Int32);
            Reflector.Interfaces(t);
            Reflector.Methods(t);
            Reflector.PropertiesAndFields(t);

        }
    }
}
