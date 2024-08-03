using BookingSystem.Domain.Entities;
using BookingSystem.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.EF
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<LocationModel> Locations { get; set; }
        public DbSet<DeskModel> Desks { get; set; }
        public DbSet<ReservationModel> Reservations { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

       
    }
}
