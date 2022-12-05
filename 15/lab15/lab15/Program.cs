using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
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
            }
            Console.WriteLine();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime+"\n");
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Tasks tasks = new Tasks();
            Task task1 = new Task(tasks.Task1);
            task1.Start();
            Console.WriteLine($"Id: {task1.Id};\nStatus: {task1.Status};\nCompleted? ({task1.IsCompleted})\n");
            task1.Wait();
            Console.WriteLine($"Id: {task1.Id};\nStatus: {task1.Status};\nCompleted? ({task1.IsCompleted})\n");
            Console.WriteLine("Main");
        }
    }
}
