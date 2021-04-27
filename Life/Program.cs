using System;
using ConsoleTables;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Playground playground = new Playground();
            playground.GameStart(100, 30, 300); 
        }
    }   
}