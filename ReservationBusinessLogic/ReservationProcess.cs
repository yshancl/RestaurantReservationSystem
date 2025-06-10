﻿using ReservationDataLogic;
using ReservationDataService;
using System;
using System.Collections.Generic;

namespace ReservationBusinessLogic
{
    public class ReservationProcess
    {
        private readonly double pricePerGuest = 750;
        private readonly IReservationDataService dataService;

        public ReservationProcess(IReservationDataService dataService)
        {
            this.dataService = dataService;
        }

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

        public void CancelReservation(int reservationId)
        {
            dataService.CancelReservation(reservationId);
        }

        public void UpdateReservation(int reservationId, DateTime date, string time, string meal, string request)
        {
            dataService.UpdateReservation(reservationId, date, time, meal, request);
        }

        public List<string> GetReservationDetails(int reservationId)
        {
            var r = dataService.GetReservation(reservationId);
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
