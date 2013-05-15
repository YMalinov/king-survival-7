using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Engine engine = new Engine(8);

        engine.Print();

        engine.Run();
    }
}