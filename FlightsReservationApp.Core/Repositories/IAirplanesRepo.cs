using System.Collections.Generic;
using System.Threading.Tasks;
using FlightsReservationApp.Core.Models;

namespace FlightsReservationApp.Core.Repositories
{
    public interface IAirplanesRepo
    {
        Task<IEnumerable<Airplanes>> GetAllAirplanesAsync();
    }
}