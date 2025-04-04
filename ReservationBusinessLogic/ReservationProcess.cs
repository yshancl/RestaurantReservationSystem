namespace ReservationBusinessLogic
{
    public class Reservation
    {
        public string FullName;
        public string PhoneNumber;
        public int NumGuests;
        public DateTime ReservationDate;
        public DateTime BookingDateTime;
        public string SpecialRequest;
        public string ReservationTime;
        public string MealType;

        public Reservation(string fullName, string phoneNumber, int numGuests, DateTime reservationDate, DateTime bookingDateTime, string specialRequest, string reservationTime, string mealType)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            NumGuests = numGuests;
            ReservationDate = reservationDate;
            BookingDateTime = bookingDateTime;
            SpecialRequest = specialRequest;
            ReservationTime = reservationTime;
            MealType = mealType;
        }
    }

    public static class ReservationProcess
    {
        private static List<Reservation> reservations = new List<Reservation>();
        private static double pricePerGuest = 750;

        public static double CalculateTotalAmount(int numGuests)
        {
            return numGuests * pricePerGuest;
        }

        public static bool ValidatePayment(double amountPaid, double totalAmount)
        {
            return amountPaid >= totalAmount;
        }

        public static double CalculateChange(double amountPaid, double totalAmount)
        {
            return amountPaid >= totalAmount ? amountPaid - totalAmount : 0;
        }

        public static void AddReservation(string fullName, string phoneNumber, int numGuests, DateTime reservationDate, DateTime bookingDateTime, string specialRequest, string reservationTime, string mealType)
        {
            reservations.Add(new Reservation(fullName, phoneNumber, numGuests, reservationDate, bookingDateTime, specialRequest, reservationTime, mealType));
        }

        public static List<Reservation> GetReservations()
        {
            return reservations;
        }

        public static int GetReservationsCount()
        {
            return reservations.Count;
        }

        public static void CancelReservation(int index)
        {
            if (index >= 0 && index < reservations.Count)
            {
                reservations.RemoveAt(index);
            }
        }

        // Business logic only returns data, no console output
        public static List<string> GetReservationDetails(int index)
        {
            var reservation = reservations[index];
            return new List<string>
            {
                $"Name: {reservation.FullName}",
                $"Phone: {reservation.PhoneNumber}",
                $"Guests: {reservation.NumGuests}",
                $"Reservation Date: {reservation.ReservationDate:yyyy-MM-dd}",
                $"Time: {reservation.ReservationTime}",
                $"Meal Type: {reservation.MealType}",
                $"Special Request: {reservation.SpecialRequest}"
            };
        }
    }
}
