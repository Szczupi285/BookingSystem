using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record ReserveDeskRequestDTO(Guid LocationId, Guid DeskId, DateDTO startDate, byte numOfDays);
}
