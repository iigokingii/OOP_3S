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
            Process[] allProcess = Process.GetProcesses();
            foreach (Process process in allProcess)
            {
                try
                {
                    Console.WriteLine($"\nId: {process.Id}");
                    Console.WriteLine($"Name:{process.ProcessName};");
                    Console.WriteLine($"Priority:{process.PriorityClass};");
                    Console.WriteLine($"Start time: {process.StartTime};");
                    Console.WriteLine($"total processor time: {process.TotalProcessorTime}");
                }
                catch(Exception e){}
                
            }
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            //Создание домена
            /*AppDomain newDomain = AppDomain.CreateDomain("New");
            newDomain.Load(newDomain.BaseDirectory);
            Console.WriteLine("Название "+newDomain.FriendlyName);*/
            //AppDomain.Unload(newDomain);    //Выгрузить сборки из домена нельзя, можно выгрузить весь домен

            Console.WriteLine("Domain of current app: ");
            AppDomain domain = AppDomain.CurrentDomain;
            Console.WriteLine("Name: {0}", domain.FriendlyName);
            Console.WriteLine("Base Dir: {0}", domain.BaseDirectory);
            Console.WriteLine();
            Assembly[] assemblies = domain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
                Console.WriteLine("assembly name: {0}", assembly.GetName().Name);

           

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Thread thred = Thread.CurrentThread;
            Console.WriteLine("id:{0}",thred.ManagedThreadId);
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
            //*threadForTask.Suspend();
            /*Console.WriteLine($"Запущен ли поток: {threadForTask.IsAlive}");
            Console.WriteLine($"Id потока: {threadForTask.ManagedThreadId}");
            Console.WriteLine($"Статус потока: {threadForTask.ThreadState}");
            threadForTask.Resume();
            Console.WriteLine($"Запущен ли поток: {threadForTask.IsAlive}");
            Console.WriteLine($"Id потока: {threadForTask.ManagedThreadId}");
            Console.WriteLine($"Статус потока: {threadForTask.ThreadState}");*/

            void Task(object? obj)
            {
                if(obj is int n)
                {
                    for(int i = 0; i < n; i++)
                    {
                        Console.WriteLine(i);
                        using (StreamWriter sw = new StreamWriter("task.txt",true))
                        {
                            sw.WriteLine(i);
                            Thread.Sleep(300);
                        }
                    }
                }
            }
            threadForTask.Join();   //блокирует выполнение вызвавшего его потока до тех пор, пока не завершится поток, для которого был вызван данный метод


            //4i
            object locker = new object();
            Thread thread1 = new Thread(Task2)
            {
                Priority = ThreadPriority.AboveNormal,
            };
            thread1.Name = "Поток 1";
            Thread thread2 = new Thread(Task2);
            thread2.Name = "Поток 2";
            thread1.Start(n);
            thread2.Start(n);
            void Task2(object? obj)
            {
                lock (locker)
                {
                    if (obj is int n)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (j % 2 == 0 && Thread.CurrentThread.Name == "Поток 1")
                            {
                                Console.WriteLine("четный j {0}, {1}", j, Thread.CurrentThread.Name);
                                Thread.Sleep(400);
                                using (StreamWriter sw = new StreamWriter("task2.txt", true))
                                {
                                    sw.WriteLine(j);
                                }
                            }
                            else if (j % 2 != 0 && Thread.CurrentThread.Name == "Поток 2")
                            {
                                Console.WriteLine("нечетный j {0}, {1}", j, Thread.CurrentThread.Name);
                                Thread.Sleep(200);
                                using (StreamWriter sw = new StreamWriter("task2.txt", true))
                                {
                                    sw.WriteLine(j);
                                }
                            }
                        }
                    }
                }
            }
            thread1.Join();
            thread2.Join();
            //4ii


            AutoResetEvent reset = new AutoResetEvent(true);
            Thread thread3 = new Thread(Task2I)
            {
                Priority = ThreadPriority.AboveNormal,
            };
            thread3.Name = "Поток 3";
            Thread thread4 = new Thread(Task2I);
            thread4.Name = "Поток 4";
            thread3.Start(n);
            thread4.Start(n);
            void Task2I(object? obj)
            {
                
                if (obj is int n)
                {
                    for (int j = 0; j < n; j++)
                    {
                        reset.WaitOne();
                        if (j % 2 == 0 && Thread.CurrentThread.Name == "Поток 3")
                        {
                            Console.WriteLine("четный j {0}, {1}", j, Thread.CurrentThread.Name);
                            Thread.Sleep(400);
                            using (StreamWriter sw = new StreamWriter("task3.txt", true))
                            {
                                sw.WriteLine(j);
                            }
                            
                        }
                        else if (j % 2 != 0 && Thread.CurrentThread.Name == "Поток 4")
                        {
                            Console.WriteLine("нечетный j {0}, {1}", j, Thread.CurrentThread.Name);
                            Thread.Sleep(400);
                            using (StreamWriter sw = new StreamWriter("task3.txt", true))
                            {
                                sw.WriteLine(j);
                            }
                        }
                        reset.Set();
                    }

                }
            }
            thread3.Join();
            thread4.Join();
            TimerCallback timerCB = new TimerCallback(Print);
            Timer timer = new Timer(timerCB, null, 0, 1000);
            Thread.Sleep(4000);

            void Print(object obj)
            {
                Console.WriteLine("wassup");   
            }
        }
    }
}
