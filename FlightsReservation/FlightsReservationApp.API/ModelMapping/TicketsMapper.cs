using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.ModelMapping
{
    public class TicketsMapper
    {
        public static Orders OrdersDTOtoReg(Order_DTO dto)
        {
            var tempList = new List<Tickets>();
            var tempGuid = Guid.NewGuid();

            foreach (var ticket in dto.Tickets)
            {
                Tickets tick = new Tickets
                {
                    Id = Guid.NewGuid(),
                    OrderId = tempGuid,
                    SeatId = ticket.SeatId,
                    FlightId = ticket.FlightId
                };
                tempList.Add(tick);
            }
            Orders order = new Orders
            {
                Id = tempGuid,
                Price = 123.45F,
                DateOfEntry = DateTime.Now,
                UserId = dto.UserId,
                Tickets = tempList
            };

            return order;
        }
    }
}
