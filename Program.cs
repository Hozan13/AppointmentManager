 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManager
{
    internal class Program
    {
        static List<(DateTime dateTime, string description)> appointments = new List<(DateTime, string )> ();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("--- Appointment Manager ---");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. List Appointment");
                Console.WriteLine("3. Delete Appointment");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddAppointment();
                }
                else if (choice == "2")
                {
                    ListAppointment();
                }
                else if (choice == "3")
                {
                    DeleteAppointment();
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Exiting... Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
                Console.WriteLine();
            }
        }

        static void AddAppointment()
        {
            Console.WriteLine("Enter date and time (yyyy-MM-dd HH:mm): ");
            DateTime dateTime;
            while (!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Invalid format. Please enter a valid date and time (yyyy-MM-dd HH:mm): ");
            }
            Console.WriteLine("Enter description: ");
            string description = Console.ReadLine();

            appointments.Add((dateTime, description));
            Console.WriteLine("Appointment added successfully!");
        }

        static void ListAppointment()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments available.");
                return;
            }

            Console.WriteLine("--- Appointments ---");
            for (int i = 0; i < appointments.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {appointments[i].dateTime:yyyy-MM-dd HH:mm} - {appointments[i].description}");
            }
        }


        static void DeleteAppointment()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No appointments to delete.");
                return;
            }
            Console.WriteLine("Enter the number of the appointment to delete: ");
            int index;
            while(!int.TryParse(Console.ReadLine(), out index) || index < 1 || index > appointments.Count)
            {
                Console.WriteLine("Invalid input. Please enter a valid number: ");
            }
            appointments.RemoveAt(index - 1);
            Console.WriteLine("Appointment deleted successfully!");
        }
    }
}
