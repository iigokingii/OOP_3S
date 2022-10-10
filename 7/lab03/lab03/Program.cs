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
        public T[] array;
        public int counter = 0;
       
        public stack()
        {
            array = new T[number];
        }
        public stack(int length)
        {
            array = new T[length];
        }
        public void Print()
        {
            int i = 1;
            int tmp=counter;

            while(counter!=0)
            {
                Console.WriteLine("Элемент "+i+" :"+array[--counter]) ;
                i++;
            }
            counter = tmp;
        }
        public void Push(T elem)
        {
            array[counter] = elem;
            counter++;
        }
        public T Pop()
        {
            if (counter == 0)
            {
                throw new Exception("cтек пуст");
            }
            T result = array[--counter];
            array[counter] = default(T);
            return result;
        }
        public bool Contains(T elem)
        {
            foreach (var arr in array)
            {
                if (arr.Equals(elem))
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            for (int i = 0; i < counter; i++)
            {
                array[i] = default(T);
            }
            counter = 0;
        }
        public T Peek()
        {
            if (counter == 0)
                throw new Exception("стек пуст");
            T result = array[--counter];
            counter++;
            return result;
        }
        public void Extract()
        {
            array[--counter]=default(T);
        }
        public bool IsEmpty()
        {
            if (counter == 0)
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
            for(int i=0;i<stack.counter;i++)
            {
                max = 0;
                for (int j = i; j < stack.counter; j++)
                {
                    if (max < stack.array[j])
                    {
                        max = stack.array[j];
                        index = j;
                    }
                       
                }
                temp = stack.array[i];
                stack.array[i] = max;
                stack.array[index]=temp;
            }
            for (int i = 0; i < stack.counter; i++)
            {
                stack3.array[i] = stack.array[i];
            }
            return stack3;
        }
        public static stack<int> operator <(stack<int> stack, stack<T> stack1)
        {
            stack<int> stack3 = new stack<int>();
            int min = 0;
            for (int i = 0; i < stack.counter; i++)
            {
                for (int j = 0; j < stack.counter; j++)
                {
                    if (min > stack.array[j])
                        min = stack.array[j];
                }
                stack.array[i] = min;
            }
            for (int i = 0; i < stack.counter; i++)
            {
                stack3.array[i] = stack.array[i];
            }
            return stack3;
        }
    }
    static public class StatisticOperation
    {
        public static int sum(stack<int> stack)
        {
            int sum = 0;
            for (int i = 0; i < stack.counter; i++)
            {
                sum += stack.array[i];
            }
            return sum;
        }
        public static int difference(stack<int> stack)
        {
            int max = 0;
            int min = 1000;
            for (int i = 0; i < stack.counter; i++)
            {
                if (max < stack.array[i])
                    max = stack.array[i];
                else if (min > stack.array[i])
                    min = stack.array[i];
            }
            int difference = max - min;
            return difference;
        }
        public static int counter(stack<int> stack)
        {
            return stack.counter;
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
            int middle = stack.counter / 2;
            return stack.array[middle];
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
                bool a = stack1.Contains(122);
                if (a)
                Console.WriteLine($"include 122");
                else
                    Console.WriteLine($"don't include{a}");
                bool b = stack1.Contains(2);
                //int c = stack1.Peek();
                stack1.Print();




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





            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
