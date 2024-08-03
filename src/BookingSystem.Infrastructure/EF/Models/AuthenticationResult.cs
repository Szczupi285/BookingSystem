using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.EF.Models
{
    public record AuthenticationResult(bool Succeeded, string ErrorMessage);
}
