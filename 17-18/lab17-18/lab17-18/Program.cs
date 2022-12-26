using System;
using System.Drawing;

namespace lab17_18
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Console.Clear();

            *//*Console.Clear();*//*
            //Abstract Factory
            Score score = new Score(new Factory());
            score.Run();

            //Builder
            ConcreteBuilder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Request req = builder.GetResult();
            score.RunWithRequest(req);

            //Prototype
            IFigure requestClone = req.Clone();
            requestClone.GetInfo();

            //Singleton
            Settings setting = new Settings();
            setting.Launch("green", "Cyan");
            Settings settings = new Settings();
            settings.Launch("red", "Cyan");*/

            //Adapter



            //Decorator
            Room room = new CentralLocation();
            Console.WriteLine("Местоположение :{0}, Цена :{1}$",room.Location,room.GetFinalCoast());
            room = new WithDustRoom(room);
            Console.WriteLine("Местоположение :{0}, Цена :{1}$", room.Location, room.GetFinalCoast());




        }
    }
}
