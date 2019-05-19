using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.DTO_s
{
    public class Order_DTO
    {
        public Guid UserId { get; set; }

        public IEnumerable<Tickets_DTO> Tickets { get; set; }
    }
}
