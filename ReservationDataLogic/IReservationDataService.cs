using ReservationDataLogic;
using System;
using System.Collections.Generic;

namespace ReservationDataService
{
    public interface IReservationDataService
    {
        public void AddReservation(Reservation reservation);
        public List<Reservation> GetReservations();
        public Reservation GetReservation(int reservationId);
        public int GetReservationsCount();
        public void CancelReservation(int reservationId);
        public void UpdateReservation(int reservationId, DateTime date, string time, string meal, string request);
        public List<Reservation> LoadReservations();
        public void SaveReservations(List<Reservation> updatedReservations);
    }
}

