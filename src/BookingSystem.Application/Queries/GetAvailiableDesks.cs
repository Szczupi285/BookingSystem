using BookingSystem.Application.DTO;
using BookingSystem.Domain.ValueObjects.Location;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Application.Queries
{
    public record GetAvailiableDesks(Guid LocationId, DateTime StartDate, DateTime EndDate, int PageNumber, int PageSize) : IRequest<IEnumerable<AvailableDeskDTO>>;
}
