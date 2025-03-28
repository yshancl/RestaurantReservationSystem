﻿namespace ReservationBusinessLogic
{
    public class ReservationProcess
    {
        public static double pricePerGuest = 750;

        public static double CalculateTotalAmount(int numGuests)
        {
            return numGuests * pricePerGuest;
        }

        public static bool ValidatePayment(double amountPaid, double totalAmount)
        {
            return amountPaid >= totalAmount;
        }

        public static double CalculateChange(double amountPaid, double totalAmount)
        {
            return amountPaid >= totalAmount ? amountPaid - totalAmount : 0;
        }
    }
}