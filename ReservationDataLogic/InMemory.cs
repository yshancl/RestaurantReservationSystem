﻿using ReservationDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationDataLogic
{
    public class InMemory : IReservationDataService
    {
        private List<Reservation> reservations = new();
        private int nextId = 1;

        public InMemory()
        {
            reservations = new List<Reservation>
            {
                new Reservation
                {
                    ReservationId = nextId++,
                    FullName = "Ayisha",
                    PhoneNumber = "09171234567",
                    NumGuests = 2,
                    ReservationDate = DateTime.Today.AddDays(1),
                    BookingDateTime = DateTime.Now,
                    SpecialRequest = "Birthday setup",
                    ReservationTime = "6:00 PM",
                    MealType = "Dinner"
                },
                new Reservation
                {
                    ReservationId = nextId++,
                    FullName = "Nicole",
                    PhoneNumber = "09987654321",
                    NumGuests = 3,
                    ReservationDate = DateTime.Today.AddDays(2),
                    BookingDateTime = DateTime.Now,
                    SpecialRequest = "Near the window",
                    ReservationTime = "7:00 PM",
                    MealType = "Dinner"
                }
            };
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.ReservationId = nextId++;
            reservations.Add(reservation);
        }

        public List<Reservation> GetReservations() => reservations;

        public Reservation GetReservation(int reservationId) => reservations.FirstOrDefault(r => r.ReservationId == reservationId);

        public int GetReservationsCount() => reservations.Count;

        public void CancelReservation(int reservationId)
        {
            var r = GetReservation(reservationId);
            if (r != null) reservations.Remove(r);
        }

        public void UpdateReservation(int reservationId, DateTime date, string time, string meal, string request)
        {
            var r = GetReservation(reservationId);
            if (r != null)
            {
                r.ReservationDate = date;
                r.ReservationTime = time;
                r.MealType = meal;
                r.SpecialRequest = request;
            }
        }

        public List<Reservation> LoadReservations() => reservations;
        public void SaveReservations(List<Reservation> updatedReservations) => reservations = updatedReservations;
    }
}
