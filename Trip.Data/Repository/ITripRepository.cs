using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Data.Models;

namespace Trip.Data.Repository
{
   public interface ITripRepository
    {
        Task<List<FlightModel>> GetFlights(string DeparturePoint, string ArrivalPoint, DateTime DepartureDate);
        Task<int> InsertBook(int idflight, int idCustomer);
        Task<BookingModel> GetBooking(int idBook);
    }
}
