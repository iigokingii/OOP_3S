using System;
using System.Collections.Generic;
namespace lab04
{
    enum Classes
    {
        continent,
        island,
        land,
        printer,
        sea,
        surface,
        water,
        planet,
        controller
    }
    struct structure
    {
        int numberOfClasses;
        string types;
        int overloading;
        bool List;
        bool Array;
        public structure(int _numberOfClasses,string _types,int _overloading,bool _List,bool _Array)
        {
            numberOfClasses = _numberOfClasses;
            types = _types;
            overloading = _overloading;
            List = _List;
            Array = _Array;
        }
        public string Print()
        {
            return $"\nВ лабораторной работе {numberOfClasses} классов, есть следующие типы:{types}.Есть {overloading} перегрузок,{List} лист, {Array} массив";
        }
    }
    class Planet
    {
        List<object> container;
        Printer printer1 = new Printer();
        public Planet() { }
        public void add(params object[] someobjects)
        {
            foreach (var obj in someobjects) {
                container.Add(obj);
            }
        }
        public void delete(object someobj)
        {
            container.RemoveAt(container.IndexOf(someobj));
        }
        public void print()
        {
            Console.WriteLine("\nВывод списка в консоль:");
            foreach (object tmp in container)
            {
                if (tmp is land)
                Console.WriteLine(printer1.IAmPrinting((land)tmp));
                else if(tmp is island)
                    Console.WriteLine(printer1.IAmPrinting((island)tmp));
                else if(tmp is continent)
                    Console.WriteLine(printer1.IAmPrinting((continent)tmp));
                else if(tmp is sea)
                    Console.WriteLine(printer1.IAmPrinting((sea)tmp));
                else if(tmp is surface)
                    Console.WriteLine(printer1.IAmPrinting((surface)tmp));
                else if(tmp is water)
                    Console.WriteLine(printer1.IAmPrinting((water)tmp));
            }
        }
        public List<object> Container
        {
            get
            {
                return container;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ошибка создания");
                else
                {
                    container = value;
                }
            }
        }
        
    }   

    class Controller
    {
        public void findState(Planet obj,string name)
        {
            state State = new state();
            for (int i = 0; i < obj.Container.Count; i++)
            {
                object tmp = obj.Container[i];
                if(tmp is state)
                {
                    State = (state)tmp;
                    if(State.name==name)
                        Console.WriteLine(State.ToString());
                }
            }
        }
        public int findSea(Planet obj)
        {
            int counter = 0;
            sea Sea = new sea();
            for (int i = 0; i < obj.Container.Count; i++)
            {
                object tmp = obj.Container[i];
                if (tmp is sea)
                {
                    counter++;
                }
            }
            return counter;
        }
        public void printIsland(Planet obj)
        {
            List<island> list= new List<island>();
            for (int i = 0; i < obj.Container.Count; i++)
            {
                object temp = obj.Container[i];
                if (temp is island)
                {
                    list.Add((island)temp);
                }
            }

            list.Sort((x,y)=>x.Name.CompareTo(y.Name));
            foreach(island isl in list)
            {
                Console.WriteLine(isl.ToString());
            }
        }
    }

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
            Console.WriteLine($"\ninformation about second object:\n{Eurasia.ToString()}\n");
            Console.WriteLine($"переопределенные методы:\nHashcode:{Eurasia.GetHashCode()},\tEquals:{Eurasia.Equals(Africa)},\tToString: {Eurasia.ToString()}\n");

            state Belarus = new state("Евразия",32145,"podzolic","Belarus");
            Console.WriteLine($"information about third object:\n{Belarus.ToString()}\n");


            island Hawaiian = new island(1234,"sand", "Hawaiian Islands");
            Console.WriteLine($"information about fourth object:\n{Hawaiian.ToString()}\n");

            water Water = new water(1400000000);
            Console.WriteLine($"information about fifth object:\n{Water.ToString()}\n");

            sea Pacific = new sea(710360000, "Pacific Ocean");
            Console.WriteLine($"information about sixth object:\n{Pacific.ToString()}\n");
            Console.WriteLine("is/as:");
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

            //struct,enum

            Classes classes = Classes.controller;

            string types = "sealed,abstract,partial";
            structure Lab04 = new structure(9,types,((int)classes)+1,true,false);
            Console.WriteLine(Lab04.Print());





            //контейнер и контейнер
            Planet planet = new Planet();
            planet.Container = new List<object>();

            state Russia = new state("Евразия", 17100000, "podzolic", "Russia");
            state Poland = new state("Евразия", 322575, "loamy", "Poland");
            state Ukraine = new state("Евразия", 207600, "black soil", "Ukraine");
            state Niger = new state("Африка", 1267000, "sand", "Нигер");
            island Maldives = new island(54353, "sand", "Maldives");
            island Bora = new island(24334, "sand", "Bora Bora");

            planet.add(Russia,Poland,Ukraine,Land,Pacific,Maldives,Bora,Niger,Hawaiian);
            planet.delete(Poland);
            planet.print();
            Controller controller = new Controller();
            Console.WriteLine("\nПоиск государств на континенте:");
            Console.WriteLine("Введите континент");
            string name =Console.ReadLine();
            controller.findState(planet,name);
            Console.WriteLine($"\nколичество морей в классе контейнере:{controller.findSea(planet)}");
            Console.WriteLine("\nВывод островов ,добавленных в контейнер, в алфавитном порядке:");
            controller.printIsland(planet);


            Console.WriteLine();


        }
    }
}
