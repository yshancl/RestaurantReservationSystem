namespace ReservationDataService
{
    public class Reservation
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int NumGuests { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime BookingDateTime { get; set; }
        public string SpecialRequest { get; set; }
        public string ReservationTime { get; set; }
        public string MealType { get; set; }
    }

    public class ReservationDataService
    {
        private List<Reservation> reservations = new List<Reservation>();

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
        }

        public List<Reservation> GetReservations()
        {
            return reservations;
        }

        public Reservation GetReservation(int index)
        {
            return reservations[index];
        }

        public int GetReservationsCount()
        {
            return reservations.Count;
        }

        public void CancelReservation(int index)
        {
            if (index >= 0 && index < reservations.Count)
                reservations.RemoveAt(index);
        }

    }
}
