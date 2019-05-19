using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Seats
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int Row { get; set; }
        public char Column { get; set; }
        public bool Available { get; set; }
        public Guid FlightId { get; set; }

        //Navigation Property
        public Flights Flight { get; set; }
        public Tickets Ticket { get; set; }

    }
}
