using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.EF.Models
{
    public record RegisterResult(bool Succeeded, string ErrorCode);
}
