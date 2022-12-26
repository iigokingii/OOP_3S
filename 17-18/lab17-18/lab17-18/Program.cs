using System;
using System.Drawing;

namespace lab17_18
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Clear();

            Score score = new Score(new Factory());
            score.Run();

            ConcreteBuilder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Request req = builder.GetResult();
            score.RunWithRequest(req);

            /*Settings setting = new Settings();
            setting.Launch("red", "Cyan");

            Settings settings = new Settings();
            settings.Launch("red", "Cyan");*/



        }
    }
}
