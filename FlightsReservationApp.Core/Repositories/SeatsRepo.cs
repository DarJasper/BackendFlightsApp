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
    public class SeatsRepo : ISeatsRepo
    {
        private readonly ApplicationDbContext _context;
        public SeatsRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

        //Get Seats for a Flight
        public async Task<IEnumerable<Seats>> GetSeatsForFlightAsync(string flight_id)
        {
            Guid flight_id_guid = new Guid(flight_id);
            var data = await _context.Seats
                .Where(s => s.FlightId == flight_id_guid)
                .OrderBy(s => s.Row)
                .ThenBy(s => s.Column)
                .ToListAsync();
            return data;
        }

        //Create Seats for a new Flight
        public List<Seats> CreateSeatsForFlight(Flights Flight)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            //Check which airplane is used for this flight
            var airplaneid = Flight.AirplaneId;
            var airplane = _context.Airplanes
                .Where(s => s.Id == airplaneid)
                .FirstOrDefault();

            //Initiate a list of seats for that flight
            List<Seats> seats = new List<Seats>();

            for (int i = 0; i < airplane.Rows; i++)
            {
                for (int j = 0; j < airplane.Columns; j++)
                {
                    Seats seat = new Seats
                    {
                        Id = Guid.NewGuid(),
                        Row = i + 1,
                        Column = alphabet[j],
                        Available = true,
                        FlightId = Flight.Id
                    };
                    seats.Add(seat);
                }
            }
            return seats;
        }

        public async Task SetSeatToNotAvailable(Guid id)
        {
            var x = _context.Seats
                .Where(s => s.Id == id)
                .FirstOrDefault()
                .Available = false;
            _context.SaveChanges();
        }

        public async Task InsertOrderAndTickets(Orders order)
        {
            await _context.Orders.AddAsync(order);
            _context.SaveChanges();
        }

        public async Task InsertNewOrder(Orders order)
        {
            _context.Database.ExecuteSqlCommand("Insert into Orders Values({0},{1},{2},{3})", order.Id, order.Price, order.DateOfEntry, order.UserId);
        }
        
        public async Task InsertNewTickets (List<Tickets> tickets)
        {
            await _context.Tickets.AddRangeAsync(tickets);
            _context.SaveChanges();
        } 
    }
}
