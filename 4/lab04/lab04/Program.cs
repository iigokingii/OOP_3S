using System;
using System.Collections.Generic;
namespace lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            land Land = new land(123999, "peat soil");
            Console.WriteLine($"information about first object:\n{Land.ToString()}");
            Land.DoClone();
            ((IInformation)Land).DoClone();

            continent Eurasia = new continent("Евразия", 322332,"coal") ;
            continent Africa = new continent("Африка", 322332, "coal");
            Console.WriteLine($"\ninformation about second object:\n{Eurasia.ToString()}");
            Console.WriteLine($"переопределенные методы:\nHashcode:{Eurasia.GetHashCode()},\tEquals:{Eurasia.Equals(Africa)},\tToString: {Eurasia.ToString()}\n");

            continent.state Belarus = new continent.state("Belarus");
            Console.WriteLine($"information about third object:\n{Belarus.ToString()}\n"); 


            island Hawaiian = new island(1234,"sand", "Hawaiian Islands");
            Console.WriteLine($"information about fourth object:\n{Hawaiian.ToString()}\n");

            water Water = new water(1400000000);
            Console.WriteLine($"information about fifth object:\n{Water.ToString()}\n");

            sea Pacific = new sea(710360000, "Pacific Ocean");
            Console.WriteLine($"information about sixth object:\n{Pacific.ToString()}\n");

            Console.WriteLine("Using as / is:");
            if (Eurasia is land)
            {
                Console.WriteLine("this is the land");
            }
            if(Africa is continent)
            {
                Console.WriteLine("it is a continent");
            }
            if (Hawaiian as island == null)
            {
                Console.WriteLine("невозможно привести Hawaiian к типу island");
            }
            else
            {
                Console.WriteLine("возможно");
            }
            if (Hawaiian as land == null)
            {
                Console.WriteLine("невозможно привести Hawaiian к типу land");
            }
            else
            {
                Console.WriteLine("возможно");
            }

            Console.WriteLine("\nкласс Printer c полиморфным методом:");
            List<land> list = new List<land> { new land(444211, "soil"), new continent("Австралия", 322332, "coal"), new island(1234, "sand", "Hawaiian Islands")};
            Printer printer = new Printer();
            foreach(land counter in list)
            {
                Console.WriteLine(printer.IAmPrinting(counter));
            }

        }
    }
}
