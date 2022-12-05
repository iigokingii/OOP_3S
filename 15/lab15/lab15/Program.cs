using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
namespace lab15
{
    class Tasks
    {
        public void Task1()
        {
            Stopwatch stopWatch = new Stopwatch();
            
            Console.WriteLine("введите n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            stopWatch.Start();
            var numbers = new List<int>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2; i < n; i++)
            {
                numbers.Add(i);
            }
            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }
            foreach(int temp in numbers)
            {
                Console.Write("  "+temp);
                Thread.Sleep(200);
            }
            Console.WriteLine();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime+"\n");
        }
        public void Task2()
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            Task task = new Task(() => {
                Stopwatch stopWatch = new Stopwatch();
                Console.WriteLine("введите n: ");
                int n = Convert.ToInt32(Console.ReadLine());
                stopWatch.Start();
                var numbers = new List<int>();
                //заполнение списка числами от 2 до n-1
                for (var i = 2; i < n; i++)
                {
                    numbers.Add(i);
                }
                for (var i = 0; i < numbers.Count; i++)
                {
                    for (var j = 2; j < n; j++)
                    {
                        //удаляем кратные числа из списка
                        numbers.Remove(numbers[i] * j);
                    }
                }
                foreach (int temp in numbers)
                {
                    if (token.IsCancellationRequested)  //для выхода из операции
                    {
                        Console.WriteLine("\nОперация прервана: ");
                        return;
                    }
                    Console.Write("  " + temp);
                    Thread.Sleep(200);
                }
                Console.WriteLine();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
                Console.WriteLine("RunTime " + elapsedTime + "\n");
            }, token);
            task.Start();
            Thread.Sleep(4000);
            source.Cancel();
            Thread.Sleep(1000);
            Console.WriteLine($"\nId: {task.Id};\nStatus: {task.Status};\nCompleted? ({task.IsCompleted})\n");
        }

        public void Task3()
        {
            int z1=2, z2=4;
            Task<int> sum = new Task<int>(() => {
                Console.WriteLine("task Sum");
                return Sum(z1, z2);
            });
            sum.Start();
            int res1 = sum.Result;
            
            Task<int> mul = new Task<int>(() => {
                Console.WriteLine("task Mul");
                return Mult(z1, z2);
            });
            mul.Start();
            int res2 = mul.Result;

            Task<int> sqr = new Task<int>(() => { Console.WriteLine("task Square"); ; return Square(z1); });
            sqr.Start();
            int res3 = sqr.Result;

            Task<int> volume = new Task<int>(() => { Console.WriteLine("task Volume"); return Volume(res1, res2, res3); });
            volume.Start();
            Console.WriteLine("Результат работы 4-ех задач:{0}",volume.Result);
            Task.WaitAll(sum, mul, sqr, volume);
            int Mult(int x, int c) => x * c;
            int Sum(int x, int y) => x + y;
            int Square(int x) => x * x;
            int Volume(int a, int b, int c) => a * b * c;
        }



    }




    class Program
    {
        static void Main(string[] args)
        {
            Tasks tasks = new Tasks();
            Task task1 = new Task(tasks.Task1);
            Console.WriteLine($"Id: {task1.Id};\nStatus: {task1.Status};\nCompleted? ({task1.IsCompleted})\n");
            task1.Start();
            
            task1.Wait();

            tasks.Task2();

            tasks.Task3();
            Console.WriteLine("Main");
        }
    }
}
