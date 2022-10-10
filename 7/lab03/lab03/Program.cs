using System;
using System.Collections.Generic;

namespace lab03
{
    interface Iuser<T>
    {
        void Push(T elem);  //добавление
        void Clear();       //полное удаление
        T Pop();            //извлечение и удаления
        void Print();
        bool Contains(T elem);
    }




    public class stack<T>:Iuser<T>
    {
        public class Production
        {
            public int Id;
            public string Name;
            public Production()
            {
                Id = 0;
            }
            public Production(int ID,string NAME)
            {
                Id = ID;
                Name = NAME;
            }
        }
        public class Developer
        {
            string fio;
            int id;
            string department;
            public string FIO
            {
                get
                {
                    return fio;
                }
                set
                {
                    fio = value;
                }
            }
            public int ID
            {
                get
                {
                    return id;
                }
                set
                {
                    id = ID;
                }
            }
            public string Department
            {
                get
                {
                    return department;
                }
                set
                {
                    department = value  ;
                }
            }
        }
        const int number = 10;
        public List<T> list;
       
        public stack()
        {
            list = new List<T>();
        }
        public stack(int length)
        {
            list = new List<T>(length);
        }
        public void Print()
        {
            if (list.Count-1 == 0)
            {
                throw new Exception("Пытаетесь вывести пустой стек");
            }
            else
            {
                foreach(var tmp in list)
                    Console.WriteLine(tmp);
            }
            
        }
        public void Push(T elem)
        {
            list.Add(elem);
        }
        public T Pop()
        {
            if (list.Count-1 == 0)
            {
                throw new Exception("cтек пуст");
            }
            T result = list[list.Count-1];
            list.RemoveAt(list.Count-1);
            return result;
        }
        public bool Contains(T elem)
        {
            foreach (var arr in list)
            {
                if (arr.Equals(elem))
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            list.Clear();
        }
        public T Peek()
        {
            if (list.Count-1 == 0)
                throw new Exception("стек пуст");
            T result = list[list.Count-1] ;
            return result;
        }
        public void Extract()
        {
            list.RemoveAt(list.Count - 1);
        }
        public bool IsEmpty()
        {
            if (list.Count-1 == 0)
                return true;
            return false;
        }
        public static stack<T> operator +(stack<T> stack,T value) {
            stack.Push(value);
            return stack;
        }
        public static stack<T> operator --(stack<T> stack)
        {
            stack.Extract();
            return stack;
        }
        public static bool operator true(stack<T> stack)
        {
            return stack.IsEmpty();
        }
        public static bool operator false (stack<T> stack)
        {
            return stack.IsEmpty();
        }
        public static stack<int> operator > (stack<int> stack,stack <T> stack1)
        {
            stack<int> stack3 = new stack<int>();
            int max = 0;
            int index = 0;
            int temp;
            for(int i=0;i<stack.list.Count;i++)
            {
                max = 0;
                for (int j = i; j < stack.list.Count; j++)
                {
                    if (max < stack.list[j])
                    {
                        max = stack.list[j];
                        index = j;
                    }
                       
                }
                temp = stack.list[i];
                stack.list[i] = max;
                stack.list[index]=temp;
            }
            for (int i = 0; i < stack.list.Count; i++)
            {
                stack3.list[i] = stack.list[i];
            }
            return stack3;
        }
        public static stack<int> operator <(stack<int> stack, stack<T> stack1)
        {
            stack<int> stack3 = new stack<int>();
            int min = 0;
            for (int i = 0; i < stack.list.Count; i++)
            {
                for (int j = 0; j < stack.list.Count; j++)
                {
                    if (min > stack.list[j])
                        min = stack.list[j];
                }
                stack.list[i] = min;
            }
            for (int i = 0; i < stack.list.Count; i++)
            {
                stack3.list[i] = stack.list[i];
            }
            return stack3;
        }
    }
    static public class StatisticOperation
    {
        public static int sum(stack<int> stack)
        {
            int sum = 0;
            for (int i = 0; i < stack.list.Count; i++)
            {
                sum += stack.list[i];
            }
            return sum;
        }
        public static int difference(stack<int> stack)
        {
            int max = 0;
            int min = 1000;
            for (int i = 0; i < stack.list.Count; i++)
            {
                if (max < stack.list[i])
                    max = stack.list[i];
                else if (min > stack.list[i])
                    min = stack.list[i];
            }
            int difference = max - min;
            return difference;
        }
        public static int counter(stack<int> stack)
        {
            return stack.list.Count;
        }
       
    }
    static public class StatisticOperationExtencion
    {
        public static int NumberOfSentences(this string str)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '!' || str[i] == '?' || str[i] == '.')
                    counter++;
            }
            return counter;
        }
        public static int MiddleElement(this stack<int> stack)
        {
            int middle = stack.list.Count / 2;
            return stack.list[middle];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                stack<int> stack1 = new stack<int>();
                stack<string> stack2 = new stack<string>(10);
                stack1.Push(122);
                stack1.Push(124);
                stack1.Push(1000);
                stack1.Push(100);
                stack1.Push(110);
                
                //stack1.Push(125);
                int top = stack1.Pop();
                stack1.Print();
                bool a = stack1.Contains(122);
                if (a)
                Console.WriteLine($"include 122");
                else
                    Console.WriteLine($"don't include{a}");
                bool b = stack1.Contains(2);
                //int c = stack1.Peek();
                
                int m = 412;
                stack<int> result = stack1 + m;
                stack1--;
                if (stack1)
                    Console.WriteLine("стек пуст");
                else
                    Console.WriteLine("стек не пуст");

                stack<int> stack3 = new stack<int>();
                //stack3= stack1 > stack3;
                stack<string>.Production prod1 = new stack<string>.Production();
                stack<int>.Production production = new stack<int>.Production(1, "GoKing");
                stack<int>.Developer developer = new stack<int>.Developer();
                developer.ID = 123;
                developer.FIO = "smolik valeriy Aleksandrovich";
                developer.Department = "SoftWare";

                int Sum = StatisticOperation.sum(stack1);
                int Difference = StatisticOperation.difference(stack1);
                int Counter = StatisticOperation.counter(stack1);
                Console.WriteLine($"Sum:{Sum};\tDifference:{Difference};\t\tCounter:{Counter}");
                string stroke = "Hello,World!I like ice-creem.My name is valera.How old are u?";
                Console.WriteLine($"stroke:{stroke}");
                int numb = stroke.NumberOfSentences();
                Console.WriteLine($"Number of sentences:{numb}");
                int middle = stack1.MiddleElement();
                Console.WriteLine($"Middle elem of stack1   :{middle}");


                //stack1.Clear();
                //int top1 = stack1.Pop();
                
                stack <int> stack4=stack1 > stack2;
                Console.WriteLine($"top:{top}");
                stack<string> st = new stack<string>();
                st.Print();




            }
            catch (Exception e)
            {
                Console.WriteLine("\nБлок catch:");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.Source);
                Console.WriteLine(e.TargetSite);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Конец лабораторной");
            }
        }
    }
}
