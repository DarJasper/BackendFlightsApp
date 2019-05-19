using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Flights
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FlightNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string AirportDepartureName { get; set; }
        public string AirportArrivalName { get; set; }
        public Guid AirplaneId { get; set; }

        //Navigation Properties
        public Airports AirportDeparture { get; set; }
        public Airports AirportArrival { get; set; }
        public Airplanes Airplane { get; set; }

        public ICollection<Tickets> Tickets { get; set; }
        public ICollection<Seats> Seats { get; set; }
    }
}
