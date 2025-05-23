using ReservationDataLogic;
using ReservationDataService;
using System;
using System.Collections.Generic;

namespace ReservationDataLogic
{
    public interface IReservationDataService
    {
        void AddReservation(Reservation reservation);
        List<Reservation> GetReservations();
        Reservation GetReservation(int index);
        int GetReservationsCount();
        void CancelReservation(int index);
        void UpdateReservation(int index, DateTime date, string time, string meal, string request);
    }
}
