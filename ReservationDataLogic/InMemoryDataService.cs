using ReservationDataLogic;
using ReservationDataService;
using System;
using System.Collections.Generic;

namespace ReservationDataService
{
    public class InMemoryDataService : IReservationDataService
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

        public void UpdateReservation(int index, DateTime date, string time, string meal, string request)
        {
            if (index >= 0 && index < reservations.Count)
            {
                reservations[index].ReservationDate = date;
                reservations[index].ReservationTime = time;
                reservations[index].MealType = meal;
                reservations[index].SpecialRequest = request;
            }
        }
    }
}
