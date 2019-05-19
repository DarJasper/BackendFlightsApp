using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FlightsReservationApp.Core.Models
{
    public class Orders
    {
        [Key]
        public Guid Id { get; set; }
        public float Price { get; set; }
        public DateTime DateOfEntry { get; set; }

        public Guid UserId { get; set; } //FK

        //Navigation property
        public IdentityUser User { get; set; }
        public IEnumerable<Tickets> Tickets { get; set; }
    }
}
