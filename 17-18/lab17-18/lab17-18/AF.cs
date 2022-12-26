using System;
using System.Collections.Generic;
using System.Text;

namespace lab17_18
{
    abstract class AbstractHotel  //методы для создания объектов
    {
        public abstract Client CreateClient();
        public abstract Admin CreateAdmin();
    }
    class Factory : AbstractHotel    
    {
        public override Client CreateClient()
        {
            return new Client();
        }

        public override Admin CreateAdmin()
        {
            return new Admin();
        }
    }
    abstract class AbstractProductA     //интерфейсы
    {
        public abstract void CreateRequest();
    }

    abstract class AbstractProductB
    {
        public abstract void ViewRequest(Client client);
    }

    class Client : AbstractProductA  //реализация абстрактных классов
    {
        public class Request
        {
            public int amount;
            public string type;
            public string time;
        }
        public Request request = new Request();
        public override void CreateRequest()
        {
            Console.WriteLine("Количество мест :");
            request.amount=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Тип :");
            request.type = Console.ReadLine();
            Console.WriteLine("Время :");
            request.time = Console.ReadLine();
        }
    
    }

    class Admin : AbstractProductB
    {
        public override void ViewRequest(Client client)
        {
            if(client.request.type == "luxe")
                Console.WriteLine("С вас three hundred bucks");
            if(client.request.amount==2)
                Console.WriteLine("С вас 100$");
        }

    }

    class Score
    {
        private Client client;
        private Admin admin;

        public Score(AbstractHotel factory)
        {
            client = factory.CreateClient();
            admin = factory.CreateAdmin();
        }
        public void Run()
        {
            Console.WriteLine("Запущен ран а ты попущен");
            client.CreateRequest();
            admin.ViewRequest(client);
        
        }
    }
}