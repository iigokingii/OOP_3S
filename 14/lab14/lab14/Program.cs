using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.IO;
namespace lab14
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Process[] allProcess = Process.GetProcesses();
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
            //Создание домена
            //AppDomain newDomain = AppDomain.CreateDomain("New");
            //newDomain.Load("Name of assembly");

            Console.WriteLine("Domain of current app: ");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0}",domain.FriendlyName);
            Console.WriteLine("Base Dir: {0}", domain.BaseDirectory);
            Console.WriteLine();
            Assembly[] assemblies = domain.GetAssemblies();
            foreach(Assembly assembly in assemblies)
                Console.WriteLine("assembly name: {0}",assembly.GetName().Name);
            
            //AppDomain.Unload(newDomain);//Выгрузить сборки из домена нельзя, можно выгрузить весь домен

            Console.WriteLine("---------------------------------------------------------------------------------------------");*/
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Thread threadForTask = new Thread(Task);
            threadForTask.Name = "thread For Task";
            Console.WriteLine($"Имя потока: {threadForTask.Name}");
            Console.WriteLine($"Запущен ли поток: {threadForTask.IsAlive}");
            Console.WriteLine($"Id потока: {threadForTask.ManagedThreadId}");
            Console.WriteLine($"Приоритет потока: {threadForTask.Priority}");
            Console.WriteLine($"Статус потока: {threadForTask.ThreadState}");
            Console.WriteLine($"фоновый? {threadForTask.IsBackground}");
            Console.WriteLine() ;
            threadForTask.Start(n);
            Console.WriteLine($"Запущен ли поток: {threadForTask.IsAlive}");
            Console.WriteLine($"Id потока: {threadForTask.ManagedThreadId}");
            Console.WriteLine($"Статус потока: {threadForTask.ThreadState}");
            //threadForTask.Abort();
            threadForTask.Suspend();
            Console.WriteLine($"Запущен ли поток: {threadForTask.IsAlive}");
            Console.WriteLine($"Id потока: {threadForTask.ManagedThreadId}");
            Console.WriteLine($"Статус потока: {threadForTask.ThreadState}");

            void Task(object? obj)
            {
                if(obj is int n)
                {
                    for(int i = 0; i < n; i++)
                    {
                        Console.WriteLine(i);
                        using (StreamWriter sw = new StreamWriter("task.txt",false))
                        {
                            sw.Write(i);
                            Thread.Sleep(300);
                        }
                    }
                }
            }






        }
    }
}
