using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Data.Models
{
    public class BookingModel
    {
        int ID_Booking { get; set; }

        public FlightModel? FlightModel { get; set; }
        public CustomerModel? CustomerModel { get; set; }

        public DateTime DateBooking { get; set; }

    }
}
