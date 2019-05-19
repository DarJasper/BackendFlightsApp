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
    public class FlightsRepo : IFlightsRepo
    {
        //fields
        private readonly ApplicationDbContext _context;
        private readonly ISeatsRepo _repo;

        //constructor injection (dependency injection)
        public FlightsRepo(ApplicationDbContext context, ISeatsRepo repo)
        {
            this._context = context;
            this._repo = repo;
        }

        //Methodes
        
        //READ: all flights
        public async Task<IEnumerable<Flights>> GetAllFlightsAsync()
        {
            return await _context.Flights
                .OrderBy(f => f.DepartureTime)
                .Include(f => f.Airplane)
                .Include(f => f.AirportDeparture)
                .Include(f => f.AirportArrival)
                .ToListAsync();
        }

        //CREATE
        public async Task Add(Flights flight)
        {
            await _context.Flights.AddAsync(flight);
            _context.SaveChanges();

            List<Seats> seatList = _repo.CreateSeatsForFlight(flight);

            await _context.Seats.AddRangeAsync(seatList);
            _context.SaveChanges();

        }
    }
}
