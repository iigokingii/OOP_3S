using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    class AdminsRoom
    {
        int numberOfFreeRooms = 10;
        public void Rent()
        {
            if (numberOfFreeRooms > 0)
            {
                numberOfFreeRooms--;
                Console.WriteLine("Номер забронирован. В отеле еще свободно {0} комнат",numberOfFreeRooms);
            }
            else
            {
                Console.WriteLine("К сожалению, в отеле нет свободных мест");
            }
        }
        public HotelMemento SaveState()
        {
            Console.WriteLine("Сохранение количества свободных комнат . Свободных комнат : {0}", numberOfFreeRooms);
            return new HotelMemento(numberOfFreeRooms);
        }

        // восстановление состояния
        public void RestoreState(HotelMemento memento)
        {
            this.numberOfFreeRooms = memento.FreeRoom;
            Console.WriteLine("Восстановление количества свободных комнат . Свободных комнат : {0}", numberOfFreeRooms);
        }
    }

    class HotelMemento
    {
        public int FreeRoom { get; private set; }
        public int Lives { get; private set; }

        public HotelMemento(int _FreeRoom)
        {
            this.FreeRoom = _FreeRoom;
        }
    }
    class HotelHistory
    {
        public Stack<HotelMemento> History { get; private set; }
        public HotelHistory()
        {
            History = new Stack<HotelMemento>();
        }
    }






    /*class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.Shoot(); // делаем выстрел, осталось 9 патронов
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState()); // сохраняем игру

            hero.Shoot(); //делаем выстрел, осталось 8 патронов

            hero.RestoreState(game.History.Pop());

            hero.Shoot(); //делаем выстрел, осталось 8 патронов

            Console.Read();
        }
    }

    // Originator
    class Hero
    {
        private int patrons = 10; // кол-во патронов
        private int lives = 5; // кол-во жизней

        public void Shoot()
        {
            if (patrons > 0)
            {
                patrons--;
                Console.WriteLine("Производим выстрел. Осталось {0} патронов", patrons);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }
        // сохранение состояния
        public HeroMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", patrons, lives);
            return new HeroMemento(patrons, lives);
        }

        // восстановление состояния
        public void RestoreState(HeroMemento memento)
        {
            this.patrons = memento.Patrons;
            this.lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней", patrons, lives);
        }
    }
    // Memento
    class HeroMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    // Caretaker
    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }*/
}
