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

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var hasher = new PasswordHasher<IdentityUser>();
            base.OnModelCreating(builder);

            Guid AdminRoleId = Guid.NewGuid();
            Guid EmployeeRoleId = Guid.NewGuid();
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = AdminRoleId.ToString(),
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = EmployeeRoleId.ToString(),
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            Guid AdminId = Guid.NewGuid();
            Guid EmployeeId = Guid.NewGuid();
            var users = new List<IdentityUser>
            {
                new IdentityUser
                {
                    Id = AdminId.ToString(),
                    UserName = "Administrator",
                    NormalizedUserName = "ADMINISTRATOR",
                    Email = "admin@example.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "AdminPassword123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new IdentityUser
                {
                    Id = EmployeeId.ToString(),
                    UserName = "Employee",
                    NormalizedUserName = "EMPLOYEE",
                    Email = "employee@example.com",
                    NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "EmployeePassword123!"),
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            };

            builder.Entity<IdentityUser>().HasData(users);

            var userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId = AdminId.ToString(),
                    RoleId = AdminRoleId.ToString()
                },
                new IdentityUserRole<string>
                {
                    UserId = EmployeeId.ToString(),
                    RoleId = EmployeeRoleId.ToString()
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);

        }
    }
}
