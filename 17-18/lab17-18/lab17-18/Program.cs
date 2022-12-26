using System;

namespace lab17_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Score score = new Score(new Factory());
            score.Run();

           
        }
    }
}
