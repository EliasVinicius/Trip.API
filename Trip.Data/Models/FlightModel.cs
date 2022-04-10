using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trip.Data.Models
{
    public class FlightModel
    {
        public int ID_Flight { get; set; }
        public string? DepartureAirport { get; set; }

        public string? DeparturePoint { get; set; }

        public DateTime DepartureDate { get; set; }
        public string? DepartureTime { get; set; }

        public DateTime ArrivalDate { get; set; }
        public string? ArrivalTime { get; set; }

        public string? ArrivalPoint { get; set; }
        public string? ArrivalAirport { get; set; }
        public string? AeroLineName { get; set; }
        public int FlightNumber { get; set; }
        public float PriceAdult { get; set; }
        public float PriceChildren { get; set; }
    }
}
