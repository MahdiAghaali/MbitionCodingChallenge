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
                Console.WriteLine("1. Create a new Event");
                Console.WriteLine("2. View all Events");
                Console.WriteLine("3. Delete an Event");
                Console.WriteLine("4. Modify an Event");
                Console.WriteLine("5. Search events");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": manager.CreateEvent(); break;
                    case "2": manager.ViewEvents(); break;
                    case "3": manager.DeleteEvent(); break;
                    case "4": manager.EditEvent(); break;
                    case "5": manager.FuzzySearchEvents(); break;
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
