using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    class Settings
    {
        public Singleton Setting { get; set; }
        public void Launch(string _BColor, string _font)
        {
            Setting = Singleton.getInstance();
        }
        public void BackColor()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Clear();
        }
        public void Font()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
    class Singleton
    {
        private static Singleton instance;

        public string Name { get; private set; }

        protected Singleton()
        {
            
        }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                Console.WriteLine("Создан Singleton объект");
                instance = new Singleton();
            }
               
            return instance;
        }
    }
}

/*
 class Program
{
    static void Main(string[] args)
    {
        Computer comp = new Computer();
        comp.Launch("Windows 8.1");
        Console.WriteLine(comp.OS.Name);
         
        // у нас не получится изменить ОС, так как объект уже создан    
        comp.OS = OS.getInstance("Windows 10");
        Console.WriteLine(comp.OS.Name);
         
        Console.ReadLine();
    }
}
class Computer
{
    public OS OS { get; set; }
    public void Launch(string osName)
    {
        OS = OS.getInstance(osName);
    }
}
class OS
{
    private static OS instance;
 
    public string Name { get; private set; }
 
    protected OS(string name)
    {
        this.Name=name;
    }
 
    public static OS getInstance(string name)
    {
        if (instance == null)
            instance = new OS(name);
        return instance;
    }
}
 
 */