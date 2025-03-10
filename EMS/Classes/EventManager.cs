using System;
using System.Collections.Generic;

namespace EventManagementSystem
{
    class EventManager
    {
        private List<Event> events = new List<Event>();
        private int nextEventId = 1;

        /// <summary>
        /// Creates and event based on the user inputs
        /// </summary>
        public void CreateEvent()
        {
            Console.Write("Enter Event Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Location (optional, press Enter to skip): ");
            string location = Console.ReadLine();
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
            events.Add(new Event
            {
                Id = nextEventId++,
                Name = name,
                Date = date,
                Description = description,
                Location = string.IsNullOrWhiteSpace(location) ? "Not specified" : location
            });
            Console.WriteLine("Event added successfully!\n");
        }

        /// <summary>
        /// Lists all of the events, then user can select an event to see the details of event and modify or delete it if needed.
        /// </summary>
        public void ViewEvents()
        {
            Console.Clear();
            if (events.Count == 0)
            {
                Console.WriteLine("No events available.\n");
                return;
            }
            Console.WriteLine("\n-------------------------------------------------------------------------------------");
            Console.WriteLine("| {0,-5} | {1,-20} | {2,-12} | {3,-25} | {4,-20} |", "ID", "Name", "Date", "Description", "Location");
            Console.WriteLine("-------------------------------------------------------------------------------------");
            foreach (var ev in events)
            {
                {
                    Console.WriteLine("| {0,-5} | {1,-20} | {2,-12} | {3,-25} | {4,-20} |",
                        ev.Id,
                        ev.Name.Length > 20 ? ev.Name.Substring(0, 17) + "..." : ev.Name,
                        ev.Date.ToString("yyyy-MM-dd"),
                        ev.Description.Length > 25 ? ev.Description.Substring(0, 22) + "..." : ev.Description,
                        ev.Location.Length > 20 ? ev.Location.Substring(0, 17) + "..." : ev.Location);
                }
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

        /// <summary>
        /// Displays details of selected event, the user can also choose to edit or delete the event
        /// </summary>
        /// <param name="ev">Event Object</param>
        private void ViewOrEditEvent(Event ev)
        {
            Console.Clear();
            Console.WriteLine("\nEvent Details:");
            Console.WriteLine($"ID: {ev.Id}");
            Console.WriteLine($"Name: {ev.Name}");
            Console.WriteLine($"Date: {ev.Date:yyyy-MM-dd}");
            Console.WriteLine($"Location: {ev.Location}");
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

        /// <summary>
        /// Has two functionalities 
        /// 1- an event can be passed to it as args by other methods to be edited
        /// 2- if no event is passed as args the user should type in an event ID to edit
        /// </summary>
        /// <param name="ev"></param>
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

            Console.Write("Enter new Location (leave empty to keep current): ");
            string newLocation = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newLocation)) ev.Location = newLocation;

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

        /// <summary>
        /// Has two functionalities 
        /// 1- an event can be passed as agrs to be deleted
        /// 2- if no arguments are passed the user can type an ID to delete an event
        /// </summary>
        /// <param name="ev"></param>
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

        public void FuzzySearchEvents()
        {
            Console.WriteLine("This fuzzy search feature is not implemented yet! \n");
        }
    }
}