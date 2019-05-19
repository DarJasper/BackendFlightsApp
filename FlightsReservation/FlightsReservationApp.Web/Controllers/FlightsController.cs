using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsReservationApp.Core.Models;
using FlightsReservationApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlightsReservationApp.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly IFlightsRepo FlightsRepo;
        private readonly IAirplanesRepo AirplaneRepo;
        private readonly IAirportsRepo AirportRepo;
        private readonly ISeatsRepo SeatsRepo;

        public FlightsController(IFlightsRepo repo, IAirplanesRepo repo2, IAirportsRepo repo3, ISeatsRepo repo4)
        {
            this.FlightsRepo = repo;
            this.AirplaneRepo = repo2;
            this.AirportRepo = repo3;
            this.SeatsRepo = repo4;
        }

        public async Task<IActionResult> Index()
        {
            //1. flights ophalen
            var flights = await FlightsRepo.GetAllFlightsAsync();

            //2. Stuur naar de view
            return View(flights);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            //GET all airplanes
            var airplanes = await AirplaneRepo.GetAllAirplanesAsync();
            ViewData["Airplanes"] = new SelectList(airplanes, "Id", "Model");
            //GET all airports
            var airports = await AirportRepo.GetAllAirportsAsync();
            ViewData["Airports"] = new SelectList(airports, "Name", "Name");
            //Add them to viewmodel
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] Flights f)
        {
            //GET all airplanes
            var airplanes = await AirplaneRepo.GetAllAirplanesAsync();
            ViewData["Airplanes"] = new SelectList(airplanes, "Id", "Model");
            //GET all airports
            var airports = await AirportRepo.GetAllAirportsAsync();
            ViewData["Airports"] = new SelectList(airports, "Name", "Name");
            if (ModelState.IsValid)
            {
                try
                {
                    Flights flight = new Flights
                    {
                        Id = new Guid(),
                        FlightNumber = f.FlightNumber,
                        AirportDepartureName = f.AirportDepartureName,
                        AirportArrivalName = f.AirportArrivalName,
                        DepartureTime = f.DepartureTime,
                        ArrivalTime = f.ArrivalTime,
                        AirplaneId = f.AirplaneId
                    };
                    // TODO: Add insert logic here
                    await FlightsRepo.Add(flight);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(f);
                }
            }
            else
            {
                return View(f);
            }
        }
    }
}