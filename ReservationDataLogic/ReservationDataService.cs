using ReservationDataLogic;
using System;
using System.Collections.Generic;

namespace ReservationDataService
{
    public class ReservationDataService : IReservationDataService
    {
        private IReservationDataService dataService;

        public ReservationDataService()
        {
            //dataService = new TextFileDataService();
            //dataService = new JsonFileDataService();
            dataService = new DBDataService();
            //dataService = new InMemory();
        }

        public void AddReservation(Reservation reservation)
        {
            dataService.AddReservation(reservation);
        }

        public List<Reservation> GetReservations()
        {
            return dataService.GetReservations();
        }

        public Reservation GetReservation(int reservationId)
        {
            return dataService.GetReservation(reservationId);
        }

        public int GetReservationsCount()
        {
            return dataService.GetReservationsCount(); 
        }

        public void CancelReservation(int reservationId)
        {
            dataService.CancelReservation(reservationId);
        }

        public void UpdateReservation(int reservationId, DateTime date, string time, string meal, string request)
        {
            dataService.UpdateReservation(reservationId, date, time, meal, request);
        }

        public List<Reservation> LoadReservations()
        {
            return dataService.LoadReservations();
        }

        public void SaveReservations(List<Reservation> updatedReservations)
        {
            dataService.SaveReservations(updatedReservations);
        }
    }
}
