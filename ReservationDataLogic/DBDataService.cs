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
        static string connectionString = "Data Source=DESKTOP-FFTVSBU\\SQLEXPRESS;Initial Catalog=RestaurantReservationSystem;Integrated Security=True;TrustServerCertificate=True;";
        static SqlConnection sqlConnection = new(connectionString);

        public void AddReservation(Reservation reservation)
        {
            var insert = @"INSERT INTO ReservationDetails (Name, PhoneNumber, NumOfGuests, ReservationDate, BookingDateTime, SpecialRequest, ReservationTime, MealType) 
                           VALUES (@FullName, @Phone, @Guests, @Date, @Booked, @Request, @Time, @Meal)";
            SqlCommand cmd = new(insert, sqlConnection);

            cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);  
            cmd.Parameters.AddWithValue("@FullName", reservation.FullName);
            cmd.Parameters.AddWithValue("@Phone", reservation.PhoneNumber);
            cmd.Parameters.AddWithValue("@Guests", reservation.NumGuests);
            cmd.Parameters.AddWithValue("@Date", reservation.ReservationDate.ToString());
            cmd.Parameters.AddWithValue("@Booked", reservation.BookingDateTime.ToString());
            cmd.Parameters.AddWithValue("@Request", (object)reservation.SpecialRequest ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Time", reservation.ReservationTime);
            cmd.Parameters.AddWithValue("@Meal", reservation.MealType);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Reservation> GetReservations()
        {
            var query = @"SELECT ReservationId, Name, PhoneNumber, NumOfGuests, ReservationDate, BookingDateTime, SpecialRequest, ReservationTime, MealType FROM ReservationDetails";
            SqlCommand cmd = new(query, sqlConnection);
            sqlConnection.Open();
            var reader = cmd.ExecuteReader();
            List<Reservation> list = new();

            while (reader.Read())
            {
                list.Add(new Reservation
                {
                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                    FullName = reader.GetString(reader.GetOrdinal("Name")),
                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                    NumGuests = reader.GetInt32(reader.GetOrdinal("NumOfGuests")),
                    ReservationDate = DateTime.Parse(reader.GetString(reader.GetOrdinal("ReservationDate"))),
                    BookingDateTime = DateTime.Parse(reader.GetString(reader.GetOrdinal("BookingDateTime"))),
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
                           SET ReservationDate=@Date, ReservationTime=@Time, MealType=@Meal, SpecialRequest=@Request 
                           WHERE ReservationId=@Id";
            SqlCommand cmd = new(update, sqlConnection);
            cmd.Parameters.AddWithValue("@Date", date.ToString());
            cmd.Parameters.AddWithValue("@Time", time);
            cmd.Parameters.AddWithValue("@Meal", meal);
            cmd.Parameters.AddWithValue("@Request", (object)request ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Id", reservationId);

            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Reservation> LoadReservations() => GetReservations();
        public void SaveReservations(List<Reservation> updatedReservations) { }
    }
}
