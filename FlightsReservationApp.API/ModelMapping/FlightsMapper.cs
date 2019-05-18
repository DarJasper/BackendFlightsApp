using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.ModelMapping
{
    public class FlightsMapper
    {
        public static List<Flights_DTO> ConvertFlightstoDTO(IEnumerable<Flights> Flights, ref List<Flights_DTO> flights_DTOs)
        {
            foreach (Flights flight in Flights)
            {
                Flights_DTO flight_DTO = new Flights_DTO
                {
                    FlightNumber = (flight.FlightNumber is null) ? "" : flight.FlightNumber,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,

                    AirportDeparture = new Airports_DTO(),
                    AirportArrival = new Airports_DTO()
                };
                flight_DTO.AirportDeparture.Name = flight.AirportDeparture.Name;
                flight_DTO.AirportDeparture.City = flight.AirportDeparture.City;
                flight_DTO.AirportArrival.Name = flight.AirportArrival.Name;
                flight_DTO.AirportArrival.City = flight.AirportArrival.City;

                var temp_DTO = new Airplanes_DTO
                {
                    Model = flight.Airplane.Model,
                    Seats = flight.Airplane.Seats,
                    Rows = flight.Airplane.Rows,
                    Columns = flight.Airplane.Columns
                };

                flight_DTO.Airplane = temp_DTO;

                flights_DTOs.Add(flight_DTO);
            }
            return flights_DTOs;
        }

    }
}
