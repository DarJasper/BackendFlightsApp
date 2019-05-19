using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Airplanes
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Model { get; set; }
        public int Seats { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        //Navigation Properties
        public ICollection<Flights> Flights { get; set; }
    }
}
