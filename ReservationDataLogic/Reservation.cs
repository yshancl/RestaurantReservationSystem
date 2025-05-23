using System;
using ReservationDataLogic;
using ReservationDataService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationDataLogic
{
    public class Reservation
    {
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }
            public int NumGuests { get; set; }
            public DateTime ReservationDate { get; set; }
            public DateTime BookingDateTime { get; set; }
            public string SpecialRequest { get; set; }
            public string ReservationTime { get; set; }
            public string MealType { get; set; }
    }
}
