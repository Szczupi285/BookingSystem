using BookingSystem.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityUser?> AuthenticateAsync(string email, string password);
    }
}
