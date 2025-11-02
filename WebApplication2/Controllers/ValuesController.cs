using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationDataLogic;
using ReservationBusinessLogic;
using Microsoft.Extensions.Configuration; 

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ReservationProcess reservationProcess;

        public ValuesController(IConfiguration configuration) 
        {
            var dataService = new ReservationDataService.ReservationDataService();
            reservationProcess = new ReservationProcess(dataService, configuration); 
        }

        [HttpGet]
        public IEnumerable<Reservation> GetReservations()
        {
            return reservationProcess.GetReservations();
        }

        [HttpGet("details/{id}")]
        public IEnumerable<string> GetReservationDetails(int id)
        {
            return reservationProcess.GetReservationDetails(id);
        }

        [HttpPost]
        public IActionResult AddReservation([FromBody] Reservation reservation)
        {
            reservationProcess.AddReservation(
                reservation.FullName,
                reservation.PhoneNumber,
                reservation.NumGuests,
                reservation.ReservationDate,
                reservation.BookingDateTime,
                reservation.SpecialRequest,
                reservation.ReservationTime,
                reservation.MealType
            );

            return Ok("Reservation added.");
        }

        [HttpPatch("update")]
        public IActionResult UpdateReservation(int reservationId, DateTime date, string time, string meal, string request)
        {
            reservationProcess.UpdateReservation(reservationId, date, time, meal, request);
            return Ok("Reservation updated.");
        }

        [HttpDelete("{reservationId}")]
        public IActionResult CancelReservation(int reservationId)
        {
            reservationProcess.CancelReservation(reservationId);
            return Ok("Reservation canceled.");
        }

        [HttpGet("count")]
        public int GetCount()
        {
            return reservationProcess.GetReservationsCount();
        }

        [HttpGet("total")]
        public double GetTotalAmount(int guests)
        {
            return reservationProcess.CalculateTotalAmount(guests);
        }

        [HttpGet("validate-payment")]
        public bool ValidatePayment(double paid, double total)
        {
            return reservationProcess.ValidatePayment(paid, total);
        }

        [HttpGet("change")]
        public double CalculateChange(double paid, double total)
        {
            return reservationProcess.CalculateChange(paid, total);
        }
    }
}
