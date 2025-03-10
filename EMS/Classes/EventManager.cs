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
            DateTime date;
            while (true)
            {
                Console.Write("Enter Event Date (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();

                if (DateTime.TryParse(dateInput, out date))
                {
                    break; // Exit loop if date is valid
                }
                else
                {
                    Console.WriteLine("Invalid date format! Please enter a valid date (yyyy-mm-dd).");
                }
            }
            Console.Write("Enter Description: ");
            string description = Console.ReadLine();

            events.Add(new Event { Id = nextEventId++, Name = name, Date = date, Description = description });
            Console.WriteLine("Event added successfully!\n");
        }

        public void ViewEvents()
        {
            Console.Clear();
            if (events.Count == 0)
            {
                Console.WriteLine("No events available.\n");
                return;
            }
            foreach (var ev in events)
            {
                Console.WriteLine($"ID: {ev.Id}, Name: {ev.Name}, Date: {ev.Date:yyyy-MM-dd}, Description: {ev.Description}\n");
            }
        }

        public void DeleteEvent()
        {
            Console.Write("Enter Event ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            Event ev = events.Find(e => e.Id == id);
            if (ev != null)
            {
                events.Remove(ev);
                Console.WriteLine("Event deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Event not found!\n");
            }
        }

    }
}