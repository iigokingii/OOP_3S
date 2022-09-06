using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            //основные
            sbyte a1 = 127;
            Console.WriteLine($" sbyte:{a1}");
            object o1 = a1;
            sbyte c1 = (sbyte)o1;

            byte a2 = 255;
            Console.WriteLine($" byte:{a2}");
            object o2 = a2;
            byte c2 = (byte)o2;

            short a3 = 333;
            Console.WriteLine($" short:{a3}");
            object o3 = a3;
            short c3 = (short)o3;

            int a4 = 120222;
            Console.WriteLine($" int:{a4}");
            object o4 = a4;
            int c4 = (int)o4;

            ushort a5 = 1111;
            Console.WriteLine($" ushort:{a5}");
            object o5 = a5;
            ushort c5 = (ushort)o5;

            uint a6 = 1111111111;
            Console.WriteLine($" uint:{a6}");
            object o6 = a6;
            uint c6 = (uint)o6;

            ulong a7 = 112312312312;
            Console.WriteLine($" ulong:{a7}");
            object o7 = a7;
            ulong c7 = (ulong)o7;

            long a8 = -222222;
            Console.WriteLine($" long:{a8}");
            object o8 = a8;
            long c8 = (long)o8;

            System.Single a9 = 3.4F;
            Console.WriteLine($" float:{a9}");
            object o9 = a9;
            float c9 = (float)o9;

            double a10 = 332.1111;
            Console.WriteLine($" double:{a10}");
            object o10= a10;
            double c10 = (double)o10;

            char a11 = 'V';
            Console.WriteLine($" char:{a11}");
            object o11 = a11;
            char c11 = (char)o11;

            bool a12 = true;
            Console.WriteLine($" bool:{a12}");
            object o12 = a12;
            bool c12 = (bool)o12;

            //неявное
            int b1 = 9;
            double b2 = b1;
            float b3 = 4.2F;
            double b4 = b3;
            short b5 = 66;
            int b6=b5;
            int b7 = 8;
            float b8 = b7;
            short b9 = -100;
            long b10 = b9;
            double v = (b2 + b4 + b6 - b8) / b10;
            //явное 
            sbyte b11 = 100;
            byte b12 = (byte)b11;
            float b13 = 9.1F;
            int b14 = (int)b13;
            double b15 = 9.2222;
            string b16 = Convert.ToString(b15);
            long b17 = 9999;
            float b18 = (System.Single)b17;
            double b19 = 6.66;
            int b20 = Convert.ToInt32(b19);

            double? n = 100.9922445;
            if (n.HasValue)
                Console.WriteLine($"\n число n = {n}");
            else
                Console.WriteLine($" n не содержит число");
            double d=n.Value;
            Console.WriteLine($" число d равно: {d}");




            var name = "\nValera";
            //name = 100;

            string str1 = "Hello, ";
            string str2 = @"World";
            string str3 = "!!!!\n";
            string str4;
            Console.WriteLine(string.Concat(str1,str2,str3));
            str4=string.Copy(str1);
            Console.WriteLine(str4);
            string str5 = str1.Substring(1);
            Console.WriteLine(str5);
            string str6 = "vvsssa sdasda dasasdas asdsdss xcssd sta sxxxc";
            Console.WriteLine(str6);
            string[] words = str6.Split(' ');
            foreach (var word in words)
                Console.WriteLine($"{word}");
            string str7 = str6.Insert(8, str1);
            Console.WriteLine(str7);
            str7 = str7.Remove(10,20);
            Console.WriteLine(str7);
            Console.WriteLine($"в строке ({str7}) были удалены символы 11-21 ");


            string str8 = null;
            string str9 = string.Empty;
            if (string.IsNullOrEmpty(str9))
                Console.WriteLine("строка пуста");
            else
                Console.WriteLine("строка не пуста");
            if (string.IsNullOrEmpty(str8))
                Console.WriteLine("строка пуста");
            else
                Console.WriteLine("строка не пуста");
            string str10 = str8 + str1;
            Console.WriteLine(str10);
            if (str10 == str9)
                Console.WriteLine("строка пуста");
            else
                Console.WriteLine("строка не пуста");


            StringBuilder sb = new StringBuilder("лабораторная 01");
            sb.Append(" по с#");
            sb.Insert(0, "Название: ");
            sb.Remove(13, 15);
            Console.WriteLine(sb);
            Console.WriteLine();
            int[,] array = { {6,5,8,6 },{ 1,23,5,6},{ 4,2,1,5},{7,7,7,7} }; 

            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    Console.Write($"{array[i, j]} \t");
                }
                Console.WriteLine();
            }

            string[] str = {"привет",",","как","дела","?"};
            Console.WriteLine($"Длина массива строк: {str.Length}");
            foreach(var word in str)
                Console.WriteLine($"{word}");
            Console.WriteLine("откуда необходимо изменять?");
            string m=Console.ReadLine();
            int q = Convert.ToInt32(m)-1;
            Console.WriteLine("на что необходимо изменить?");
            m = Console.ReadLine();
            Console.WriteLine("\n");
            str[q]= m;
            foreach (var word in str)
                Console.WriteLine($"{word}");


            Console.WriteLine();
            int[][] arr=new int [3][];
            arr[0] = new int[2];
            arr[1] = new int[3];
            arr[2] = new int[4];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j]+"\t");
                }
                Console.WriteLine();
            }

            var arrays = new object[2];
            var strin = string.Empty;

            (int, string, char, string, ulong) tuple = (777, "lucky", 'I', "sleep", 1488) ;
            Console.WriteLine($"{tuple} 1-{tuple.Item1} 3-{tuple.Item3} 4-{tuple.Item4}");
            (int n5, string n1, char n2, string n3, ulong n4) = tuple;
            int m1 = tuple.Item1;
            string m2 = tuple.Item2;
            char m3 = tuple.Item3;
            string m4 = tuple.Item4;
            ulong m5 = tuple.Item5;
            (int k1, _, char k2 , _, ulong k3 ) = tuple;

            (int, double) tuple1 = (123, 2.3);
            (int, double) tuple2 = (123, 2.3);
            Console.WriteLine(tuple1 == tuple2);

            (int max,int min, int sum, char firstletter) tupl(int[]squares, string squar)
            {
                int sum = 0;
                int max = 0;
                int min = 12;

                Console.WriteLine(squar);
                for (int i = 0; i < squares.Length; i++)
                {
                    Console.Write($"{squares[i]}\t");
                    sum += squares[i];
                    if (squares[i] > max)
                        max = squares[i];
                    if (min > squares[i])
                        min = squares[i];
                }
                var result = (max: max, min: min, sum: sum, firstletter: squar[0]);
                return result;
            }
            string square = "макс и мин площади равны: ";
            var tup = tupl(new int[]{ 1,5,9,2,4},square);
            Console.WriteLine($"\nmax:{tup.max}\tmin:{tup.min}\tsum:{tup.sum}\tfirstletter:{tup.firstletter}");

            void checkedfunc(){
                checked
                {
                    int y = int.MaxValue;
                    Console.WriteLine(y);
                }
            };
            void uncheckedfunc(){
                unchecked
                {
                    int y = int.MaxValue;
                    Console.WriteLine(y);
                }
            }
            checkedfunc();
            uncheckedfunc();




            Console.WriteLine("ваззап");
            string a = Console.ReadLine();
            int b=Convert.ToInt16(a);
            int c = 100;
            Console.WriteLine(c + b);


            Console.ReadKey();

        }
    }
}
