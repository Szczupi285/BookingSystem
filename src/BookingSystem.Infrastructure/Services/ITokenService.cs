using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Services
{
    public interface ITokenService
    {
        Task<string> GenerateToken(IdentityUser user);
    }
}
