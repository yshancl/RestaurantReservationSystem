using ReservationDataLogic;
using ReservationDataService;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReservationDataLogic
{
    using ReservationDataService;
    public class TextFileDataService : IReservationDataService
    {
        private readonly string filePath = "reservation.txt";
        private List<Reservation> reservations = new();
        private int nextId = 1;

        public TextFileDataService() => LoadFromFile();

        private void LoadFromFile()
        {
            reservations.Clear();
            if (!File.Exists(filePath)) return;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split('|');
                if (parts.Length == 9)
                {
                    reservations.Add(new Reservation
                    {
                        ReservationId = int.Parse(parts[0]),
                        FullName = parts[1],
                        PhoneNumber = parts[2],
                        NumGuests = int.Parse(parts[3]),
                        ReservationDate = DateTime.Parse(parts[4]),
                        BookingDateTime = DateTime.Parse(parts[5]),
                        SpecialRequest = parts[6],
                        ReservationTime = parts[7],
                        MealType = parts[8]
                    });
                }
            }
            nextId = reservations.Any() ? reservations.Max(r => r.ReservationId) + 1 : 1;
        }

        private void SaveToFile()
        {
            var lines = reservations.Select(r => $"{r.ReservationId}|{r.FullName}|{r.PhoneNumber}|{r.NumGuests}|{r.ReservationDate}|{r.BookingDateTime}|{r.SpecialRequest}|{r.ReservationTime}|{r.MealType}");
            File.WriteAllLines(filePath, lines);
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

