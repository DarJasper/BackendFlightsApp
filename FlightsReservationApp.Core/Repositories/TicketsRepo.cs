using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public class TicketsRepo : ITicketsRepo
    {
        //fields
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        //constructor injection (dependency injection)
        public TicketsRepo(ApplicationDbContext context, IConfiguration config)
        {
            this._context = context;
            _config = config;
        }

        //Methodes
        //READ: all flights
        public async Task<IEnumerable<Tickets>> GetAllOrdersForAUser(Guid id)
        {
            //Door migrations kan ik hier geen entity framework gebruiken.
            //Heb niet gevonden hoe ik het fix
            var x = new List<Tickets>();
            return x;
        }
    }
}
