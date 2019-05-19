using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Tickets
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid OrderId { get; set; }
        public Guid SeatId { get; set; }
        public Guid FlightId { get; set; }

        //Navigation Properties
        public Orders Order { get; set; }
        public Seats Seat { get; set; }
        public Flights Flight { get; set; }
    }
}
