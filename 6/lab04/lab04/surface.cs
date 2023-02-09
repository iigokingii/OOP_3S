using System;

namespace lab04
{
    abstract class surface
    {
        public void Surface()
        {
            Console.WriteLine("Вы находитесь на поверхности Земли");
        }
        public abstract void DoClone();
    }
}
