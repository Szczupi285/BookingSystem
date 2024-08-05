using BookingSystem.Domain.ValueObjects.Desk;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands
{
    public record ChangeReservedDesk(Guid LocationId,Guid oldDeskId, Guid NewDeskId, Guid EmployeeId, Guid ReservationId) : IRequest;
}
