using BookingSystem.Infrastructure.EF.DTO;
using BookingSystem.Infrastructure.EF.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<RegisterResult> RegisterUser(RegisterDTO registerDto)
        {
            var doesEmailExist = await _userManager.FindByEmailAsync(registerDto.Email);
            var doesUsernameExist = await _userManager.FindByNameAsync(registerDto.Username);

            if (doesEmailExist != null)
                return new RegisterResult(false, "Account with this E-Mail or Password already exists");
            else if (doesUsernameExist != null)
                return new RegisterResult(false, "Account with this E-Mail or Password already exists");

            IdentityUser user = new IdentityUser
            {
                UserName = registerDto.Username,
                Email = registerDto.Email,
            };

            await _userManager.CreateAsync(user, registerDto.Password);
            await _userManager.AddToRoleAsync(user, "Employee");

            return new RegisterResult(true, string.Empty);
        }
    }
}
