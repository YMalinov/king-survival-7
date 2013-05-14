using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        char[,] board = new char[,] {{'+','-','+','-','+','-','+','-'},
                                     {'-','+','-','+','-','+','-','+'},
                                     {'+','-','+','-','+','-','+','-'},
                                     {'-','+','-','+','-','+','-','+'},
                                     {'+','-','+','-','+','-','+','-'},
                                     {'-','+','-','+','-','+','-','+'},
                                     {'+','-','+','-','+','-','+','-'},
                                     {'-','+','-','+','-','+','-','+'}};

        Engine engine = new Engine(board);

        engine.Print();

        bool whoWon = engine.Run();

        if (whoWon)
        {
            Console.WriteLine("Pawn's win!");
        }
        else
        {
            Console.WriteLine("King's win!");
        }
    }
}