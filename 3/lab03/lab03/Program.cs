using System;
using System.Collections.Generic;

namespace lab03
{
    public class stack
    {
        const int number = 10;
        public int[] array;
        int counter = 0;
        public stack()
        {
            array = new int[number];
        }
        public stack(int length)
        {
            array = new int[length];
        }
        public void Push(int elem)
        {
            array[counter] = elem;
            counter++;
        }
        public int Pop()
        {
            if (counter==0)
            {
                throw new Exception("cтек пуст");
            }
            int result = array[--counter];
            array[counter] = default(int);
            return result;
        }
        public bool Contains(int elem)
        {
            foreach(var arr in array)
            {
                if (arr == elem)
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            for(int i=0; i < counter; i++)
            {
                array[i] = default(int);
            }
            counter = 0;
        }





    }



    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                stack stack1 = new stack();
                stack stack2 = new stack(10);
                stack1.Push(122);
                stack1.Push(124);
                
                int top = stack1.Pop();
                stack1.Push(125);
                bool a = stack1.Contains(122);
                bool b = stack1.Contains(2);
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
