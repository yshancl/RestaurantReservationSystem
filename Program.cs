using System;
using ReservationBusinessLogic;
using ReservationDataLogic;
using ReservationDataService;
using Microsoft.Extensions.Configuration; // Add this using statement

namespace RestaurantReservationSystem
{
    internal class Program
    {
        static ReservationProcess reservationService;

        static void Main(string[] args)
        {
            IReservationDataService dataService = new ReservationDataService.ReservationDataService();

            // Create a default configuration instance
            IConfiguration configuration = new ConfigurationBuilder().Build();

            reservationService = new ReservationProcess(dataService, configuration);

            Console.WriteLine("Welcome to Seoul House!");

            string[] options = {
                "[1] Book a reservation",
                "[2] View Reservations",
                "[3] Update Reservation",
                "[4] Cancel Reservation",
                "[5] Exit"
            };

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                foreach (var option in options)
                {
                    Console.WriteLine(option);
                }

                int selectedOption = GetUserInput();

                switch (selectedOption)
                {
                    case 1:
                        BookReservation();
                        break;
                    case 2:
                        ViewReservations();
                        break;
                    case 3:
                        UpdateReservation();
                        break;
                    case 4:
                        CancelReservation();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void BookReservation()
        {
            Console.WriteLine("\n==== Book a Reservation ====");
            Console.Write("Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Number of Guests: ");
            int numGuests = Convert.ToInt32(Console.ReadLine());

            DateTime reservationDate;
            while (true)
            {
                Console.Write("Reservation Date (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out reservationDate) && reservationDate.Date >= DateTime.Now.Date)
                    break;
                Console.WriteLine("Invalid date. Try again.");
            }

            DateTime bookingDateTime = DateTime.Now;

            string[] timeSlots = { "4:00 PM - 6:30 PM", "6:30 PM - 9:00 PM", "9:00 PM - 11:00 PM" };
            for (int i = 0; i < timeSlots.Length; i++)
                Console.WriteLine($"[{i + 1}] {timeSlots[i]}");
            Console.Write("Select time slot: ");
            string reservationTime = timeSlots[Convert.ToInt32(Console.ReadLine()) - 1];

            string[] mealTypes = { "Breakfast", "Lunch", "Dinner" };
            for (int i = 0; i < mealTypes.Length; i++)
                Console.WriteLine($"[{i + 1}] {mealTypes[i]}");
            Console.Write("Select meal type: ");
            string mealType = mealTypes[Convert.ToInt32(Console.ReadLine()) - 1];

            Console.Write("Special Requests: ");
            string specialRequest = Console.ReadLine();

            double total = reservationService.CalculateTotalAmount(numGuests);
            Console.WriteLine($"Total Fee: PHP{total}");

            Console.Write("Enter amount paid: ");
            double amountPaid = Convert.ToDouble(Console.ReadLine());

            if (reservationService.ValidatePayment(amountPaid, total))
            {
                double change = reservationService.CalculateChange(amountPaid, total);
                Console.WriteLine(change > 0 ? $"Change: PHP{change}" : "Exact amount received.");

                reservationService.AddReservation(fullName, phoneNumber, numGuests, reservationDate, bookingDateTime, specialRequest, reservationTime, mealType);
                Console.WriteLine("Reservation confirmed!");
            }
            else
            {
                Console.WriteLine("Insufficient payment. Reservation not confirmed.");
            }
        }

        static void ViewReservations()
        {
            Console.WriteLine("==== View Reservations ====");
            var reservations = reservationService.GetReservations();

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations.");
                return;
            }

            foreach (var r in reservations)
            {
                var details = reservationService.GetReservationDetails(r.ReservationId);
                foreach (var line in details)
                    Console.WriteLine(line);
                Console.WriteLine("-------------------------");
            }
        }

        static void CancelReservation()
        {
            Console.WriteLine("==== Cancel Reservation ====");
            var reservations = reservationService.GetReservations();

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations to cancel.");
                return;
            }

            for (int i = 0; i < reservations.Count; i++)
                Console.WriteLine($"{i + 1}. {reservations[i].FullName} - {reservations[i].ReservationDate:yyyy-MM-dd}");

            Console.Write("Enter reservation number to cancel: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < reservations.Count)
            {
                int reservationId = reservations[index].ReservationId;
                reservationService.CancelReservation(reservationId);
                Console.WriteLine("Reservation cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid reservation number.");
            }
        }

        static void UpdateReservation()
        {
            Console.WriteLine("==== Update Reservation ====");
            var reservations = reservationService.GetReservations();

            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations to update.");
                return;
            }

            for (int i = 0; i < reservations.Count; i++)
                Console.WriteLine($"{i + 1}. {reservations[i].FullName} - {reservations[i].ReservationDate:yyyy-MM-dd}");

            Console.Write("Enter reservation number to update: ");
            int index = Convert.ToInt32(Console.ReadLine()) - 1;

            if (index >= 0 && index < reservations.Count)
            {
                int reservationId = reservations[index].ReservationId;

                DateTime newDate;
                while (true)
                {
                    Console.Write("Enter new reservation date (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out newDate) && newDate.Date >= DateTime.Now.Date)
                        break;
                    Console.WriteLine("Invalid date. Try again.");
                }

                string[] timeSlots = { "4:00 PM - 6:30 PM", "6:30 PM - 9:00 PM", "9:00 PM - 11:00 PM" };
                for (int i = 0; i < timeSlots.Length; i++)
                    Console.WriteLine($"[{i + 1}] {timeSlots[i]}");
                Console.Write("Select new time slot: ");
                string reservationTime = timeSlots[Convert.ToInt32(Console.ReadLine()) - 1];

                string[] mealTypes = { "Breakfast", "Lunch", "Dinner" };
                for (int i = 0; i < mealTypes.Length; i++)
                    Console.WriteLine($"[{i + 1}] {mealTypes[i]}");
                Console.Write("Select new meal type: ");
                string mealType = mealTypes[Convert.ToInt32(Console.ReadLine()) - 1];

                Console.Write("New Special Requests: ");
                string specialRequest = Console.ReadLine();

                reservationService.UpdateReservation(reservationId, newDate, reservationTime, mealType, specialRequest);
                Console.WriteLine("Reservation updated.");
            }
            else
            {
                Console.WriteLine("Invalid reservation number.");
            }
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]: ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
