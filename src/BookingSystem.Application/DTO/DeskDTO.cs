using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record DeskDTO(Guid Id, string LocationCode, Guid LocationId, string Availability);
}
