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
            BackColor();
            Font();
        }
        public void BackColor()
        {
            Console.BackgroundColor = ConsoleColor.Green;
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
        { }

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