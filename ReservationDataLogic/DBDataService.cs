using Microsoft.Data.SqlClient;
using ReservationDataLogic;
using System;
using System.Collections.Generic;

namespace ReservationDataService
{
    using Microsoft.Data.SqlClient;
    using ReservationDataLogic;

    public class DBDataService : IReservationDataService
    {
        static string connectionString = "Data Source=DESKTOP-U96CAG2\\SQLEXPRESS;Initial Catalog=RestaurantReservationSystem;Integrated Security=True;TrustServerCertificate=True;";
        static SqlConnection sqlConnection = new(connectionString);

        public void AddReservation(Reservation reservation)
        {
            var insert = @"INSERT INTO ReservationDetails (FullName, PhoneNumber, NumGuests, ReservationDate, BookingDateTime, SpecialRequest, ReservationTime, MealType) 
                           VALUES (@FullName, @PhoneNumber, @NumGuests, @ReservationDate, @BookingDateTime, @SpecialRequest, @ReservationTime, @MealType)";
            SqlCommand cmd = new(insert, sqlConnection);

            cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);  
            cmd.Parameters.AddWithValue("@FullName", reservation.FullName);
            cmd.Parameters.AddWithValue("@PhoneNumber", reservation.PhoneNumber);
            cmd.Parameters.AddWithValue("@NumGuests", reservation.NumGuests);
            cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
            cmd.Parameters.AddWithValue("@BookingDateTime", reservation.BookingDateTime);
            cmd.Parameters.AddWithValue("@SpecialRequest", (object)reservation.SpecialRequest ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationTime", reservation.ReservationTime);
            cmd.Parameters.AddWithValue("@MealType", reservation.MealType);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Reservation> GetReservations()
        {
            var query = @"SELECT ReservationId, FullName, PhoneNumber, NumGuests, ReservationDate, BookingDateTime, SpecialRequest, ReservationTime, MealType FROM ReservationDetails";
            SqlCommand cmd = new(query, sqlConnection);
            sqlConnection.Open();
            var reader = cmd.ExecuteReader();
            List<Reservation> list = new();

            while (reader.Read())
            {
                list.Add(new Reservation
                {
                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                    NumGuests = reader.GetInt32(reader.GetOrdinal("NumGuests")),
                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                    BookingDateTime = reader.GetDateTime(reader.GetOrdinal("BookingDateTime")),
                    SpecialRequest = reader.IsDBNull(reader.GetOrdinal("SpecialRequest")) ? null : reader.GetString(reader.GetOrdinal("SpecialRequest")),
                    ReservationTime = reader.GetString(reader.GetOrdinal("ReservationTime")),
                    MealType = reader.GetString(reader.GetOrdinal("MealType"))
                });
            }

            sqlConnection.Close();
            return list;
        }

        public Reservation GetReservation(int reservationId) =>
            GetReservations().FirstOrDefault(r => r.ReservationId == reservationId);

        public int GetReservationsCount() => GetReservations().Count;

        public void CancelReservation(int reservationId)
        {
            var delete = "DELETE FROM ReservationDetails WHERE ReservationId = @ReservationId";
            SqlCommand cmd = new(delete, sqlConnection);
            cmd.Parameters.AddWithValue("@ReservationId", reservationId);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void UpdateReservation(int reservationId, DateTime date, string time, string meal, string request)
        {
            var update = @"UPDATE ReservationDetails 
                           SET ReservationDate=@ReservationDate, ReservationTime=@ReservationTime, MealType=@MealType, SpecialRequest=@SpecialRequest 
                           WHERE ReservationId=@ReservationId";
            SqlCommand cmd = new(update, sqlConnection);
            cmd.Parameters.AddWithValue("@ReservationDate", date);
            cmd.Parameters.AddWithValue("@ReservationTime", time);
            cmd.Parameters.AddWithValue("@MealType", meal);
            cmd.Parameters.AddWithValue("@SpecialRequest", (object)request ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ReservationId", reservationId);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Reservation> LoadReservations() => GetReservations();
        public void SaveReservations(List<Reservation> updatedReservations) { }
    }
}
