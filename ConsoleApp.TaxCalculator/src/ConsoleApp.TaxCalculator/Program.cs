using ConsoleApp.TaxCalculator.Models;
using System;

namespace ConsoleApp.TaxCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            do
            {
                userInput = Menu.DisplayMenu();
                if (userInput == 1)
                {
                    Menu.AddNewItem();
                }
                else if (userInput == 2) { }
                else if (userInput == 3) { }
                else if (userInput == 4) { }
                else
                {
                    Console.WriteLine("Display bill");
                }
            } while (userInput != 5);
        }
    }
}
