using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record AvailableDeskDTO(Guid Id, string LocationCode, Guid LocationId);
}
