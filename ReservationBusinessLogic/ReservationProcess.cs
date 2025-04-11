using ReservationDataService;

namespace ReservationBusinessLogic
{
    public class ReservationProcess
    {
        private double pricePerGuest = 750;
        private ReservationDataService.ReservationDataService dataService = new ReservationDataService.ReservationDataService();

        public double CalculateTotalAmount(int guests)
        {
            return guests * pricePerGuest;
        }

        public bool ValidatePayment(double paid, double total)
        {
            return paid >= total;
        }

        public double CalculateChange(double paid, double total)
        {
            return paid - total;
        }

        public void AddReservation(string name, string phone, int guests, DateTime date, DateTime booked, string note, string time, string meal)
        {
            Reservation reservation = new Reservation
            {
                FullName = name,
                PhoneNumber = phone,
                NumGuests = guests,
                ReservationDate = date,
                BookingDateTime = booked,
                SpecialRequest = note,
                ReservationTime = time,
                MealType = meal
            };

            dataService.AddReservation(reservation);
        }

        public List<Reservation> GetReservations()
        {
            return dataService.GetReservations();
        }

        public int GetReservationsCount()
        {
            return dataService.GetReservationsCount();
        }

        public void CancelReservation(int index)
        {
            dataService.CancelReservation(index);
        }

        public void UpdateReservation(int index, DateTime date, string time, string meal, string request)
        {
            dataService.UpdateReservation(index, date, time, meal, request);
        }

        public List<string> GetReservationDetails(int index)
        {
            var r = dataService.GetReservation(index);
            return new List<string>
            {
                $"Name: {r.FullName}",
                $"Phone: {r.PhoneNumber}",
                $"Guests: {r.NumGuests}",
                $"Date: {r.ReservationDate:yyyy-MM-dd}",
                $"Time: {r.ReservationTime}",
                $"Meal: {r.MealType}",
                $"Special Request: {r.SpecialRequest}"
            };
        }
    }
}
