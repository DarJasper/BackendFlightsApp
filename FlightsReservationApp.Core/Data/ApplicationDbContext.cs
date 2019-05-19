using System;
using System.Collections.Generic;
using System.Text;
using FlightsReservationApp.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlightsReservationApp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //initialiseren van tabellen (properties)
        public DbSet<Airplanes> Airplanes { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Seats> Seats { get; set; }
        public DbSet<Tickets> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Seats>()
                .HasOne(e => e.Ticket)
                .WithOne(e => e.Seat)
                .HasForeignKey<Tickets>(e => e.SeatId);
        }
    }
}
