using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Core.Models;

namespace FlightsReservationApp.Core.Repositories
{
    public interface ISeatsRepo
    {
        Task<IEnumerable<Seats>> GetSeatsForFlightAsync(string flight_id);
        List<Seats> CreateSeatsForFlight(Flights Flight);
        Task SetSeatToNotAvailable(Guid id);
        Task InsertOrderAndTickets(Orders order);

        Task InsertNewOrder(Orders order);
        Task InsertNewTickets(List<Tickets> tickets);
    }
}