using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public class AirportsRepo : IAirportsRepo
    {
        //fields
        private readonly ApplicationDbContext _context;

        //constructor injection (dependency injection)
        public AirportsRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        //READ: all Airports
        public async Task<IEnumerable<Airports>> GetAllAirportsAsync()
        {
            return await _context.Airports.ToListAsync();
        }
    }
}
