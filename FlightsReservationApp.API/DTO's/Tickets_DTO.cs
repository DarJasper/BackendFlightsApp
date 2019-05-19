using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.DTO_s
{
    public class Tickets_DTO
    {
        public Guid SeatId { get; set; }
        public Guid FlightId { get; set; }
        
        public Flights_DTO Flight { get; set; }
        public Seats_DTO Seat { get; set; }
    }
}
