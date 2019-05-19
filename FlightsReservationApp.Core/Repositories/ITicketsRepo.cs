using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Core.Models;

namespace FlightsReservationApp.Core.Repositories
{
    public interface ITicketsRepo
    {
        Task<IEnumerable<Tickets>> GetAllOrdersForAUser(Guid id);
    }
}