using ReservationDataLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ReservationDataLogic
{
    public class JsonFileDataService : IReservationDataService
    {
        private readonly string filePath = "reservations.json";
        private List<Reservation> reservations = new List<Reservation>();

        public JsonFileDataService()
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

            var json = File.ReadAllText(filePath);
            reservations = JsonSerializer.Deserialize<List<Reservation>>(json) ?? new List<Reservation>();
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(reservations, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
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
