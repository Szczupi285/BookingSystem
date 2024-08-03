using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record DetailedReservationDTO(Guid Id, string UserId, string Username, string Email, DateTime StartDate, DateTime EndDate);
}
