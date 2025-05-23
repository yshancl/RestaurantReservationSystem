using ReservationDataLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReservationDataService
{
    public class TextFileDataService : IReservationDataService
    {
        private readonly string filePath = "reservations.txt";
        private List<Reservation> reservations = new List<Reservation>();

        public TextFileDataService()
        {
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
            {
                reservations = new List<Reservation>();
                return;
            }

            var lines = File.ReadAllLines(filePath);
            reservations = lines
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Reservation
                    {
                        FullName = parts[0],
                        PhoneNumber = parts[1],
                        NumGuests = int.Parse(parts[2]),
                        ReservationDate = DateTime.Parse(parts[3]),
                        BookingDateTime = DateTime.Parse(parts[4]),
                        SpecialRequest = parts[5],
                        ReservationTime = parts[6],
                        MealType = parts[7]
                    };
                }).ToList();
        }

        private void SaveToFile()
        {
            var lines = reservations.Select(r =>
                $"{r.FullName}|{r.PhoneNumber}|{r.NumGuests}|{r.ReservationDate:O}|{r.BookingDateTime:O}|{r.SpecialRequest}|{r.ReservationTime}|{r.MealType}");
            File.WriteAllLines(filePath, lines);
        }

        public void AddReservation(Reservation reservation)
        {
            reservations.Add(reservation);
            SaveToFile();
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
            {
                reservations.RemoveAt(index);
                SaveToFile();
            }
        }

        public void UpdateReservation(int index, DateTime date, string time, string meal, string request)
        {
            if (index >= 0 && index < reservations.Count)
            {
                reservations[index].ReservationDate = date;
                reservations[index].ReservationTime = time;
                reservations[index].MealType = meal;
                reservations[index].SpecialRequest = request;
                SaveToFile();
            }
        }
    }
}
