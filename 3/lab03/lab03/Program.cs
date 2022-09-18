using System;
using System.Collections.Generic;

namespace lab03
{
    public class stack<T>
    {
        const int number = 10;
        public T[] array;
        int counter = 0;
        public stack()
        {
            array = new T[number];
        }
        public stack(int length)
        {
            array = new T[length];
        }
        public void Push(T elem)
        {
            array[counter] = elem;
            counter++;
        }
        public T Pop()
        {
            if (counter==0)
            {
                throw new Exception("cтек пуст");
            }
            T result = array[--counter];
            array[counter] = default(T);
            return result;
        }
        public bool Contains(T elem)
        {
            foreach(var arr in array)
            {
                if (arr.Equals(elem))
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            for(int i=0; i < counter; i++)
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
                
                int top = stack1.Pop();
                stack1.Push(125);
                bool a = stack1.Contains(122);
                Console.WriteLine($"includes");
                bool b = stack1.Contains(2);
                int c = stack1.Peek();
                stack1.Clear();
                int top1 = stack1.Pop();
                Console.WriteLine($"top:{top}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
