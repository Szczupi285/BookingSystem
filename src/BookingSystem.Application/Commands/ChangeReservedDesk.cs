using BookingSystem.Domain.ValueObjects.Desk;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Commands
{
    public record ChangeReservation(Guid LocationId, Guid NewDeskId, Guid ReservationId) : IRequest;
}
