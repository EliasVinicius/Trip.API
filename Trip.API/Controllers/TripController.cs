using Microsoft.AspNetCore.Mvc;
using Trip.Data.Models;
using Trip.Data.Repository;

namespace Trip.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripRepository _tripRepository;
        public TripController(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        [HttpGet("flight-result/oneway/{DeparturePoint}/{ArrivalPoint}/{DepartureDate}")]
        public async Task<IActionResult> GetFlights(string departurePoint,string arrivalPoint, DateTime departureDate)
        {
            var resultFlights = await _tripRepository.GetFlights(departurePoint, arrivalPoint, departureDate);
            if (resultFlights.Count > 0 ) return Ok(resultFlights);

            return BadRequest("Nenhuma viagem encontrada");
        }

        [HttpPost("do-booking-flight/oneway/{IdFlight}/{idCustomer}")]
        public async Task<IActionResult> PostBookingFlight(int idFlight, int idCustomer)
        {
            var resultInsertBook = await _tripRepository.InsertBook(idFlight, idCustomer);

            if (resultInsertBook > 0) return Ok(resultInsertBook);
            return BadRequest("Nao foi possivel inserir a reserva");
        }

        [HttpGet("booking-result/{idBooking}")]
        public async Task<IActionResult> GetBook(int idBooking)
        {
            var resultBooking = await _tripRepository.GetBooking(idBooking);
            if (resultBooking != null) return Ok(resultBooking);
            return BadRequest("Reserva não encontrada");

        }

    }
}