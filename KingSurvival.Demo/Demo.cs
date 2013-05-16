using System;
using KingSurvival;

namespace KingSurvival.Demo
{
    class Demo
    {
        static void Main()
        {
            Engine engine = new Engine(8);

            engine.Print();

            engine.Run();
        }
    }
}
