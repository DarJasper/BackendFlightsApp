using FlightsReservationApp.API.DTO_s;
using FlightsReservationApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsReservationApp.API.ModelMapping
{
    public class SeatsMapper
    {
        public static List<Seats_DTO> ConvertSeatstoDTO(IEnumerable<Seats> Seats, ref List<Seats_DTO> seats_DTOs)
        {
            foreach (Seats seat in Seats)
            {
                Seats_DTO seat_DTO = new Seats_DTO
                {
                    Row = seat.Row,
                    Column = seat.Column,
                    Available = seat.Available,
                };
                seats_DTOs.Add(seat_DTO);
            }
            return seats_DTOs;
        }
    }
}
