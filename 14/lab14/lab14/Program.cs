using System;
using System.Diagnostics;
using System.Reflection;

namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] allProcess = Process.GetProcesses();
            foreach(Process process in allProcess)
            {
                Console.WriteLine($"Id: {process.Id}");
                Console.WriteLine($"Name:{process.ProcessName};");
                //Console.WriteLine($"\n Priority:{process.PriorityClass};");
                //Console.WriteLine($"\n Start time: {process.StartTime};");
                //Console.WriteLine($" \n total processor time: {process.TotalProcessorTime}");
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Domain of current app: ");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0}",domain.FriendlyName);
            Console.WriteLine("Base Dir: {0}", domain.BaseDirectory);
            Console.WriteLine();
            Assembly[] assemblies = domain.GetAssemblies();
            foreach(Assembly assembly in assemblies)
                Console.WriteLine("assembly name: {0}",assembly.GetName().Name);




            Console.WriteLine("---------------------------------------------------------------------------------------------");







        }
    }
}
