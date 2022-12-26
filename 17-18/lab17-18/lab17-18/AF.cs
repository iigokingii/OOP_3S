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
        public Client()
        {
            Console.WriteLine("Количество мест :");
            request.amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Тип :");
            request.type = Console.ReadLine();
            Console.WriteLine("Время :");
            request.time = Console.ReadLine();
        }
        public Request request = new Request();
        public override void CreateRequest()
        { }
    
    }

    class Admin : AbstractProductB
    {
        public override void ViewRequest(Client client)
        {
            if(String.Equals(client.request.type, "first class"))
                Console.WriteLine("С вас 300$");
            if(client.request.amount==12)
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
            admin.ViewRequest(client);
        }
        public void RunWithRequest(Request request)
        {
            if (String.Equals(request.parts[1], "luxe"))
                Console.WriteLine("С вас 200$");
            if (request.parts[0] == "12")
                Console.WriteLine("С вас 150$");
        }
    }
}