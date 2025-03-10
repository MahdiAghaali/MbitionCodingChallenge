using System;
namespace EventManagementSystem
{
    class Program
    {
        static void Main()
        {
            EventManager manager = new EventManager();
            while (true)
            {
                Console.WriteLine("Event Management System");
                Console.WriteLine("1. Add Event");
                Console.WriteLine("2. View Events");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": manager.CreateEvent(); break;
                    // case "2": manager.ViewEvents(); break;
                    case "0": return;
                    default: 
                    {   
                        Console.Clear();
                        Console.WriteLine("Invalid Input! Please try again. \n"); 
                    } break;
                }
            }
        }
    }
}
