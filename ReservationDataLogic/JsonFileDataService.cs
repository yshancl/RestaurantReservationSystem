﻿using ReservationDataLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ReservationDataLogic
{
    using ReservationDataService;

    public class JsonFileDataService : IReservationDataService
    {
        private readonly string filePath = "reservation.json";
        private List<Reservation> reservations = new();
        private int nextId = 1;

        public JsonFileDataService() => LoadFromFile();

        private void LoadFromFile()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                reservations = JsonSerializer.Deserialize<List<Reservation>>(json) ?? new();
                nextId = reservations.Any() ? reservations.Max(r => r.ReservationId) + 1 : 1;
            }
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddReservation(Reservation reservation)
        {
            reservation.ReservationId = nextId++;
            reservations.Add(reservation);
            SaveToFile();
        }

        public List<Reservation> GetReservations() => reservations;

        public Reservation GetReservation(int reservationId) => reservations.FirstOrDefault(r => r.ReservationId == reservationId);

        public int GetReservationsCount() => reservations.Count;

        public void CancelReservation(int reservationId)
        {
            var r = GetReservation(reservationId);
            if (r != null) reservations.Remove(r);
            SaveToFile();
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
                SaveToFile();
            }
        }

        public List<Reservation> LoadReservations() => reservations;
        public void SaveReservations(List<Reservation> updatedReservations) => reservations = updatedReservations;
    }
}