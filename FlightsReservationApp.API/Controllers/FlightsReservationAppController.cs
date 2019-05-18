using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.API.ModelMapping;
using FlightsReservationApp.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightsReservationApp.API.Controllers
{
    public class FlightsReservationAppController : Controller
    {
        private IFlightsRepo _repo;
        private ISeatsRepo _repo2;

        public FlightsReservationAppController(IFlightsRepo repo, ISeatsRepo repo2)
        {
            _repo = repo;
            _repo2 = repo2;
        }

        [Route("api/Flights")]
        public async Task<List<Flights_DTO>> GetAllFlights()
        {
            //var model = await _FlightsAppRepo.GetAllFlightsAsync();
            var model = await _repo.GetAllFlightsAsync();
            List<Flights_DTO> model_DTO = new List<Flights_DTO>();
            //Hier is DTO <-> Entity mapping noodzakelijk
            model_DTO = FlightsMapper.ConvertFlightstoDTO(model, ref model_DTO);

            return model_DTO;
        }

        [Route("api/Seats/{FlightId}")]
        public async Task<List<Seats_DTO>> GetSeatsForFlight(string FlightId)
        {
            var model = await _repo2.GetSeatsForFlightAsync(FlightId);

            List<Seats_DTO> model_DTO = new List<Seats_DTO>();

            model_DTO = SeatsMapper.ConvertSeatstoDTO(model, ref model_DTO);

            return model_DTO;
        }
    }
}