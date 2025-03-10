using System;
using System.Collections.Generic;

namespace EventManagementSystem
{
    class EventManager
    {
        private List<Event> events = new List<Event>();
        private int nextEventId = 1;

        public void CreateEvent()
        {
            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Event Date (yyyy-mm-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            events.Add(new Event { Id = nextEventId++, Name = name, Date = date, Description = description });
            Console.WriteLine("Event added successfully!\n");
        }

    }
}