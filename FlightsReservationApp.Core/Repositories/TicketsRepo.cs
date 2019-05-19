using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public class TicketsRepo : ITicketsRepo
    {
        //fields
        private readonly ApplicationDbContext _context;

        //constructor injection (dependency injection)
        public TicketsRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Methodes
        //READ: all flights
        public async Task<IEnumerable<Tickets>> GetAllOrdersForAUser(Guid id)
        {
            var x = await _context.Database.ExecuteSqlCommandAsync("");
            return x;

        }
    }
}
