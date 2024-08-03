using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record DetailedDeskDTO(Guid Id, Guid LocationId, string LocationCode, bool Availability, IEnumerable<DetailedReservationDTO> Reservation);
}
