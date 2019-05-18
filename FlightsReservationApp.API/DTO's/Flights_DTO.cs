using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.DTO_s
{
    public class Flights_DTO
    {
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public Airports_DTO AirportDeparture { get; set; }
        public Airports_DTO AirportArrival { get; set; }

        public Airplanes_DTO Airplane { get; set; }
    }
}
