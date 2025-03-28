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
                Console.WriteLine("Choose an option: ");
                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }

                string selectedOption = Console.ReadLine();

                if (selectedOption == "1")
                {
                    BookReservation();
                }
                else if (selectedOption == "2")
                {
                    ViewReservations();
                }
                else if (selectedOption == "3")
                {
                    CancelReservation();
                }
                else if (selectedOption == "4")
                {
                    Console.WriteLine("Exiting program...");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid option.");
                }
            }
        }

        static void BookReservation()
        {
            Console.WriteLine("==== Book a reservation ====");
            Console.Write("Full Name: ");
            string fullName = Console.ReadLine();

            string phoneNumber;
            Console.Write("Phone Number: ");
            while (true)
            {
                phoneNumber = Console.ReadLine();
                if (long.TryParse(phoneNumber, out _) && phoneNumber.Length == 11)
                    break;
                Console.WriteLine("Invalid input. Please enter a valid phone number (numbers only).");
                Console.Write("Phone Number: ");
            }

            int numGuests;
            Console.Write("Number of Guests: ");
            while (!int.TryParse(Console.ReadLine(), out numGuests) || numGuests <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of guests.");
                Console.Write("Number of Guests: ");
            }

            string[] guestNames = new string[numGuests];
            for (int i = 0; i < numGuests; i++)
            {
                Console.Write($"Guest {i + 1} Name: ");
                guestNames[i] = Console.ReadLine();
            }

            Console.Write("Date (YYYY-MM-DD): ");
            string reservationDate = Console.ReadLine();

            string[] timeSlots = { "4:00 PM - 6:30 PM", "6:30 PM - 9:00 PM", "9:00 PM - 11:00 PM" };
            Console.WriteLine("Available Time Slots:");
            for (int i = 0; i < timeSlots.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {timeSlots[i]}");
            }

            int timeSlotIndex;
            Console.Write("Select a time slot (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out timeSlotIndex) || timeSlotIndex < 1 || timeSlotIndex > timeSlots.Length)
            {
                Console.WriteLine("Invalid input. Please select a valid time slot (1-3).");
                Console.Write("Select a time slot: ");
            }
            string reservationTime = timeSlots[timeSlotIndex - 1];

            string[] mealTypes = { "Breakfast", "Lunch", "Dinner" };
            Console.WriteLine("Meal Type:");
            for (int i = 0; i < mealTypes.Length; i++)
            {
                Console.WriteLine($"[{i + 1}] {mealTypes[i]}");
            }

            int mealTypeIndex;
            Console.Write("Select Meal Type (1-3): ");
            while (!int.TryParse(Console.ReadLine(), out mealTypeIndex) || mealTypeIndex < 1 || mealTypeIndex > mealTypes.Length)
            {
                Console.WriteLine("Invalid input. Please select a valid meal type (1-3).");
                Console.Write("Select Meal Type: ");
            }
            string mealType = mealTypes[mealTypeIndex - 1];

            Console.Write("Special Requests/Notes (e.g., complimentary cake, table near the window): ");
            string specialRequest = Console.ReadLine();

            Console.WriteLine("\n===== Reservation Summary =====");
            Console.WriteLine($"Full Name: {fullName}");
            Console.WriteLine($"Phone Number: {phoneNumber}");
            Console.WriteLine($"Date: {reservationDate}");
            Console.WriteLine($"Time Slot: {reservationTime}");
            Console.WriteLine($"Meal Type: {mealType}");
            Console.WriteLine($"Number of Guests: {numGuests}");
            Console.WriteLine("Guest Names: " + string.Join(", ", guestNames));
            Console.WriteLine($"Special Requests: {specialRequest}");
            Console.WriteLine("===============================");

            Console.Write("Confirm reservation? (YES/NO): ");
            string confirmation = Console.ReadLine().Trim().ToUpper();

            if (confirmation != "YES")
            {
                Console.WriteLine("Reservation cancelled.");
                return;
            }

            double totalAmount = numGuests * 750;
            double amountPaid;
            Console.Write($"Reservation Fee: PHP{totalAmount}. Enter Amount: ");
            while (!double.TryParse(Console.ReadLine(), out amountPaid) || amountPaid < totalAmount)
            {
                Console.WriteLine(amountPaid < totalAmount ? "Insufficient amount. Please enter the exact amount." : "Invalid input. Please enter a valid amount.");
                Console.Write($"Reservation Fee: PHP{totalAmount}. Enter Amount: ");
            }

            if (amountPaid > totalAmount)
            {
                Console.WriteLine($"Reservation confirmed! Your change is PHP{amountPaid - totalAmount}.");
            }
            else
            {
                Console.WriteLine("Reservation success!");
            }
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
