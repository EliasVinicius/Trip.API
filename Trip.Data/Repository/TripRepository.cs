using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trip.Data.Context;
using Trip.Data.Models;
using Dapper;

namespace Trip.Data.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly DapperContext _context;
        public TripRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<List<FlightModel>> GetFlights(string DeparturePoint, string ArrivalPoint, DateTime DepartureDate)
        {
            var query = @$"
            SELECT * FROM Flight 
            WHERE DeparturePoint = @DeparturePoint
            AND ArrivalPoint = @ArrivalPoint
            AND DepartureDate = @DepartureDate";

            using (var connection = _context.CreateConnection())
            {
                
                var flightModels = await connection
                    .QueryAsync<FlightModel>(query,
                    new { DeparturePoint = DeparturePoint , ArrivalPoint = ArrivalPoint, DepartureDate  = DepartureDate });
                return flightModels.AsList();
            }
        }

        public async Task<int> InsertBook(int idflight, int idCustomer)
        {
            try
            {
                var query = @"
            INSERT INTO Booking
            VALUES (@Idflight,@IdCustomer,@Datebooking)";

                using (var connection = _context.CreateConnection())
                {

                    return await connection
                        .ExecuteAsync(query, new
                        { Idflight = idflight, IdCustomer = idCustomer, DateBooking = DateTime.Now });
                }
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public async Task<BookingModel> GetBooking(int idBooking)
        {
            var query = @"
            SELECT
            *
            FROM Booking b
            INNER JOIN Flight f on f.ID_Flight = b.FK_ID_Flight
            INNER JOIN Customer c on c.ID_Customer = b.FK_ID_Customer
            WHERE b.ID_Booking = @IdBooking";

            using (var connection = _context.CreateConnection())
            {

                var result = await connection
                    .QueryAsync<BookingModel, FlightModel, CustomerModel, BookingModel>(query, map: (bookingModel, flightModel, customerModel) =>
                   {
                       bookingModel.FlightModel = flightModel;
                       bookingModel.CustomerModel = customerModel;
                       
                       return bookingModel;
                   }, param:new { IdBooking = idBooking }
                    ,splitOn: "ID_Flight,ID_Customer");

                return result.FirstOrDefault() ?? new BookingModel();
            }
        }

    }
}
