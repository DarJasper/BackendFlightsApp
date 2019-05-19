using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Core.Models;

namespace FlightsReservationApp.Core.Repositories
{
    public interface IFlightsRepo
    {
        //READ
        Task<IEnumerable<Flights>> GetAllFlightsAsync();

        //CREATE
        Task Add(Flights flight);
    }
}