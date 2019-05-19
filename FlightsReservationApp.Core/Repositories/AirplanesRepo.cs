using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservationApp.Core.Repositories
{
    public class AirplanesRepo : IAirplanesRepo
    {
        //fields
        private readonly ApplicationDbContext _context;

        //constructor injection (dependency injection)
        public AirplanesRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        //READ: all Airplanes
        public async Task<IEnumerable<Airplanes>> GetAllAirplanesAsync()
        {
            return await _context.Airplanes.ToListAsync();
        }
    }
}
