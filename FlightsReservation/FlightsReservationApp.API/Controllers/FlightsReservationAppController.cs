using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.API.ModelMapping;
using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FlightsReservationApp.API.Controllers
{
    [Route("api")]
    public class FlightsReservationAppController : Controller
    {
        private IFlightsRepo _repo;
        private ISeatsRepo _repo2;

        public FlightsReservationAppController(IFlightsRepo repo, ISeatsRepo repo2)
        {
            _repo = repo;
            _repo2 = repo2;
        }

        [Route("Flights")]
        public async Task<List<Flights_DTO>> GetAllFlights()
        {
            //var model = await _FlightsAppRepo.GetAllFlightsAsync();
            var model = await _repo.GetAllFlightsAsync();
            List<Flights_DTO> model_DTO = new List<Flights_DTO>();
            //Hier is DTO <-> Entity mapping noodzakelijk
            model_DTO = FlightsMapper.ConvertFlightstoDTO(model, ref model_DTO);

            return model_DTO;
        }

        [Route("Seats/{FlightId}")]
        public async Task<Flights_DTO> GetSeatsForFlight(Guid FlightId)
        {
            var model = await _repo2.GetSeatsForFlightAsync(FlightId);

            List<Seats_DTO> model_DTO = new List<Seats_DTO>();

            model_DTO = SeatsMapper.ConvertSeatstoDTO(model, ref model_DTO);

            var flight = new Flights_DTO()
            {
                Id = FlightId,
                Seats = model_DTO
            };

            return flight;
        }

        [HttpPost]
        [Route("Seats/Reserve")]
        public async Task<IActionResult> Reserve([FromBody] Order_DTO model)
        {
            try
            {
                foreach (var ticket in model.Tickets)
                {
                    await _repo2.SetSeatToNotAvailable(ticket.SeatId);
                }
                //var x = TicketsMapper.OrdersDTOtoReg(model);
                //return BadRequest(x);
                //await _repo2.InsertOrderAndTickets(x);
                var x = new Orders() {
                    Id = Guid.NewGuid(),
                    Price = 123.45F,
                    DateOfEntry = DateTime.Now,
                    UserId = model.UserId,
                };

                await _repo2.InsertNewOrder(x);

                var y = new List<Tickets>();
                foreach (var t in model.Tickets)
                {
                    Tickets tick = new Tickets
                    {
                        Id = Guid.NewGuid(),
                        OrderId = x.Id,
                        SeatId = t.SeatId,
                        FlightId = t.FlightId
                    };
                    y.Add(tick);
                }
                await _repo2.InsertNewTickets(y);

                return Ok("Succes!");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong! " + ex);
            }
           
        }
    }
}