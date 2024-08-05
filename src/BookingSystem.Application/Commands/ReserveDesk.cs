using BookingSystem.Application.DTO;
using BookingSystem.Domain.ValueObjects.Desk;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands
{
    public record ReserveDesk(Guid LocationId, Guid DeskId, Guid EmployeeId, DateDTO startDate, byte numOfDays) : IRequest;
}
