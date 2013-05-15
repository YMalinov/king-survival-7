using System;

namespace KingSurvival
{
    class ZProgram // the 'Z' is so that this file goes to the bottom when sorted
    {
        static void Main()
        {
            Engine engine = new Engine(8);

            engine.Print();

            engine.Run();
        }
    }
}