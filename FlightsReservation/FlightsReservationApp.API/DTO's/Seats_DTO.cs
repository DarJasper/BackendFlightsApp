using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.DTO_s
{
    public class Seats_DTO
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public char Column { get; set; }
        public bool Available { get; set; }
    }
}
