using ReservationBusinessLogic;

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
                Console.WriteLine("\nChoose an option:");
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
            Console.WriteLine("==== Book a Reservation ====");

            Console.Write("Full Name: ");
            string fullName = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Console.Write("Number of Guests: ");
            int numGuests = Convert.ToInt32(Console.ReadLine());

            Console.Write("Date (YYYY-MM-DD): ");
            string reservationDate = Console.ReadLine();

            Console.Write("Special Requests/Notes: ");
            string specialRequest = Console.ReadLine();

            Console.WriteLine($"Total Reservation Fee: PHP{ReservationProcess.CalculateTotalAmount(numGuests)}");

            Console.Write("Enter Amount Paid: ");
            double amountPaid = Convert.ToDouble(Console.ReadLine());

            if (ReservationProcess.ValidatePayment(amountPaid, ReservationProcess.CalculateTotalAmount(numGuests)))
            {
                double change = ReservationProcess.CalculateChange(amountPaid, ReservationProcess.CalculateTotalAmount(numGuests));
                Console.WriteLine(change > 0 ? $"Reservation confirmed! Your change is PHP{change}." : "Reservation success!");
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
            Console.WriteLine("No upcoming reservations.");
        }

        static void CancelReservation()
        {
            Console.WriteLine("==== Cancel Reservations ====");
            Console.WriteLine("Reservation canceled successfully.");
        }
    }
}
