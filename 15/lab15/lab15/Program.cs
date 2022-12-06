using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;
namespace lab15
{
    class Tasks
    {
        public void Task1()
        {
            Thread.Sleep(600);
            Console.WriteLine("---Task 1---");
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
            Thread.Sleep(500);
            Console.WriteLine("---Task 2---");
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
            Thread.Sleep(400);
            Console.WriteLine("---Task 3---");
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
        public void Task4()
        {
            Thread.Sleep(300);
            Console.WriteLine("---TASK 4---");
            Task<int> task = new Task<int>(() => Mul(4, 5));
            Task print = task.ContinueWith(t => PrintResult(t.Result));
            task.Start();
            print.Wait();
            int Mul(int a, int b) => a * b;
            void PrintResult(int sum) => Console.WriteLine($"Mul: {sum}");
            
        }
        public void Task5()
        {
            Thread.Sleep(200);
            Console.WriteLine("---Task 5---");
            int[] arr1 = new int[10000];
            int[] arr2 = new int[10000];
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Parallel.For: ");
            Parallel.For(1, arr1.Length,t=>arr1[t]=t);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("RunTime " + ts + "\n");

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            Console.WriteLine("Standart for: ");
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = i;
            }
            stopwatch2.Stop();
            TimeSpan ts2 = stopwatch2.Elapsed;
            Console.WriteLine("RunTime "+ts2 +"\n");
            //foreach
            Stopwatch stopwatch4 = new Stopwatch();
            stopwatch4.Start();
            Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4 },Square);
            stopwatch4.Stop();
            Console.WriteLine("Parallel.Foreach: " + stopwatch4.Elapsed);

            Stopwatch stopwatch5 = new Stopwatch();
            stopwatch5.Start();
            foreach (var m in new List<int>() { 1, 2, 3, 4 })
            {
                Square(m);
            }
            stopwatch5.Stop();
            Console.WriteLine("foreach: " + stopwatch5.Elapsed);
            Console.WriteLine();
            static void Square(int a) => Console.WriteLine($"Square: {a*a}");
        }
        public void Task6()
        {
            Console.WriteLine("[---Task 6---]");
            Parallel.Invoke(
               Task5,
               Task4,
               Task3);
            Console.WriteLine("[------------]");
        }
        public void Task7()
        {
            Console.WriteLine("---Task 7---");
            BlockingCollection<string> collection;

            void producer()
            {
                List<string> Appliances = new List<string> { "table", "Microwave", "Plate", "computer", "chair" };
                int choose = 0;
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    choose = rnd.Next(0, Appliances.Count - 1);
                    Console.WriteLine($"Add {Appliances[choose]}");
                    collection.Add(Appliances[choose]);
                    Appliances.RemoveAt(choose);
                    Thread.Sleep(60);
                }
                collection.CompleteAdding();
            }

            void consumer()
            {
                string i = "";
                int m = 0;
                while (!collection.IsCompleted) //определить, что коллекция опустела, а новые элементы добавляться не будут.
                {
                    m++;
                    if (collection.TryTake(out i))
                        Console.WriteLine("Покупатель купил: " + i);
                    else
                        if (m % 3 == 0)
                        Console.WriteLine($"Покупатель ничего не купил и ушел");
                    Thread.Sleep(20);
                }
            }

            collection = new BlockingCollection<string>(4);

            Task pr = new Task(producer);
            Task cn = new Task(consumer);

            pr.Start();
            cn.Start();

            Task.WaitAll(pr, cn);
            pr.Dispose();
            cn.Dispose();
        }
        public async void Task8()
        {
            Console.WriteLine("---Task 8---");
            var name1 = PrintAsync("Вадим");
            var name2 = PrintAsync("Максим");
            var name3 = PrintAsync("Дима");
            
            await name1;
            await name2;
            await name3;
            
            async Task PrintAsync(string name)
            {
                Console.WriteLine("printing name");
                Console.WriteLine(name);
                await Task.Delay(3000);
            }
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

            tasks.Task4();

            tasks.Task5();
            
            tasks.Task6();

            tasks.Task7();

            tasks.Task8();

        }
    }
}
