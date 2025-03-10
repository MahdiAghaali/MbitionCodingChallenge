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
            Console.Write("Enter Event ID to View Details or Edit (or press Enter to go back): ");
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return;

            if (int.TryParse(input, out int eventId))
            {
                Event selectedEvent = events.FirstOrDefault(e => e.Id == eventId);
                if (selectedEvent != null)
                {
                    ViewOrEditEvent(selectedEvent);
                }
                else
                {
                    Console.WriteLine("Invalid ID! No such event found.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter a valid event ID.\n");
            }
        }

        private void ViewOrEditEvent(Event ev)
        {
            Console.Clear();
            Console.WriteLine("\nEvent Details:");
            Console.WriteLine($"ID: {ev.Id}");
            Console.WriteLine($"Name: {ev.Name}");
            Console.WriteLine($"Date: {ev.Date:yyyy-MM-dd}");
            Console.WriteLine($"Description: {ev.Description}");
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Edit Event");
            Console.WriteLine("2. Delete Event");
            Console.WriteLine("3. Go Back");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditEvent(ev);
                    break;
                case "2":
                    DeleteEvent(ev);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice! Returning to main menu.\n");
                    break;
            }
        }

        public void EditEvent(Event ev = null)
        {
            if (ev == null)
            {
                Console.Write("Enter Event ID to edit: ");
                if (!int.TryParse(Console.ReadLine(), out int eventId))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.\n");
                    return;
                }

                ev = events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                {
                    Console.WriteLine("No event found with that ID!\n");
                    return;
                }
            }
            Console.Write("Enter new name (leave empty to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName)) ev.Name = newName;

            Console.Write("Enter new date (yyyy-mm-dd, leave empty to keep current): ");
            string newDate = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDate) && DateTime.TryParse(newDate, out DateTime parsedDate))
            {
                ev.Date = parsedDate;
            }
            Console.Write("Enter new description (leave empty to keep current): ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription)) ev.Description = newDescription;

            Console.WriteLine("Event updated successfully!\n");
        }

        public void DeleteEvent(Event ev = null)
        {
            if (ev == null)
            {
                Console.Write("Enter Event ID to delete: ");
                if (!int.TryParse(Console.ReadLine(), out int eventId))
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.\n");
                    return;
                }

                ev = events.FirstOrDefault(e => e.Id == eventId);
                if (ev == null)
                {
                    Console.WriteLine("No event found with that ID!\n");
                    return;
                }
            }

            Console.Write($"Are you sure you want to delete '{ev.Name}'? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                events.Remove(ev);
                Console.WriteLine("Event deleted successfully!\n");
            }
            else
            {
                Console.WriteLine("Deletion canceled.\n");
            }
        }

    }
}