using System;

namespace ResumeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select which resume to generate:");
            Console.WriteLine("1. Single-Page Resume (Michael_Roy_Software_Engineer-1pg.pdf)");
            Console.WriteLine("2. Two-Page Resume (Michael_Roy_Software_Engineer-2pg.pdf)");
            Console.Write("Enter 1 for (1-page Resume) or 2 for (2-Page Resume): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SinglePage.RunSinglePage(args);
                    break;
                case "2":
                    TwoPage.RunTwoPage(args);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please run again and enter 1 or 2.");
                    break;
            }
        }
    }
}