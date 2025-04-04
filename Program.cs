using ReservationBusinessLogic;
using System;

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
                "[4] Exit"
            };

            while (true)
            {
                Console.WriteLine("\n=== Menu ===");
                Console.WriteLine("\nSelect and option:");
                foreach (string option in options)
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
                        CancelReservation();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please select a valid option.");
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
                if (DateTime.TryParse(Console.ReadLine(), out reservationDate))
                {
                    if (reservationDate.Date >= DateTime.Now.Date)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Cannot book a reservation in the past. Please enter a valid date.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid format. Please enter the date as YYYY-MM-DD.");
                }
            }

            DateTime bookingDateTime = DateTime.Now;
            Console.WriteLine($"Reservation Made On: {bookingDateTime}");

            string[] timeSlots = { "4:00 PM - 6:30 PM", "6:30 PM - 9:00 PM", "9:00 PM - 11:00 PM" };
            Console.WriteLine("Available Time Slots:");
            for (int i = 0; i < timeSlots.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {timeSlots[i]}");
            }

            Console.Write("Select a time slot (1-3): ");
            int timeSlotIndex = Convert.ToInt16(Console.ReadLine());
            string reservationTime = timeSlots[timeSlotIndex - 1];

            string[] mealTypes = { "Breakfast", "Lunch", "Dinner" };
            Console.WriteLine("Meal Type:");
            for (int i = 0; i < mealTypes.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {mealTypes[i]}");
            }

            Console.Write("Select a meal type (1-3): ");
            int mealTypeIndex = Convert.ToInt16(Console.ReadLine());
            string mealType = mealTypes[mealTypeIndex - 1];

            Console.Write("Special Requests/Notes: ");
            string specialRequest = Console.ReadLine();

            Console.WriteLine($"Total Reservation Fee: PHP{ReservationProcess.CalculateTotalAmount(numGuests)}");

            Console.Write("Enter Amount Paid: ");
            double amountPaid = Convert.ToDouble(Console.ReadLine());

            if (ReservationProcess.ValidatePayment(amountPaid, ReservationProcess.CalculateTotalAmount(numGuests)))
            {
                Console.WriteLine(
                    ReservationProcess.CalculateChange(amountPaid, ReservationProcess.CalculateTotalAmount(numGuests)) > 0
                    ? $"Reservation confirmed! Your change is PHP{ReservationProcess.CalculateChange(amountPaid, ReservationProcess.CalculateTotalAmount(numGuests))}."
                    : "Reservation success!"
                );

                ReservationProcess.AddReservation(fullName, phoneNumber, numGuests, reservationDate, bookingDateTime, specialRequest, reservationTime, mealType);
                Console.WriteLine("\n===== Reservation Summary =====");
                Console.WriteLine($"Name: {fullName}");
                Console.WriteLine($"Phone: {phoneNumber}");
                Console.WriteLine($"Guests: {numGuests}");
                Console.WriteLine($"Reservation Date: {reservationDate:yyyy-MM-dd}");
                Console.WriteLine($"Time Slot: {reservationTime}");
                Console.WriteLine($"Meal Type: {mealType}");
                Console.WriteLine($"Booking Date & Time: {bookingDateTime}");
                Console.WriteLine($"Special Request: {specialRequest}");
                Console.WriteLine("Thank you for your reservation!");
            }
            else
            {
                Console.WriteLine("Insufficient amount. Reservation not confirmed.");
            }
        }

        static int GetUserInput()
        {
            Console.Write("[User Input]: ");
            return Convert.ToInt16(Console.ReadLine());
        }

        static void ViewReservations()
        {
            Console.WriteLine("==== View Reservations ====");
            if (ReservationProcess.GetReservationsCount() == 0)
            {
                Console.WriteLine("No upcoming reservations.");
            }
            else
            {
                var reservations = ReservationProcess.GetReservations();
                for (int i = 0; i < reservations.Count; i++)
                {
                    var reservationDetails = ReservationProcess.GetReservationDetails(i);
                    foreach (var detail in reservationDetails)
                    {
                        Console.WriteLine(detail);
                    }
                    Console.WriteLine("====================");
                }
            }
        }

        static void CancelReservation()
        {
            Console.WriteLine("==== Cancel Reservation ====");

            // Display all reservations with their name and reservation date
            if (ReservationProcess.GetReservationsCount() == 0)
            {
                Console.WriteLine("No reservations available to cancel.");
                return;
            }

            var reservations = ReservationProcess.GetReservations();
            for (int i = 0; i < reservations.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {reservations[i].FullName} - {reservations[i].ReservationDate:yyyy-MM-dd}");
            }

            Console.Write("Enter the reservation number to cancel: ");
            int reservationNumber = Convert.ToInt16(Console.ReadLine()) - 1;

            if (reservationNumber >= 0 && reservationNumber < ReservationProcess.GetReservationsCount())
            {
                ReservationProcess.CancelReservation(reservationNumber);
                Console.WriteLine("Reservation canceled successfully.");
            }
            else
            {
                Console.WriteLine("Invalid reservation number.");
            }
        }
    }
}
