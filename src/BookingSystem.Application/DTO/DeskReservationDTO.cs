using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    
    public record DeskReservationDTO(Guid Id, string LocationCode, Guid LocationId, bool Availability, IEnumerable<ReservationDTO> ReservationDTOs);
}
