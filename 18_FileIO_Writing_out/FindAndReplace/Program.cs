using System;
using FindAndReplace.Class;

namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            UserInterface ui = new UserInterface();
            ui.RunUI();
            Console.ReadLine();

        }
    }
}
