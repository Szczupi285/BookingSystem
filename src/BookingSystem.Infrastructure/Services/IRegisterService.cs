using BookingSystem.Infrastructure.EF.DTO;
using BookingSystem.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Services
{
    public interface IRegisterService
    {
        Task<RegisterResult> RegisterUser(RegisterDTO registerDto);
    }
}
