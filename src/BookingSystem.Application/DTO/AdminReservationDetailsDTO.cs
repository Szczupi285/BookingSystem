using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.DTO
{
    public record AdminReservationDetailsDTO(Guid Id, Guid EmployeeId, Guid DeskId, DateTime StartDate, DateTime EndDate, string EmployeeName, string EmployeeSurname);
}
