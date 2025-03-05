using System.ComponentModel.Design;

namespace RestaurantReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Seoul House!");

            string[] options = {
                "[1] Book a reservation",
                "[2] View Reservations",
                "[3] Cancel Reservation",
            };

            Console.WriteLine("Choose an option: ");
            foreach (string option in options)
            {
                Console.WriteLine(option);
            }

            string selectedOption = Console.ReadLine();

            if (selectedOption == "1")
            {
                Console.WriteLine("==== Book a reservation ====");
                Console.Write("Full Name: ");
                string fullName = Console.ReadLine();

                Console.Write("Contact Information: ");
                string contact = Console.ReadLine();

                Console.Write("Date & Time (YYYY-MM-DD HH:MM): ");
                string dateTimeInput = Console.ReadLine();

                string[] mealTypes = { "Breakfast", "Lunch", "Dinner" };
                Console.WriteLine("Meal Type:");
                foreach (var meal in mealTypes)
                {
                    Console.WriteLine($"- {meal}");
                }
                Console.Write("Select Meal Type: ");
                string mealType = Console.ReadLine();

                Console.Write("Reservation success!");
            }
            else if (selectedOption == "2")
            {
                Console.WriteLine("==== View Reservations ====");
                Console.WriteLine("No upcoming reservations");
            }
            else if (selectedOption == "3")
            {
                Console.WriteLine("==== Cancel Reservations ====");
                Console.WriteLine("Reservation canceled successfully.");
            }
        }
    }
}
