using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Airports
    {
        [Key]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }

        //Navigation Properties
        [InverseProperty("AirportDeparture")]
        public ICollection<Flights> DepartureFlights { get; set; }
        [InverseProperty("AirportArrival")]
        public ICollection<Flights> ArrivalFlights { get; set; }
    }
}
